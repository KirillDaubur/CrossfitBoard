using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Dto
{
    public class WodResultDto
    {
        public Int32 ID { get; set; }

        public UserDto Ward { get; set; }

        public UserDto Trainer { get; set; }

        public DateTime TrainingDate { get; set; }

        public String HardnessLevel { get; set; }

        public String WardComment { get; set; }
    }
}
