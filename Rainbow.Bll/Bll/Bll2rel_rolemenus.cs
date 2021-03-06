/*******************************************************************************************
 * 此代码由T4模板自动生成
 * 对此文件的更改可能会导致不正确的行为，并且如果
 * 重新生成代码，这些更改将会丢失。
 * 日期:2016-12-12 13:40:21
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
    /// Bll2rel_rolemenus业务逻辑
    /// </summary>
    public partial class Bll2rel_rolemenus   
    {    
	    /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">修改的匿名类</param>
        /// <returns></returns>
        public static bool Edit(string id,dynamic entity)
        {
          return DalFactory.Createrel_rolemenus().Edit(id,entity);
        }
        /// <summary>
        /// 分页数据
        /// </summary>
		/// <param name="conwhere">条件</param>
        /// <param name="sortpara">排序字段</param>
        /// <param name="currentpage">当前页</param>
        /// <param name="pagesize">每页的数量默认是15条</param>
		public static PageDataView<rel_rolemenus> GetPageData(string conwhere,string sortpara,int currentpage,int pagesize=15)
        {
		   string wheresql= SearchHelper.GetSearchParaSql(conwhere);
            PageCriteria criteria = new PageCriteria()
            {
                TableName = "rel_rolemenus",
                PageSize = pagesize,
                CurrentPage = currentpage,
				Sort = sortpara,
				Condition = wheresql
            };
            object param = null;
            return DalFactory.Createrel_rolemenus().GetPageData(criteria, param);
        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
		public static  bool Insert(rel_rolemenus entity)
		{
			return DalFactory.Createrel_rolemenus().Insert(entity);
		}
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public static bool Delete(string id)
		{
			return DalFactory.Createrel_rolemenus().Delete(id);
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
                bool ret = DalFactory.Createrel_rolemenus().DeleteWhere(wherela);
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
		public static rel_rolemenus GetById(string id)
		{
			return DalFactory.Createrel_rolemenus().GetById(id);
		}
        /// <summary>
        /// 按照主键修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
		public static bool Edit(string id,rel_rolemenus entity)
		{
			return DalFactory.Createrel_rolemenus().Edit(id,entity);
		}
        /// <summary>
        /// 获得全部数据
        /// </summary>
        /// <returns></returns>
        public static List<rel_rolemenus> GetAll()
        {
            return DalFactory.Createrel_rolemenus().GetAll().ToList();
        }
		
        /// <summary>
        /// 按照条件获得全部数据
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
        public static List<rel_rolemenus> GetWhere(dynamic wherela)
        {
            var tt =  DalFactory.Createrel_rolemenus().GetWhere(wherela);
			return tt;
        }
        /// <summary>
        /// 按条件获得数量
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
		public static int GetWhereCount(dynamic wherela)
		{
			return DalFactory.Createrel_rolemenus().GetWhereCount(wherela);
		}
		
    }
}
    
