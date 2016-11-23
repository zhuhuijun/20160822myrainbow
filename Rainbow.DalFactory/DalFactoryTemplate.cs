using System;
using System.Collections.Generic;
using Rainbow.Dal;
 
/*******************************************************************************************
 *  以下是代码工具生成，请不要做任何添加
 *  否则代码会被覆盖
 *  描    述： 数据处理DalFactory层     					
 *  创 建 者： zhuhj
 *  创建时间： 2016-01-13
 *  来    源：
 *  修改记录：
 *  此模板生成实体层:Rainbow.DalFactory
 * ****************************************************************************************/
 namespace Rainbow.IDal
{
	public class DalFactory
	{
	  		/// <summary>
		/// Isys_menuDal的工厂实现
		/// </summary>
		public  static Isys_menuDal Createsys_menu()
		{
			Isys_menuDal tmp=new sys_menuDal();
			return tmp;
		}
			/// <summary>
		/// Isys_roleDal的工厂实现
		/// </summary>
		public  static Isys_roleDal Createsys_role()
		{
			Isys_roleDal tmp=new sys_roleDal();
			return tmp;
		}
			/// <summary>
		/// Isys_actionDal的工厂实现
		/// </summary>
		public  static Isys_actionDal Createsys_action()
		{
			Isys_actionDal tmp=new sys_actionDal();
			return tmp;
		}
			/// <summary>
		/// Irel_menuactionsDal的工厂实现
		/// </summary>
		public  static Irel_menuactionsDal Createrel_menuactions()
		{
			Irel_menuactionsDal tmp=new rel_menuactionsDal();
			return tmp;
		}
			/// <summary>
		/// Irel_rolemenusDal的工厂实现
		/// </summary>
		public  static Irel_rolemenusDal Createrel_rolemenus()
		{
			Irel_rolemenusDal tmp=new rel_rolemenusDal();
			return tmp;
		}
			/// <summary>
		/// Ibas_userDal的工厂实现
		/// </summary>
		public  static Ibas_userDal Createbas_user()
		{
			Ibas_userDal tmp=new bas_userDal();
			return tmp;
		}
	
	}
}