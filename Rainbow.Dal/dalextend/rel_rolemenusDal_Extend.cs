using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Rainbow.IDal;
using Rainbow.Models;

namespace Rainbow.Dal
{
    /// <summary>
    /// 角色和菜单行为的关联dal
    /// </summary>
    public partial class rel_rolemenusDal : Irel_rolemenusDal
    {
        /// <summary>
        /// 保存角色和菜单的关联
        /// </summary>
        /// <param name="rolemenus"></param>
        /// <param name="roleid">角色id</param>
        /// <returns></returns>
        public bool SaveRoleMenu(List<rel_rolemenus> rolemenus, string roleid)
        {
            bool flag = false;
            using (IDbConnection conn = new SqlConnection(ContextFactory.ConnectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    //先删除原来的行为关联,再添加新的关联
                    string sql = string.Format(@"DELETE FROM rel_rolemenus WHERE roleid='{0}'", roleid);
                    //新的数据的插入语句
                    string sql2 = @"INSERT INTO rel_rolemenus ([roleid],[menuid],[createdate])
                             VALUES ( @roleid,@menuid,GETDATE())";
                    conn.Execute(sql, null, trans);
                    if (rolemenus.Count > 0)
                    {
                        conn.Execute(sql2, rolemenus.ToArray(), trans);
                    }

                    trans.Commit();
                    flag = true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    flag = false;
                }
                conn.Close();
            }
            return flag;
        }
        /// <summary>
        /// 删除角色时需要将对应的菜单删除
        /// 提示是否有关联的用户
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public bool DeleteRole(string roleid)
        {
            bool flag = false;
            using (IDbConnection conn = new SqlConnection(ContextFactory.ConnectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    //先删除此角色
                    string sql = string.Format(@"DELETE FROM sys_role WHERE id='{0}'", roleid);
                    //删除此角色下的菜单
                    string sql2 = string.Format(@"DELETE FROM rel_rolemenus WHERE roleid='{0}'", roleid);
                    conn.Execute(sql, null, trans);
                    conn.Execute(sql2, null, trans);
                    trans.Commit();
                    flag = true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    flag = false;
                }
                conn.Close();
            }
            return flag;
        }
        /// <summary>
        /// 根据角色获得控制器和actions
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <returns></returns>
        public List<rel_rolemenus> GetControllerAndActions(string roleid)
        {
            using (var sqlConnection = ContextFactory.GetContext())
            {
                string sql = string.Format("SELECT menuid FROM rel_rolemenus WHERE roleid='{0}' AND menuid  LIKE '%*%' ", roleid);
                sqlConnection.Open();
                List<rel_rolemenus> rolemenus = sqlConnection.Query<rel_rolemenus>(sql).ToList();
                return rolemenus;
            }
        }
    }
}
