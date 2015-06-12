using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class RoundDto
    {
        public Int32 ID { get; set; }

        public List<TackDto> Tacks { get; set; }

        public TimeSpan TimeForRound { get; set; }

        public TimeSpan RestAfterRound { get; set; }
    }
}
