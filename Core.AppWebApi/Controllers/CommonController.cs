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
using Core.AppSystemServices;
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
        public CommonServices commonServices { get; set; }

        DataBaseServices.DataBaseServices dbservices = new Core.DataBaseServices.DataBaseServices();
        public CommonController(MenuServices _menuServices, IMapper _mapper, CommonServices _commonServices)
        {
            mapper = _mapper;
            commonServices = _commonServices;
        }

        /// <summary>
        /// 获取列头
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetListHeader")]
        [Authorize]
        public Response<List<ShowColumns>> GetListHeader([FromBody] BaseRequest<ShowColumns> request)
        {
            Response<List<ShowColumns>> response = new Response<List<ShowColumns>>();
            var hiddencolumns = typeof(BaseCompany).GetPropertyList();
            var hascolumns = commonServices.CheckShowColumns(request.TableName);
            if (!hascolumns)
            {
                var columns = dbservices.GetColumn(DataBaseFactory.Core_Application.FreeSql, DataBaseFactory.Core_Application.DefaultDataType, request.TableName);
                List<ShowColumns> showColumns = new List<ShowColumns>();
                columns.ForEach(x =>
                {
                    ShowColumns showcolumn = new ShowColumns()
                    {
                        ColumnName = x.ColumnName.ToFirstCharToLower(),
                        ColumnDescription = x.ColumnDescription,
                        TableName = x.TableName,
                        DataBaseName = x.DataBaseName,
                        ColumnWidth = 150.ToStringExtension(),
                        IsShow = !hiddencolumns.Any(p => p.ToUpper() == x.ColumnName.ToUpper()),
                        CompanysId = session.User.CompanysId
                    };
                    showColumns.Add(showcolumn);
                });
                commonServices.SaveShowColumns(showColumns);
            }
            response.Data = commonServices.GetShowColumns(request.TableName);
            return response;
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
            var hascolumns = commonServices.CheckShowColumns(request.TableName);
            var tabletype = request.TableName.GetClassType();
            var serializerSettings = new JsonSerializerSettings
            {
                // 设置为驼峰命名
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };


            if (!hascolumns)
            {
                var columns = dbservices.GetColumn(DataBaseFactory.Core_Application.FreeSql, DataBaseFactory.Core_Application.DefaultDataType, request.TableName);
                List<ShowColumns> showColumns = new List<ShowColumns>();

                var sort = 1;
                columns.ForEach(x =>
                {
                    ShowColumns showcolumn = new ShowColumns()
                    {
                        ColumnName = x.ColumnName.ToFirstCharToLower(),
                        ColumnDescription = x.ColumnDescription,
                        TableName = x.TableName,
                        DataBaseName = x.DataBaseName,
                        ColumnWidth = 120.ToStringExtension(),
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
                commonServices.SaveShowColumns(showColumns);
            }
            response.Data = commonServices.GetShowColumns(request.TableName);
            //List<KeyValuePair<string, object>> dirs = new List<KeyValuePair<string, object>>();


           
            // 处理验证规则
            JObject jobject = new JObject(); 
            response.Data.ForEach(x =>
            {
                JArray jarray = new JArray();
                // 处理数据源
                if (!string.IsNullOrEmpty(x.TargetSource))
                {

                    switch (x.TargetSource)
                    {
                        case "Table":
                            break;
                        case "BaseData":
                            var name = x.SourceValue.Trim();
                            var listdata = commonServices.GetBaseDataDeatil(name, session.User.CompanysId);
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

            //if (dirs.Count > 0)
            //{
            //    response.Other = dirs;
            //}
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
            response.Data = commonServices.GetList(request);
            response.TotalCount = request.TotalCount;
            return response;
        }

        [HttpPost("Remove")]
        public Response<dynamic> Remove([FromBody] ModifyRequest request)
        {
            Response<dynamic> response = new Response<dynamic>();
            response.Data = commonServices.RemoveEntity(request);
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
            response.Data = commonServices.SaveEntitys(request);
            return response;
        }

        [HttpPost("GetTables")]
        public ResponseList<EnumClass> GetTables()
        {
            ResponseList<EnumClass> response = new ResponseList<EnumClass>();
            List<EnumClass> list = new List<EnumClass>();
            Core.DataBaseServices.DataBaseServices dataBaseServices = new DataBaseServices.DataBaseServices();
            var table = dataBaseServices.GetTable(DataBaseFactory.Core_Application.FreeSql, DataBaseFactory.Core_Application.DefaultDataType);
            table.ForEach(x =>
            {
                list.Add(new EnumClass() { Name = x.TableName, Description = x.TableDescription });
            });
            response.Data = list;
            return response; 
        }
    }
}
