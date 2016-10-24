/*******************************************************************************************
 * 此代码由T4模板自动生成
 * 对此文件的更改可能会导致不正确的行为，并且如果
 * 重新生成代码，这些更改将会丢失。
 * 日期:2016-09-24 17:26:30
 * 作者:huijun zhu<kngcbzdsn@outlook.com> 
 * 此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　                   
 * 版权所有：榆钱（北京）科技有限公司　　　　　　          
 * 此模板生成实体层:Rainbow.Bll　　　　　                 
 * *******************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Rainbow.Commons;
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
        public static bool Edit(string id,dynamic entity)
        {
          return DalFactory.Createbas_user().Edit(id,entity);
        }
        /// <summary>
        /// 分页数据
        /// </summary>
		/// <param name="conwhere">条件</param>
        /// <param name="sortpara">排序字段</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">每页的数量默认是15条</param>
		public static PageDataView<bas_user> GetPageData(string conwhere,string sortpara,int currentpage,int pagesize=15)
        {
		   string wheresql= SearchHelper.GetSearchParaSql(conwhere);
            PageCriteria criteria = new PageCriteria()
            {
                TableName = "bas_user",
                PageSize = pagesize,
                CurrentPage = currentpage,
				Sort = sortpara,
				Condition = wheresql
            };
            object param = null;
            return DalFactory.Createbas_user().GetPageData(criteria, param);
        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
		public static  bool Insert(bas_user entity)
		{
			return DalFactory.Createbas_user().Insert(entity);
		}
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public static bool Delete(string id)
		{
			return DalFactory.Createbas_user().Delete(id);
		}
		/// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="wherelm">条件</param>
        /// <returns></returns>
		public static bool DeleteWhere(dynamic wherela)
		{
		  try
            {
                bool ret = DalFactory.Createbas_user().DeleteWhere(wherela);
                return ret;
            }
            catch (Exception ex)
            {
                return false;
            }
		}
        /// <summary>
        /// 按照主键查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public static bas_user GetById(string id)
		{
			return DalFactory.Createbas_user().GetById(id);
		}
        /// <summary>
        /// 按照主键修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
		public static bool Edit(string id,bas_user entity)
		{
			return DalFactory.Createbas_user().Edit(id,entity);
		}
        /// <summary>
        /// 获得全部数据
        /// </summary>
        /// <returns></returns>
        public static List<bas_user> GetAll()
        {
            return DalFactory.Createbas_user().GetAll().ToList();
        }
		
        /// <summary>
        /// 按照条件获得全部数据
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
        public static List<bas_user> GetWhere(dynamic wherela)
        {
            return DalFactory.Createbas_user().GetWhere(wherela).ToList();
        }
        /// <summary>
        /// 按条件获得数量
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
		public static int GetWhereCount(dynamic wherela)
		{
			return DalFactory.Createbas_user().GetWhereCount(wherela);
		}
		
    }
}
    
