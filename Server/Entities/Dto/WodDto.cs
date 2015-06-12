using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class WodDto
    {
        public Int32 ID { get; set; }

        public UserDto Ward { get; set; }

        public UserDto Trainer { get; set; }

        public RoundDto  Round { get; set; }

        public Int32 NumberOfRounds { get; set; }

        public String Status { get; set; }

        public WodResultDto WodResult { get; set; }
    }
}
