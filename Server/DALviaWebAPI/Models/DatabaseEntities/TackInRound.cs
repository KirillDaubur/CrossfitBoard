using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models.DatabaseEntities
{
    public class TackInRound
    {
        public Int32 ID { get; set; }

        public Int32 TackID { get; set; }

        public Int32 RoundID { get; set; }

    }
}