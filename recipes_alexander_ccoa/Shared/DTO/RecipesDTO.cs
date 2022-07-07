using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipes_alexander_ccoa.Shared.DTO
{
    public class RecipesDTO
    {
        public int id { get; set; }
        public string mezcla { get; set; }
        public DateTime fecha { get; set; }
        public IEnumerable<RecipeItemsDTO> items { get; set; }
    }
    public class RecipeItemsDTO
    {
        public string name { get; set; }
        public decimal quantity { get; set; }

        public RecipeItemsDTO()
        {

        }

        public RecipeItemsDTO(string name, decimal quantity)
        {
            this.name=name;
            this.quantity=quantity;
        }
    }
}
