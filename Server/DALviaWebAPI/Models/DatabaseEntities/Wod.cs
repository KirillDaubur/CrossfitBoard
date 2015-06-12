using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models.DatabaseEntities
{
    public class Wod
    {
        public Int32 ID { get; set; }

        public Int32 WardID { get; set; }

        public Int32 TrainerID { get; set; }

        public Int32 RoundID { get; set; }

        public Int32 NumberOfRounds { get; set; }

        public String Status { get; set; }

        public Int32 WodResultID { get; set; }
    }
}