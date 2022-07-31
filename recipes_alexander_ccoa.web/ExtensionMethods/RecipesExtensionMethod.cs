using Newtonsoft.Json;
using recipes_alexander_ccoa.Core.Models;
using recipes_alexander_ccoa.Shared.DTO;
using System.Runtime.Serialization.Formatters.Binary;

namespace recipes_alexander_ccoa.Server.ExtensionMethods
{
    public static class RecipesExtensionMethod
    {
        public static IEnumerable<RecipesDTO> GetResume(this IEnumerable<Recetas> Data)
        {
            return Data.Select(x => new RecipesDTO()
            {
                id = x.Id,
                fecha   = x.Fecha,
                mezcla = x.Mezcla,
                items = GenerateItems(x)
            }).ToList();
        }

        public static IEnumerable<RecipeReportDTO> GetReport(this IEnumerable<Recetas> Data, DateTime minDate, DateTime maxDate)
        {
            var returnData = new List<RecipeReportDTO>();
            var diffDays= (maxDate - minDate).Days;


            DateTime lastCountFrecuency = new DateTime();
            DateTime countFrecuency = minDate;

            while (countFrecuency <= maxDate)
            {
                
                var infoInRange = Data
                    .Where(x => x.Fecha>= lastCountFrecuency && x.Fecha < countFrecuency)
                    .Select(x => new RecipeReportDTO()
                    {
                        date = DeepCopy(countFrecuency),
                        Total = (decimal)(x.Cant1 + x.Cant2 +x.Cant3 +x.Cant4 +x.Cant5 +x.Cant6 +x.Cant7 +x.Cant8)
                    }).FirstOrDefault();

                returnData.Add(infoInRange != null ? infoInRange : new RecipeReportDTO()
                {
                    date = DeepCopy(countFrecuency),
                    Total=0
                });

                lastCountFrecuency = countFrecuency;
                if (diffDays < 45) countFrecuency= countFrecuency.AddDays(1);
                else if (diffDays >=45 && diffDays < 500) countFrecuency=countFrecuency.AddMonths(1);
                else countFrecuency= countFrecuency.AddYears(1);
            }

            return returnData;
             
        }

        static private T DeepCopy<T>(T obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        private static IEnumerable<RecipeItemsDTO> GenerateItems(Recetas Data)
        {
            return new List<RecipeItemsDTO>()
            {
                new RecipeItemsDTO(Data.InsT1,(decimal)Data.Cant1),
                new RecipeItemsDTO(Data.InsT2,(decimal)Data.Cant2),
                new RecipeItemsDTO(Data.InsT3,(decimal)Data.Cant3),
                new RecipeItemsDTO(Data.InsT4,(decimal)Data.Cant4),
                new RecipeItemsDTO(Data.InsT5,(decimal)Data.Cant5),
                new RecipeItemsDTO(Data.InsT6,(decimal)Data.Cant6),
                new RecipeItemsDTO(Data.InsT7,(decimal)Data.Cant7),
                new RecipeItemsDTO(Data.InsT8,(decimal)Data.Cant8)
            };
        }
   
    
    }
}
