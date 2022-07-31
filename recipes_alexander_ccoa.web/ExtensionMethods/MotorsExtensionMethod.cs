using recipes_alexander_ccoa.Core.Models;
using recipes_alexander_ccoa.Shared.DTO;
using recipes_alexander_ccoa.Shared.ExtensionMethods;

namespace recipes_alexander_ccoa.Server.ExtensionMethods
{
    public static class MotorsExtensionMethod
    {
        public static MotorReportDTO GetReport(this IEnumerable<Motores> Data)
        {
            var history = GetHistory(Data);

            return new MotorReportDTO()
            {
                history = history,
                oee = GetOEE(history)
            };

        }

        public static IEnumerable<MotorDTO> GetHistory(this IEnumerable<Motores> Data)
        {
            int lenght = Data.Count();
            List<MotorDTO> Motores = new List<MotorDTO>();

            for (int i = 0; i<lenght-1; i++)
            {
                var motor = Data.Skip(i).Take(2).ToArray();


                if (motor != null)
                    Motores.Add(new MotorDTO()
                    {
                        start = (DateTime)motor[0].Fecha,
                        end = motor.Length == 1 ? DateTime.Now : (DateTime)motor[1].Fecha,
                        id = motor[0].Id,
                        noMotor = motor[0].NoMotor,
                        status = motor[0].Statu
                    }); ;
            }

            return Motores;
        }

        public static IEnumerable<MotorOEEDTO> GetOEE(this IEnumerable<Motores> Data) =>
            Data.GetOEE();

        public static IEnumerable<MotorDetailOEEDTO> GetOEE(this IEnumerable<MotorDTO> Data)
        {

            var totalTime = Data.Select(x => (x.end.Subtract(x.start)).TotalSeconds).ToList();
            var tt = totalTime.Sum();
            Console.WriteLine(totalTime);
            return Data
                 .GroupBy(x => x.status)
                 .Select(x => new MotorDetailOEEDTO()
                 {
                     status=x.Key,
                     Time = x.Where(y => y.status==x.Key).Select(x => x.end-x.start).FirstOrDefault(),
                     Percentage = x.Where(y => y.status==x.Key)
                    .Select(x => (decimal)(x.end-x.start).TotalSeconds.GetPercentage(tt))
                    .Sum(),
                 }).ToList();
        }

    }
}
