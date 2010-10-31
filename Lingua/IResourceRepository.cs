using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lingua
{

    public interface IResourceRepository
    {
        //
        string New(string entity, string key, string data, string culture);
        void Delete(string entity, string key);
        void NewCulture(string entity, string culture);
        void Rename(string entity, string oldKey, string newKey);
    };

}
