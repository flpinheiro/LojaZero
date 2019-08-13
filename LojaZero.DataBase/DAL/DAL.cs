using LojaZero.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.DAL
{
    public abstract class DAL<T> : IDAL<T>
    {
        protected LojaZeroDbContext _context;

        protected DAL(LojaZeroDbContext context)
        {
            _context = context;
        }

        public abstract void Create(T t);
        public abstract void Delete(T t);
        public bool Exist(int i) => Read(i) != null;
        public abstract T Read(int i);
        public abstract ICollection<T> ReadAll();
        public abstract void Update(T t);
    }
}
