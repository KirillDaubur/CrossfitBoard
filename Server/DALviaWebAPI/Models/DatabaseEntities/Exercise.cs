using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models.DatabaseEntities
{
    public class Exercise
    {
        public Int32 ID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String ImageLink { get; set; }
    }
}