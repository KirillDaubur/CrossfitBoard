using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models.DatabaseEntities
{
    public class Round
    {
        public Int32 ID { get; set; }

        public TimeSpan TimeForRound { get; set; }

        public TimeSpan RestAfterRound { get; set; }
    }
}