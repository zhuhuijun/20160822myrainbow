/*******************************************************************************************
 * 此代码由T4模板自动生成
 * 对此文件的更改可能会导致不正确的行为，并且如果
 * 重新生成代码，这些更改将会丢失。
 * 日期:2016-09-07 10:18:31
 * 作者:huijun zhu<kngcbzdsn@outlook.com> 
 * 此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　                   
 * 版权所有：榆钱（北京）科技有限公司　　　　　　          
 * 此模板生成实体层:Rainbow.Bll　　　　　                 
 * *******************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Rainbow.IDal;
using Rainbow.Models;

namespace Rainbow.Bll
{    
    /// <summary>
    /// Bll2bas_user业务逻辑
    /// </summary>
    public partial class Bll2bas_user   
    {    
	    /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">修改的匿名类</param>
        /// <returns></returns>
        public bool Edit(string id,dynamic entity)
        {
          return DalFactory.Createbas_user().Edit(id,entity);
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="sortpara"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
		public static PageDataView<bas_user> GetPageData(string sortpara,int currentpage,int pagesize=15)
        {
            PageCriteria criteria = new PageCriteria()
            {
                TableName = "bas_user",
                PageSize = pagesize,
                CurrentPage = currentpage,
				Sort = sortpara
            };
            object param = null;
            return DalFactory.Createbas_user().GetPageData(criteria, param);
        }
    }
}
    