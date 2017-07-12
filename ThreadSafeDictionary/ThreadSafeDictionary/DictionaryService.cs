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
            Guid key = Guid.Empty;

            if (keyName != null)
            {
                if (!_keys.TryGetValue(keyName, out key))
                {
                    key = Guid.NewGuid();
                    _keys.Add(keyName, key);
                }
            }

            return key;
        }
    }
}
