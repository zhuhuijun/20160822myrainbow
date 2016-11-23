/*******************************************************************************************
 * 此代码由T4模板自动生成
 * 对此文件的更改可能会导致不正确的行为，并且如果
 * 重新生成代码，这些更改将会丢失。
 * 日期:2016-11-04 11:49:50
 * 作者:huijun zhu<kngcbzdsn@outlook.com> 
 * 此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　                   
 * 版权所有：榆钱（北京）科技有限公司　　　　　　          
 * 此模板生成实体层:Rainbow.Dal　　　　　                 
 * *******************************************************************************************/
using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Linq;
using Rainbow.IDal;
using Rainbow.Models;


namespace Rainbow.Dal
{    
    /// <summary>
    /// sys_roleDal实现
    /// </summary>
    public partial class sys_roleDal:Isys_roleDal    
    {    
	    /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity">修改的匿名类</param>
        /// <returns></returns>
        public bool Edit(string id,dynamic entity)
        {
           using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
                int ret = db.sys_roles.Update(id,entity);
				return ret > 0;
            }
        }
        /// <summary>
        /// 按照条件修改
        /// </summary>
        /// <param name="wherelm">条件</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
		public bool  EditWhere(dynamic wherelm, dynamic data)
		{
		    using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 5);
                int ret = db.sys_roles.UpdateWhere(wherelm,data);
				return ret > 0;
            }
		}
		/// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="entity">实体sys_role</param>
        /// <returns></returns>
        public bool Insert(sys_role entity)
        {
		    try
            {
			   using (var sqlConnection= ContextFactory.GetContext())
				{
					sqlConnection.Open();
					var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
					db.sys_roles.Insert(entity);
				}
				return true;
            }
            catch (Exception)
            {

               return false;
            }

        }
		/// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
		public IEnumerable<sys_role> GetAll()
        {
			using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 5);
                var result = db.sys_roles.All();
                return result;
            }
        }

	    /// <summary>
        /// 根据主键获得数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
		public sys_role GetById(string id)
		{
		    using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
                sys_role one = db.sys_roles.Get(id);
                return one;
            }
		}
		/// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public bool Delete(string id)
        {
		    using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
                return  db.sys_roles.Delete(id);
            }
		}
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="wherelm">条件</param>
        /// <returns></returns>
        public bool DeleteWhere(dynamic wherelm)
        {
		    using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
                return  db.sys_roles.DeleteWhere(wherelm)>0;
            }
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="param"></param>
        /// <returns></returns>
		public PageDataView<sys_role> GetPageData(PageCriteria criteria, object param = null)
        {
            return PageHelper.GetPageData<sys_role>(criteria, param);
        }
		
		/// <summary>
        /// 按照条件查询
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
		public IEnumerable<sys_role> GetWhere(dynamic wherela)
		{
			using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 5);
                var result = db.sys_roles.GetWhere(wherela);
                return result;
            }
		}
        /// <summary>
        /// 按条件获得数量
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
		public int GetWhereCount(dynamic wherela)
		{
			using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 5);
                var result = db.sys_roles.GetWhereCount(wherela);
                return result;
            }
		}
		
    }
}
    
