using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models.DatabaseEntities
{
    public class TrainerAndWard
    {
        public Int32 ID { get; set; }

        public Int32 TrainerID { get; set; }

        public Int32 WardID { get; set; }
    }
}