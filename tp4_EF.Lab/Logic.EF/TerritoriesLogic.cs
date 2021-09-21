using Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EF
{
    public class TerritoriesLogic : BaseLogic, IABMLogic<Territories>
    {
        public void Add(Territories territorie)
        {
            try
            {
                context.Territories.Add(territorie);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new DataException();
            }
        }

        public void Delete(int id)
        {
            var territorie = context.Territories.Find(id);
            if (territorie == null)
            {
                throw new ExcepcionPersonalizada();
            }
            else
            {
                context.Territories.Remove(territorie);
                context.SaveChanges();
            }
            
        }

        public List<Territories> GetAll()
        {
            return context.Territories.ToList();
        }

        public void Update(Territories territorie)
        {
            var territorieUpdate = context.Territories.Find(territorie.TerritoryID);
            if (territorieUpdate == null)
            {
                throw new ExcepcionPersonalizada();
            }
            else
            {
                try
                {

                    territorieUpdate.TerritoryDescription = territorie.TerritoryDescription;
                    territorieUpdate.RegionID = territorie.RegionID;
                    context.SaveChanges();
                }
                catch (ExcepcionPersonalizada ex)
                {
                    throw ex;
                }
            }
            
        }

        public Territories Encontrar(string id)
        {
            var territory = context.Territories.Find(id);
            if (territory == null)
            {
                throw new ExcepcionPersonalizada();
            }
            return territory;

        }

        public void EliminarTerritorio(string id)
        {
            var territorie = context.Territories.Find(id);
            if (territorie == null)
            {
                throw new ExcepcionPersonalizada();
            }
            else
            {
                context.Territories.Remove(territorie);
                context.SaveChanges();
            }

        }
    }
}
