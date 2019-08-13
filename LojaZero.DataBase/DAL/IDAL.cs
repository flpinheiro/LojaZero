using System;
using System.Collections.Generic;
using System.Text;

namespace LojaZero.DAL
{
    public interface IDAL<T>
    {   
        void Create(T t);
        T Read(int i);
        ICollection<T> ReadAll();
        void Update(T t);
        void Delete(T t);
        bool Exist(int i);
    }
}
