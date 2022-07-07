using recipes_alexander_ccoa.Core.Models;
using recipes_alexander_ccoa.Shared.DTO;
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
