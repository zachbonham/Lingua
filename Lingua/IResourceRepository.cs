using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lingua
{

    public interface IResourceRepository
    {
        //
        string New(string entity, string culture);
        void Delete(string entity, string key);
        void NewCulture(string entity, string culture);
        void Rename(string entity, string oldKey, string newKey);
        void AddItem(string entity, string key, string value, string culture);
        void DeleteItem(string key);

    };

}
