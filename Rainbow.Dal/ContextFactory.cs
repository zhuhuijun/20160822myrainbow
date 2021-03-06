﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow.Dal
{
    /// <summary>
    /// 数据槽的上下文
    /// </summary>
    public partial class ContextFactory
    {
        /// <summary>
        /// 数据库的连接
        /// </summary>
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Dappertest"].ConnectionString;
        /// <summary>
        /// 获得连接
        /// </summary>
        /// <returns></returns>
        public static DbBase GetContext1()
        {
            DbBase db = CallContext.GetData("OAContext") as DbBase;
            if (db == null)
            {
                db = new DbBase(ConnectionString);
                CallContext.SetData("OAContext", db);
            }
            return db;
            //SqlConnection context = CallContext.GetData("OAContext") as SqlConnection;
            //if (context == null)
            //{
            //    context = new SqlConnection(ConnectionString);
            //    CallContext.SetData("OAContext", context);
            //}
            ////SqlConnection context = new SqlConnection(ConnectionString);
            //return context;
        }
        /// <summary>
        /// 获得连接的方法
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetContext()
        {
            SqlConnection context = new SqlConnection(ConnectionString);
            return context;
        }
    }
}
