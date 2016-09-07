using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Rainbow.Models;

namespace Rainbow.Dal
{
    /// <summary>
    /// 分页的辅助方法
    /// </summary>
    public class PageHelper
    {
        public static PageDataView<T> GetPageData<T>(PageCriteria criteria, object param = null)
        {
            using (var conn = ContextFactory.GetContext())
            {
                var p = new DynamicParameters();
                string proName = "ProcGetPageData";
                p.Add("TableName", criteria.TableName);
                p.Add("PrimaryKey", criteria.PrimaryKey);
                p.Add("Fields", criteria.Fields);
                p.Add("Condition", criteria.Condition);
                p.Add("CurrentPage", criteria.CurrentPage);
                p.Add("PageSize", criteria.PageSize);
                p.Add("Sort", criteria.Sort);
                p.Add("RecordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                conn.Open();
                var pageData = new PageDataView<T>();
                pageData.Items = conn.Query<T>(proName, p, commandType: CommandType.StoredProcedure).ToList();
                conn.Close();
                pageData.TotalNum = p.Get<int>("RecordCount");
                pageData.TotalPageCount = Convert.ToInt32(Math.Ceiling(pageData.TotalNum * 1.0 / criteria.PageSize));
                pageData.CurrentPage = criteria.CurrentPage > pageData.TotalPageCount ? pageData.TotalPageCount : criteria.CurrentPage;
                return pageData;
            }
        }
    }
}
