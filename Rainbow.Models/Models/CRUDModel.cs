using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainbow.Resources;

namespace Rainbow.Models
{
    /// <summary>
    /// 操作的结果
    /// </summary>
    public class CRUDModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CRUDModel()
        {
            this.status = CommonResource.ParaErrorFlag;
            this.msg = CommonResource.ParaErrorDesc;
        }
        /// <summary>
        /// 关联数据的判断
        /// </summary>
        /// <param name="crud"></param>
        public CRUDModel(CRUD crud)
        {
            switch (crud)
            {
                case CRUD.HAVELINK:
                    this.status = CommonResource.MenuLinkFlag;
                    this.msg = CommonResource.MenuLink;
                    break;
            }

        }
        public string status { get; set; }
        public string msg { get; set; }
    }

    /// <summary>
    /// crud结果的帮助类
    /// </summary>
    public class CRUDModelHelper
    {
        /// <summary>
        /// 返回的结果类型
        /// </summary>
        /// <returns></returns>
        public static CRUDModel GetRes(CRUD crud, bool res)
        {
            CRUDModel cm = new CRUDModel();
            switch (crud)
            {
                case CRUD.ADD:
                    cm.msg = res ? CommonResource.AddSuccess : CommonResource.AddError;
                    break;
                case CRUD.DELETE:
                    cm.msg = res ? CommonResource.DelSuccess : CommonResource.DelError;
                    break;
                case CRUD.EDIT:
                    cm.msg = res ? CommonResource.EditSuccess : CommonResource.EditError;
                    break;
            }
            cm.status = res ? CommonResource.OptionSuccess : CommonResource.ServerError;
            return cm;
        }
    }

    /// <summary>
    /// crud的操作符
    /// </summary>
    public enum CRUD
    {
        ADD,
        EDIT,
        DELETE,
        HAVELINK
    }

}