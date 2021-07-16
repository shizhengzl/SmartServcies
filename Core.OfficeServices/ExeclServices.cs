using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Core.OfficeServices
{
    public static class ExeclServices
    {
        /// <summary>
        /// execl 获取 DataSet
        /// </summary>
        /// <param name="path">文件路劲</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataTable(string path)
        {
            DataSet response = new DataSet();
            try
            {
                Workbook workbook = new Workbook(path);
                for (int i = 0; i < workbook.Worksheets.Count; i++)
                {
                    var sheet = workbook.Worksheets[i];
                    Cells cells = sheet.Cells;
                    if (cells.MaxDataRow > 0) 
                    {
                        DataTable dt = cells.ExportDataTable(0, 0, cells.MaxDataRow + 1, cells.MaxColumn + 1);
                        dt.TableName = sheet.Name;
                        response.Tables.Add(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
