using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        object Get(string key);

        // object seçmemizin nedeni içine her şey koyabileceğimiz için

        void Add(string key, object value, int duration);

        bool IsAdd(string key); //Cache'te var mı

        void Remove(string key); //Cache'ten uçur

        void RemoveByPattern(string pattern); //buna verdiğimiz patterne göre silme işlemi yapacak
    }
}
