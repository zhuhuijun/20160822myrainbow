using System;
using System.Collections.Generic;
using Dapper;
using Rainbow.Models;
 
/*******************************************************************************************
 *  以下是代码工具生成，请不要做任何添加
 *  否则代码会被覆盖
 *  描    述： 数据处理仓库     					
 *  创 建 者： zhuhj
 *  创建时间： 2016-01-13
 *  来    源：
 *  修改记录：
 * ****************************************************************************************/
 namespace Rainbow.Dal
{
	public partial class MyDatabase : Database<MyDatabase>
     {
  	 /// <summary>
     /// 定义bas_user
     /// </summary>
	 public Table<bas_user> bas_users { get; set; }
	 /// <summary>
     /// 定义sys_menu
     /// </summary>
	 public Table<sys_menu> sys_menus { get; set; }
	 /// <summary>
     /// 定义sys_role
     /// </summary>
	 public Table<sys_role> sys_roles { get; set; }
	}
   }