using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Rainbow.IDal;
using Rainbow.Models;

namespace Rainbow.Dal
{
    public partial class bas_userDal : Ibas_userDal
    {
        public void getById1(string id)
        {
            using (var sqlConnection =ContextFactory.GetContext())
            {
                sqlConnection.Open();
                var db = MyDatabase.Init(sqlConnection, commandTimeout: 2);
                var one = db.bas_users.All();
                //db.bas_users.UpdateWhere(new {UserName = "Dapper"}, new {UserPwd = "vb"});

            }

        }
    }
}
