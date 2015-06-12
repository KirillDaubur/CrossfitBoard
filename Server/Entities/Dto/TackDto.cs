using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class TackDto
    {
        public Int32 ID { get; set; }

        public ExerciseDto Exercise { get; set; }

        public Int32 NumberOfIterations { get; set; }
    }
}
