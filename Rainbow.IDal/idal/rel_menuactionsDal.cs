/*******************************************************************************************
 * 此代码由T4模板自动生成
 * 对此文件的更改可能会导致不正确的行为，并且如果
 * 重新生成代码，这些更改将会丢失。
 * 日期:2016-09-24 17:26:29
 * 作者:huijun zhu<kngcbzdsn@outlook.com> 
 * 此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　                   
 * 版权所有：榆钱（北京）科技有限公司　　　　　　          
 * 此模板生成实体层:Rainbow.IDal　　　　　                 
 * *******************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Rainbow.Models;


namespace Rainbow.IDal
{    
    /// <summary>
    /// rel_menuactionsDal实现
    /// </summary>
    public partial interface Irel_menuactionsDal    
    {    
	    /// <summary>
        /// 更新数据实体到上下文
        /// </summary>
        bool Edit(string id,dynamic o);
        /// <summary>
        /// 根据条件修改
        /// </summary>
        /// <param name="wherelm">条件</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        bool EditWhere(dynamic wherelm, dynamic data);

        /// <summary>
        /// 添加新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Insert(rel_menuactions entity);
        /// <summary>
        /// 获得所有数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<rel_menuactions> GetAll();
        /// <summary>
        /// 根据主键获得数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        rel_menuactions GetById(string id);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        bool Delete(string id);
        /// <summary>
        /// 按照条件删除
        /// </summary>
        /// <param name="wherelm"></param>
        /// <returns></returns>
        bool DeleteWhere(dynamic wherelm);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        PageDataView<rel_menuactions> GetPageData(PageCriteria criteria, object param = null);
        /// <summary>
        /// 匿名条件查询
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
        IEnumerable<rel_menuactions> GetWhere(dynamic wherela);
        /// <summary>
        /// 按照条件获得数量
        /// </summary>
        /// <param name="wherela"></param>
        /// <returns></returns>
        int GetWhereCount(dynamic wherela);
    }
}
    
