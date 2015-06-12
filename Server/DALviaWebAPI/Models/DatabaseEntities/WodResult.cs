using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models.DatabaseEntities
{
    public class WodResult
    {
        public Int32 ID { get; set; }

        public Int32 WardID { get; set; }

        public Int32 TrainerID { get; set; }

        public Int32 WodID { get; set; }

        public DateTime TrainingDate { get; set; }

        public String HardnessLevel { get; set; }

        public String WardComment { get; set; }
    }
}