using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models.DatabaseEntities
{
    public class User
    {
        public Int32 ID { get; set; }

        public Int32 RoleID { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Email { get; set; }

        public Int32 Age { get; set; }

        public String Sex { get; set; }

        public String ImageUrl { get; set; }
    }
}