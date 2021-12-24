using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.UsuallyCommon;
using Core.AppSystemServices;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Core.CacheServices;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Core.DataBaseServices;
using FreeSql.Internal.Model;
using Core.FreeSqlServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Core.AppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : BaseController
    {
        /// <summary>
        /// 注入接口
        /// </summary>
        public readonly IMapper mapper;
        public CommonServices _commonServices { get; set; }

        public LogServices _logServices { get; set; }

        public DataBaseServices.DataBaseServices _dataBaseServices {  get; set; }
             
        public CommonController(MenuServices _menuServices, IMapper _mapper, CommonServices commonServices,
            DataBaseServices.DataBaseServices dataBaseServices,
            LogServices logServices
            )
        {
            mapper = _mapper;
            _commonServices = commonServices;
            _dataBaseServices = dataBaseServices;
            _logServices = logServices;
        }

        

        /// <summary>
        /// 获取列头
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetHeader")]
        [Authorize]
        public Response<List<ShowColumns>> GetHeader([FromBody] BaseRequest<ShowColumns> request)
        {
            Response<List<ShowColumns>> response = new Response<List<ShowColumns>>();
            var hiddencolumns = typeof(BaseCompany).GetPropertyList();

            var menuid = string.IsNullOrEmpty(request.Filter) ? Guid.Empty : request.Filter.ToGuid();
            var hascolumns = _commonServices.CheckShowColumns(request.TableName, menuid);
            var tabletype = request.TableName.GetClassType();
            var serializerSettings = new JsonSerializerSettings
            {
                // 设置为驼峰命名
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            if (!hascolumns)
            {
                List<Column> columns = new List<Column>();
                switch (request.DataBaseName.ToStringExtension().ToUpper())
                {
                    case "LOGS":
                        columns = _dataBaseServices.GetColumn(DataBaseFactory.Core_Log.FreeSql, DataBaseFactory.Core_Application.DefaultDataType, request.TableName);
                        break;
                    default:
                        columns = _dataBaseServices.GetColumn(DataBaseFactory.Core_Application.FreeSql, DataBaseFactory.Core_Application.DefaultDataType, request.TableName);
                        break;
                }
                List<ShowColumns> showColumns = new List<ShowColumns>();

                var sort = 1; 
                columns.ForEach(x =>
                {
                    ShowColumns showcolumn = new ShowColumns()
                    {
                        MenusId = menuid,
                        ColumnName = x.ColumnName.ToFirstCharToLower(),
                        ColumnDescription = x.ColumnDescription,
                        TableName = x.TableName,
                        DataBaseName = x.DataBaseName,
                        ColumnWidth = Math.Ceiling((800 / (columns.Count() - 5)).ToDecimal()).ToStringExtension(),
                        IsShow = !hiddencolumns.Any(p => p.ToUpper() == x.ColumnName.ToUpper()),
                        CompanysId = session.User.CompanysId,
                        CsharpType = x.SQLType.SqlTypeToCSharpType(),
                        Postion = ColumnDataAlignEnum.Center.GetDescription(),
                        Sort = sort,
                        MaxLength = x.MaxLength.ToInt32(),
                        IsRequired = x.IsRequire,
                        IsEditShow = !hiddencolumns.Any(p => p.ToUpper() == x.ColumnName.ToUpper()),
                        IsLike = x.SQLType.SqlTypeToCSharpType() == typeof(String).Name && x.MaxLength > 0 && x.MaxLength <= 500
                    };

                    if (showcolumn.ColumnDescription.Contains("密码"))
                    {
                        showcolumn.IsShow = false;
                        showcolumn.IsEditShow = false;
                    }

                    if (showcolumn.CsharpType == typeof(Boolean).Name)
                    {
                        showcolumn.TargetSource = "BaseData";
                        showcolumn.SourceValue = typeof(BooleanEnum).GetClassOrEnumDescription();
                    }

                    if (showcolumn.ColumnDescription.Contains("手机"))
                    {
                        showcolumn.ValidType = ValidTypeEnum.IsPhone.ToString();
                    }
                    if (showcolumn.ColumnDescription.Contains("邮箱"))
                    {
                        showcolumn.ValidType = ValidTypeEnum.IsEmail.ToString();
                    }
                    if (tabletype != null)
                    {
                        var prportys = tabletype.GetProperty(x.ColumnName.ToFirstCharToUpper());
                        if (prportys != null && prportys.PropertyType.IsEnum)
                        {
                            showcolumn.TargetSource = "Enum";
                            showcolumn.SourceValue = prportys.Name;
                            showcolumn.Json = JsonConvert.SerializeObject(prportys.PropertyType.GetListEnumClass(), Formatting.None, serializerSettings);
                        }
                    }
                    sort++;
                    showColumns.Add(showcolumn);
                });
                _commonServices.SaveShowColumns(showColumns);
            }
            response.Data = _commonServices.GetShowColumns(request.TableName, menuid);
   
            // 处理验证规则
            JObject jobject = new JObject(); 
            response.Data.ForEach(x =>
            {
                JArray jarray = new JArray();
                // 处理数据源
                if (!string.IsNullOrEmpty(x.TargetSource))
                {
                    var name = x.SourceValue.Trim();
                    switch (x.TargetSource)
                    {
                        case "Table":
                            var tabledata = _commonServices.GetAllEntitys(name,session.User.CompanysId);
                            x.Json = JsonConvert.SerializeObject(tabledata, Formatting.None, serializerSettings);
                            break;
                        case "BaseData":
                          
                            var listdata = _commonServices.GetBaseDataDeatil(name, session.User.CompanysId);
                            //dirs.Add(new KeyValuePair<string, object>(name, listdata));
                            x.Json =  JsonConvert.SerializeObject(listdata, Formatting.None, serializerSettings);
                            break;
                        default:
                            break;
                    }
                } 
                // 必须
                if (x.IsRequired)
                {
                    RequiredRule requiredRule = new RequiredRule() { message = $"请输入{x.ColumnDescription}" };
                    jarray.Add(JObject.FromObject(requiredRule));
                }
                if ((x.CsharpType == "String" || x.CsharpType == "string") && x.MaxLength != -1)
                {
                    LengthRule lengthRule = new LengthRule() { message = $"长度在{1}到{x.MaxLength}", max = x.MaxLength };
                    jarray.Add(JObject.FromObject(lengthRule));
                }
                if (!string.IsNullOrEmpty(x.ValidType))
                {
                    FiledValidatorRule filedValidatorRule = new FiledValidatorRule() { validator = x.ValidType };
                    jarray.Add(JObject.FromObject(filedValidatorRule));
                }
                if (jobject.Property(x.ColumnName) == null)
                    jobject.Add(x.ColumnName, jarray);
            });

            response.Rules = jobject.ToString();

            return response;
        }

        /// <summary>
        /// 获取列头
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetList")]
        [Authorize]
        public ResponseList<object> GetList([FromBody] BaseRequest<string> request)
        {
            ResponseList<object> response = new ResponseList<object>();
            
            switch (request.DataBaseName.ToStringExtension().ToUpper())
            {
                case "LOGS":
                    response.Data = _logServices.GetList(request);
                    break;
                default:
                    response.Data = _commonServices.GetList(request);
                    break;
            }
          
           
            response.TotalCount = request.TotalCount;
            return response;
        }

        /// <summary>
        /// 获取列头
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetTreeList")]
        [Authorize]
        public ResponseList<object> GetTreeList([FromBody] BaseRequest<string> request)
        {
            ResponseList<object> response = new ResponseList<object>();

            switch (request.DataBaseName.ToStringExtension().ToUpper())
            {
                case "LOGS":
                    response.Data = _logServices.GetList(request);
                    break;
                default:
                    response.Data = _commonServices.GetTreeList(request);
                    break;
            } 

            response.TotalCount = request.TotalCount;
            return response;
        }


        [HttpPost("Remove")]
        public Response<dynamic> Remove([FromBody] ModifyRequest request)
        {
            Response<dynamic> response = new Response<dynamic>();
            response.Data = _commonServices.RemoveEntity(request);
            return response;
        }

        [HttpPost("Save")]
        public Response<dynamic> Save([FromBody] ModifyRequest request)
        {
            Response<dynamic> response = new Response<dynamic>();
            var type = request.TableName.GetClassType();
            dynamic model = JsonConvert.DeserializeObject(Convert.ToString(request.Model), type);

            if (model.Id == Guid.Empty)
            {
                model.CreateUserId = this.session.User.Id;
                model.CreateTime = DateTime.UtcNow;
                model.CompanysId = this.session.User.CompanysId;
            }
            else
            {
                model.ModifyUserId = this.session.User.Id;
                model.ModifyTime = DateTime.UtcNow;
            }
            request.Model = JsonConvert.SerializeObject(model);
            response.Data = _commonServices.SaveEntitys(request);
            return response;
        }

        [HttpPost("GetTables")]
        public ResponseList<EnumClass> GetTables()
        {
            ResponseList<EnumClass> response = new ResponseList<EnumClass>();
            List<EnumClass> list = new List<EnumClass>(); 
            var table = _dataBaseServices.GetTable(DataBaseFactory.Core_Application.FreeSql, DataBaseFactory.Core_Application.DefaultDataType);
            table.ForEach(x =>
            {
                list.Add(new EnumClass() { Name = x.TableName, Description = x.TableDescription });
            });
            response.Data = list;
            return response; 
        }


        /// <summary>
        /// 获取指定连接columns
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        [HttpPost("GetColumns")]
        public ResponseList<Column> GetColumns([FromBody] Table tab)
        {
            ResponseList<Column> response = new ResponseList<Column>();
            List<Column> list = new List<Column>();
            var freesql = new FreeSqlFactory(tab.TableDescription);
            response.Data = _dataBaseServices.GetColumn(freesql.FreeSql, freesql.FreeSql.Ado.DataType,tab.TableName); 
            return response;
        }


        /// <summary>
        /// 获取当前连接columns
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        [HttpPost("GetCurrentColumns")]
        public ResponseList<Column> GetCurrentColumns([FromBody] Table tab)
        {
            ResponseList<Column> response = new ResponseList<Column>();
            List<Column> list = new List<Column>(); 
            response.Data = _dataBaseServices.GetColumn(_commonServices._FreeSql, _commonServices._FreeSql.Ado.DataType, tab.TableName);
            return response;
        }


        [HttpPost("GetALLConnections")]
        public ResponseList<TreeClass> GetALLConnections()
        {
            ResponseList<TreeClass> response = new ResponseList<TreeClass>();
            List<TreeClass> list = new List<TreeClass>();
            _commonServices.GetConnections(new ConnectionString() {  CompanysId = this.session.User.CompanysId}).ForEach(x => {

                var node = new TreeClass() { Id = x.Id.ToString(),Name = x.Address  };
                node.children = new List<TreeClass>();

                var connectionstr = x.GetConnectionString();
                 
                FreeSqlFactory freesql = null;  
                // 添加缓存连接
                if (MemoryCacheManager.GetCache(connectionstr) != null)
                    freesql = (FreeSqlFactory)MemoryCacheManager.GetCache(connectionstr);
                else
                {
                    freesql = new FreeSqlFactory(x.GetConnectionString());
                    MemoryCacheManager.SetCache<FreeSqlFactory>(connectionstr, freesql, null);
                }
                   

                var databases = _dataBaseServices.GetDataBase(freesql.FreeSql, x.DataType);
                databases.ForEach(p => {
                    x.DefaultDataBase = p.DataBaseName;

                    var connectionstr = x.GetConnectionString();

                    freesql = new FreeSqlFactory(connectionstr);
                    var databasenode = new TreeClass() { Id =Guid.NewGuid().ToString(), Name = p.DataBaseName };
                    databasenode.children = new List<TreeClass>();

                    var tables = _dataBaseServices.GetTable(freesql.FreeSql, x.DataType);
                    tables.ForEach(o=>{
                        var tablenode = new TreeClass() { Id = Guid.NewGuid().ToString(),HasDescription = o.HasDescription, Name = o.TableName,Description = o.TableDescription,Props = connectionstr };
                        tablenode.children = new List<TreeClass>(); 
                        databasenode.children.Add(tablenode);
                    }); 
                    node.children.Add(databasenode);
                }); 
                list.Add(node);
            }); 
         
            response.Data = list;
            return response;
        }

        [HttpPost("AddExtendedproperty")]
        public Response<string> AddExtendedproperty([FromBody]  Column column)
        {
            Response<string> response = new Response<string>();

            var connectionstr = column.DefaultValue;
            FreeSqlFactory freesql = null;
            // 添加缓存连接
            if (MemoryCacheManager.GetCache(connectionstr) != null)
                freesql = (FreeSqlFactory)MemoryCacheManager.GetCache(connectionstr);
            else
            {
                freesql = new FreeSqlFactory(connectionstr);
                MemoryCacheManager.SetCache<FreeSqlFactory>(connectionstr, freesql, null);
            }
             
            _dataBaseServices.AddExtendedproperty(freesql.FreeSql, freesql.FreeSql.Ado.DataType, column.TableName,column.ColumnName,column.ColumnDescription);
            return response;
        }


        [HttpPost("ModifyExtendedproperty")]
        public Response<string> ModifyExtendedproperty([FromBody] Column column)
        {
            Response<string> response = new Response<string>();

            var connectionstr = column.DefaultValue;
            FreeSqlFactory freesql = null;
            // 添加缓存连接
            if (MemoryCacheManager.GetCache(connectionstr) != null)
                freesql = (FreeSqlFactory)MemoryCacheManager.GetCache(connectionstr);
            else
            {
                freesql = new FreeSqlFactory(connectionstr);
                MemoryCacheManager.SetCache<FreeSqlFactory>(connectionstr, freesql, null);
            }
            _dataBaseServices.ModifyExtendedproperty(freesql.FreeSql, freesql.FreeSql.Ado.DataType, column.TableName, column.ColumnName, column.ColumnDescription);
            return response;
        }


        [HttpPost("AddTableExtendedproperty")]
        public Response<string> AddExteAddTableExtendedpropertyndedproperty([FromBody] Column column)
        {
            Response<string> response = new Response<string>();

            var connectionstr = column.DefaultValue;
            FreeSqlFactory freesql = null;
            // 添加缓存连接
            if (MemoryCacheManager.GetCache(connectionstr) != null)
                freesql = (FreeSqlFactory)MemoryCacheManager.GetCache(connectionstr);
            else
            {
                freesql = new FreeSqlFactory(connectionstr);
                MemoryCacheManager.SetCache<FreeSqlFactory>(connectionstr, freesql, null);
            }
            _dataBaseServices.AddTableExtendedproperty(freesql.FreeSql, freesql.FreeSql.Ado.DataType, column.TableName,  column.TableDescription);
            return response;
        }


        [HttpPost("ModifyTableExtendedproperty")]
        public Response<string> ModifyTableExtendedproperty([FromBody] Column column)
        {
            Response<string> response = new Response<string>();

            var connectionstr = column.DefaultValue;
            FreeSqlFactory freesql = null;
            // 添加缓存连接
            if (MemoryCacheManager.GetCache(connectionstr) != null)
                freesql = (FreeSqlFactory)MemoryCacheManager.GetCache(connectionstr);
            else
            {
                freesql = new FreeSqlFactory(connectionstr);
                MemoryCacheManager.SetCache<FreeSqlFactory>(connectionstr, freesql, null);
            }
            _dataBaseServices.ModifyTableExtendedproperty(freesql.FreeSql, freesql.FreeSql.Ado.DataType, column.TableName, column.TableDescription);
            return response;
        }


    }

   
}
