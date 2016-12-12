using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Rainbow.Models;

namespace Rainbow.Dal
{
    public partial class sys_menuDal
    {
        /// <summary>
        /// 条件查询的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<sys_menu> GetAllWhere(string sql)
        {
            using (var sqlConnection = ContextFactory.GetContext())
            {
                sqlConnection.Open();
                return sqlConnection.Query<sys_menu>("SELECT * FROM sys_menu WHERE " + sql).ToList();
            }
        }
        /// <summary>
        /// 将菜单和行为关联的数据保存到数据库中
        /// </summary>
        /// <param name="menuid"></param>
        /// <param name="actionid"></param>
        /// <returns></returns>
        public bool SaveMenuAction(string menuid, List<string> actionid)
        {
            bool flag = false;
            using (IDbConnection conn = new SqlConnection(ContextFactory.ConnectionString))
            {
                conn.Open();
                var trans = conn.BeginTransaction();
                try
                {
                    //先删除原来的行为关联,再添加新的关联
                    string sql = string.Format(@"DELETE FROM rel_menuactions WHERE menuid='{0}'", menuid);
                    //新的数据的插入语句
                    string sql2 = @"INSERT INTO rel_menuactions ([menuid],[actionid],[isuse])
                             VALUES ( @menuid,@actionid,1)";
                    List<rel_menuactions> smalls = actionid.Select(acid => new rel_menuactions()
                    {
                        menuid = menuid,
                        actionid = acid
                    }).ToList();
                    conn.Execute(sql, null, trans);
                    if (smalls.Count > 0)
                    {
                        conn.Execute(sql2, smalls.ToArray(), trans);
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
        /// 根据角色获得菜单不包含行为
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <returns></returns>
        public List<sys_menu> GetMenuByRoleId(string roleid)
        {
            using (var sqlConnection = ContextFactory.GetContext())
            {
                string sql = string.Format("SELECT * FROM sys_menu WHERE id IN (SELECT menuid FROM rel_rolemenus WHERE roleid='{0}' AND menuid NOT LIKE '%*%') ", roleid);
                sqlConnection.Open();
                List<sys_menu> rolemenus = sqlConnection.Query<sys_menu>(sql).ToList();
                return rolemenus;
            }
        }
    }
}
