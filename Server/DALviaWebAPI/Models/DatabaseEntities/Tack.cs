﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.Models.DatabaseEntities
{
    public class Tack
    {
        public Int32 ID { get; set; }

        public Int32 ExerciseID { get; set; }

        public Int32 NumberOfIterations { get; set; }
    }
}