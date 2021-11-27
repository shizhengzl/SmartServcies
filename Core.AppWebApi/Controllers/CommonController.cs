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
using Core.AppSystemServices.Services;
using FreeSql.Internal.Model;
using Core.FreeSqlServices;

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
                        Postion = "center",
                        Sort = sort

                    };
                    sort++;
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
            dynamic model = request.Model;
            if (request.Model.GetDynamicProperty("Id").IsNull())
            {
                model.createUserId = this.session.User.Id;
                model.createTime = DateTime.UtcNow;
                model.companysId = this.session.User.CompanysId;
            }
            else 
            { 
                model.modifyUserId = this.session.User.Id;
                model.modifyTime = DateTime.UtcNow; 
            }
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
            table.ForEach(x => {
                list.Add(new EnumClass() { Name = x.TableName, Description = x.TableDescription}) ;
            });
            response.Data = list;
            return response;

        }
    }
}
