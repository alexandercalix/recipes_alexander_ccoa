using recipes_alexander_ccoa.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipes_alexander_ccoa.Core.Service
{
    public class crudService<T> where T: class
    {
        private readonly recipesContext ctx;

        public crudService(recipesContext ctx)
        {
            this.ctx=ctx;
        }

        public IEnumerable<M> GetUnique<M>(Func<T,M> selectData)
        {
            try
            {
                return ctx.Set<T>().Select(selectData).Distinct();
            }
            catch (Exception)
            {
                throw new Exception("Error con SQL");
            }
        }

        public IEnumerable<T> Get(Func<T,bool> filter)
        {
            try
            {
                return ctx.Set<T>().Where(filter).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error con SQL");
            }
        }

    }
}
