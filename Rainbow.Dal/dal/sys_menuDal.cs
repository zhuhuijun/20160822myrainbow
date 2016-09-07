/*******************************************************************************************
 * 此代码由T4模板自动生成
 * 对此文件的更改可能会导致不正确的行为，并且如果
 * 重新生成代码，这些更改将会丢失。
 * 日期:2016-09-01 18:18:16
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
    /// sys_menuDal实现
    /// </summary>
    public partial class sys_menuDal:Isys_menuDal    
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
                int ret = db.sys_menus.Update(id,entity);
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
                int ret = db.sys_menus.UpdateWhere(wherelm,data);
				return ret > 0;
            }
		}
		/// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="entity">实体sys_menu</param>
        /// <returns></returns>
        public bool Insert(sys_menu entity)
        {
		    try
            {
			   using (var sqlConnection= ContextFactory.GetContext())
				{
					sqlConnection.Open();
					var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
					db.sys_menus.Insert(entity);
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
		public IEnumerable<sys_menu> GetAll()
        {
			using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 5);
                var result = db.sys_menus.All();
                return result;
            }
        }
	    /// <summary>
        /// 根据主键获得数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
		public sys_menu GetById(string id)
		{
		    using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
                sys_menu one = db.sys_menus.Get(id);
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
                return  db.sys_menus.Delete(id);
            }
		}
		/// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public bool DeleteWhere(dynamic wherelm)
        {
		    using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
                return  db.sys_menus.DeleteWhere(wherelm)>0;
            }
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="param"></param>
        /// <returns></returns>
		public PageDataView<sys_menu> GetPageData(PageCriteria criteria, object param = null)
        {
            return PageHelper.GetPageData<sys_menu>(criteria, param);
        }
    }
}
    
