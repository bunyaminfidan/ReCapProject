using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
   public  interface ICacheService
    {
        T Get<T>(string key);
        object Get(string key); //üstteki böylede yazılır ama convert işlemi lazım ondan dolayı üstteki daha iyi
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);//Regxp ile içinde xxx olanları cahingden sil gibi; add delete update methodu sonrası için.
    }
}
