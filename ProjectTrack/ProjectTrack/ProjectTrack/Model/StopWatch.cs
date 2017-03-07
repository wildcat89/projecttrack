using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrack.Model
{
    public class StopWatch
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Time { get; set; }
    }
}
