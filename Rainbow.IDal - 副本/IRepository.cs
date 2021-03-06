﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainbow.Models;

namespace Rainbow.IDal
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class, new()
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
        bool Insert(TEntity entity);
        /// <summary>
        /// 获得所有数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// 根据主键获得数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        TEntity GetById(string id);
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
        PageDataView<TEntity> GetPageData(PageCriteria criteria, object param = null);
        ///// <summary>
        ///// 匿名条件查询
        ///// </summary>
        ///// <param name="wherela"></param>
        ///// <returns></returns>
        //IEnumerable<TEntity> GetWhere(dynamic wherela);
        ///// <summary>
        ///// 按照条件获得数量
        ///// </summary>
        ///// <param name="wherela"></param>
        ///// <returns></returns>
        //int GetWhereCount111(string id, dynamic o);
    }
}
