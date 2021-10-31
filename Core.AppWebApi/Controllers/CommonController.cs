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
                var columns = GetSQLConfigServices.GetColumn(request.TableName);
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
                var columns = GetSQLConfigServices.GetColumn(request.TableName);
                List<ShowColumns> showColumns = new List<ShowColumns>();
                columns.ForEach(x =>
                {
                    ShowColumns showcolumn = new ShowColumns()
                    {
                        ColumnName = x.ColumnName,
                        ColumnDescription = x.ColumnDescription,
                        TableName = x.TableName,
                        DataBaseName = x.DataBaseName,
                        ColumnWidth = 150.ToStringExtension(),
                        IsShow = !hiddencolumns.Any(p => p.ToUpper() == x.ColumnName.ToUpper()),
                        CompanysId = session.User.CompanysId,
                        CsharpType = x.SQLType.SqlTypeToCSharpType(),
                        Postion = ShowPostion.Center,

                        //SQLType = x.SQLType,
                        //DefaultValue = x.DefaultValue,
                        //IsPrimarykey = x.IsPrimarykey,
                        //IsRequire = x.IsRequire,
                        //Scale = x.Scale,
                        //IsIdentity = x.IsIdentity,
                        //MaxLength = x.MaxLength

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
        [HttpPost("GetList")]
        [Authorize]
        public Response<string> GetList([FromBody] BaseRequest<string> request)
        {
            Response<string> response = new Response<string>();
            response.Data = commonServices.GetList(request);
            return response;
        }



        [HttpPost("Modify")]
        public Response<dynamic> Modify([FromBody] ModifyRequest request)
        {
            Response<dynamic> response = new Response<dynamic>(); 
            response.Data = commonServices.ModifyEntitys(request);
            return response; 
        }

    }
}
