using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateMonitor.Models
{
    public class SensorReading
    {
        public long Id { get; set; }
        public long SensorId { get; set; }
        public double Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
