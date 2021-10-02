using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EF
{
    interface IABMLogic<T>
    {
        void Add(T data);

        void Delete(int id);

        List<T> GetAll();

        void Update(T data);

    }
}
