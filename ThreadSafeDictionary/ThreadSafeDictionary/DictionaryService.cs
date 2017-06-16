using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeDictionary
{
    public class DictionaryService
    {
        private Dictionary<string, Guid> _keys = new Dictionary<string, Guid>();

        public Guid GetKeyByName(string keyName)
        {
            if (_keys.ContainsKey(keyName))
            {
                return _keys[keyName];
            }

            Guid key = Guid.NewGuid();
            _keys.Add(keyName, key);

            return key;
        }
    }
}
