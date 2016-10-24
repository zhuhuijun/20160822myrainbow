using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rainbow.UIs
{
    public class Department
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public Guid? ParentID { get; set; }
    }

    public class DeptHelper
    {
        public static List<Department> getDeptList()
        {
            var dept1 = new Department() { ID = Guid.NewGuid(), Name = "think8848", Director = "John" };
            var dept2 = new Department() { ID = Guid.NewGuid(), Name = "user1", Director = "John", ParentID = dept1.ID };
            var dept3 = new Department() { ID = Guid.NewGuid(), Name = "user2", Director = "John", ParentID = dept1.ID };
            var dept4 = new Department() { ID = Guid.NewGuid(), Name = "user3", Director = "John", ParentID = dept1.ID };
            var dept5 = new Department() { ID = Guid.NewGuid(), Name = "user4", Director = "John", ParentID = dept2.ID };
            var dept6 = new Department() { ID = Guid.NewGuid(), Name = "user5", Director = "John", ParentID = dept2.ID };
            var dept7 = new Department() { ID = Guid.NewGuid(), Name = "user6", Director = "John", ParentID = dept6.ID };
            var dept8 = new Department() { ID = Guid.NewGuid(), Name = "user7", Director = "John", ParentID = dept7.ID };
            var dept9 = new Department() { ID = Guid.NewGuid(), Name = "user8", Director = "John", ParentID = dept3.ID };
            var dept10 = new Department() { ID = Guid.NewGuid(), Name = "user9", Director = "John", ParentID = dept3.ID };
            var dept11 = new Department() { ID = Guid.NewGuid(), Name = "user10", Director = "John", ParentID = dept3.ID };
            var dept12 = new Department() { ID = Guid.NewGuid(), Name = "user11", Director = "John", ParentID = dept4.ID };
            var dept13 = new Department() { ID = Guid.NewGuid(), Name = "user12", Director = "John", ParentID = dept8.ID };
            var dept14 = new Department() { ID = Guid.NewGuid(), Name = "user13", Director = "John", ParentID = dept3.ID };
            var dept15 = new Department() { ID = Guid.NewGuid(), Name = "user14", Director = "John", ParentID = dept4.ID };
            var dept16 = new Department() { ID = Guid.NewGuid(), Name = "user15", Director = "John", ParentID = dept5.ID };
            var dept17 = new Department() { ID = Guid.NewGuid(), Name = "user16", Director = "John", ParentID = dept6.ID };

            var depts = new List<Department>()
            {
                dept1,dept2,dept3,dept4,dept5,dept6,dept7,dept8,dept9,dept10,dept11,dept12,dept13,dept14,dept15,dept16,dept17
            };
            return depts;
        } 
    }
}