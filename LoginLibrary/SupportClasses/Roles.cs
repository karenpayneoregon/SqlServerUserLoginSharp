using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginLibrary.SupportClasses
{
    public class User
    {
        public string Name { get; set; }
        public RoleTypes RoleType { get; set; }
    }
    public class Roles
    {
        public int Id { get; set; }
        [EnumDataType(typeof(RoleTypes))]
        public RoleTypes RoleType { get; set; }

        public string Description { get; set; }

    }

    public enum RoleTypes
    {
        User = 0,
        Admin = 1
        
    }

}
