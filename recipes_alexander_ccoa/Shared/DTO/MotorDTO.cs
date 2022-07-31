using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipes_alexander_ccoa.Shared.DTO
{
    public class MotorDTO
    {
        public int id { get; set; }
        public string? noMotor { get; set; }

        public DateTime start { get; set; }
        public DateTime end { get; set; }   
        public byte status { get; set; }
    }
    
    public class MotorOEEDTO
    {
        public string noMotor { get; set; }
        public List<MotorDetailOEEDTO> details { get; set; }
    }

    public class MotorDetailOEEDTO
    {
        public byte status { get; set; }
        public TimeSpan Time { get; set; }

        public decimal Percentage { get; set; }

    }

    public class MotorReportDTO
    {
        public IEnumerable<MotorDetailOEEDTO> oee { get; set; }
        public IEnumerable<MotorDTO> history { get; set; }
    }
}
