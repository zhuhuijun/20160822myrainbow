/*******************************************************************************************
 * 此代码由T4模板自动生成
 * 对此文件的更改可能会导致不正确的行为，并且如果
 * 重新生成代码，这些更改将会丢失。
 * 日期:2016-11-04 11:49:50
 * 作者:huijun zhu<kngcbzdsn@outlook.com> 
 * 此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　                   
 * 版权所有：榆钱（北京）科技有限公司　　　　　　          
 * 此模板生成实体层:Rainbow.Models　　　　　                 
 * *******************************************************************************************/
using System;
using System.Collections.Generic;
namespace Rainbow.Models
{    
    /// <summary>
    /// 实体-bas_user 
    /// </summary>
    public partial class bas_user    
    {    
        public string id { get; set; }
          public string username { get; set; }
          public string userpwd { get; set; }
          public string realname { get; set; }
          public string emailaddress { get; set; }
          public string phonenum { get; set; }
          public DateTime createdate { get; set; }
          public string roleid { get; set; }
    }
}
    
