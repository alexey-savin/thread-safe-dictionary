using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeDictionary
{
    public class DictionaryService : IDisposable
    {
        private bool _isDisposed = false;

        private Dictionary<string, Guid> _keys = new Dictionary<string, Guid>();

        ~DictionaryService()
        {
            CleanUp(false);
        }

        public void Dispose()
        {
            CleanUp(true);

            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // cleanup all managed resources
                    Console.WriteLine("Disposing...");
                }

                // cleanup all unmanaged resources
            }

            _isDisposed = true;
        }

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
