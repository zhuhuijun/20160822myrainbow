/*******************************************************************************************
 * 此代码由T4模板自动生成
 * 对此文件的更改可能会导致不正确的行为，并且如果
 * 重新生成代码，这些更改将会丢失。
 * 日期:2016-11-21 14:36:54
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
    /// Bll2rel_menuactions业务逻辑
    /// </summary>
    public partial class Bll2rel_menuactions   
    {    
	    /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">修改的匿名类</param>
        /// <returns></returns>
        public static bool Edit(string id,dynamic entity)
        {
          return DalFactory.Createrel_menuactions().Edit(id,entity);
        }
        /// <summary>
        /// 分页数据
        /// </summary>
		/// <param name="conwhere">条件</param>
        /// <param name="sortpara">排序字段</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">每页的数量默认是15条</param>
		public static PageDataView<rel_menuactions> GetPageData(string conwhere,string sortpara,int currentpage,int pagesize=15)
        {
		   string wheresql= SearchHelper.GetSearchParaSql(conwhere);
            PageCriteria criteria = new PageCriteria()
            {
                TableName = "rel_menuactions",
                PageSize = pagesize,
                CurrentPage = currentpage,
				Sort = sortpara,
				Condition = wheresql
            };
            object param = null;
            return DalFactory.Createrel_menuactions().GetPageData(criteria, param);
        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
		public static  bool Insert(rel_menuactions entity)
		{
			return DalFactory.Createrel_menuactions().Insert(entity);
		}
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public static bool Delete(string id)
		{
			return DalFactory.Createrel_menuactions().Delete(id);
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
                bool ret = DalFactory.Createrel_menuactions().DeleteWhere(wherela);
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
		public static rel_menuactions GetById(string id)
		{
			return DalFactory.Createrel_menuactions().GetById(id);
		}
        /// <summary>
        /// 按照主键修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
		public static bool Edit(string id,rel_menuactions entity)
		{
			return DalFactory.Createrel_menuactions().Edit(id,entity);
		}
        /// <summary>
        /// 获得全部数据
        /// </summary>
        /// <returns></returns>
        public static List<rel_menuactions> GetAll()
        {
            return DalFactory.Createrel_menuactions().GetAll().ToList();
        }
		
        /// <summary>
        /// 按照条件获得全部数据
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
        public static List<rel_menuactions> GetWhere(dynamic wherela)
        {
            var tt =  DalFactory.Createrel_menuactions().GetWhere(wherela);
			return tt;
        }
        /// <summary>
        /// 按条件获得数量
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
		public static int GetWhereCount(dynamic wherela)
		{
			return DalFactory.Createrel_menuactions().GetWhereCount(wherela);
		}
		
    }
}
    
