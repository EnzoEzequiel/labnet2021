using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.EF;

namespace Logic.EF
{
    public class SuppliersLogic : BaseLogic, IABMLogic<Suppliers>
    {
        public void Add(Suppliers supplier)
        {

            try
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new DataException();
            }

            
        }

        public void Delete(int id)
        {
            
            var supplier = context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new ExcepcionPersonalizada();
            }
            else
            {
                context.Suppliers.Remove(supplier);
                context.SaveChanges();
            }

            
        }

        public List<Suppliers> GetAll()
        {
            return context.Suppliers.ToList();
        }


        public void Update(Suppliers supplier)
        {
            var supplierActualizado = context.Suppliers.Find(supplier.SupplierID);
            if (supplierActualizado == null)
            {
                throw new ExcepcionPersonalizada();
            }
            else
            {
                try
                {
                    supplierActualizado.CompanyName = supplier.CompanyName;
                    supplierActualizado.ContactName = supplier.ContactName;
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new DataException();
                }
            }
        }

        public Suppliers Encontrar(int? id)
        {
            var supplier = context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new ExcepcionPersonalizada();
            }
            return supplier;
            
        }

    }
}
