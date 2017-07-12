using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ThreadSafeDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DictionaryService ds = new DictionaryService())
            {
                var guid = ds.GetKeyByName(null);
                Console.WriteLine(guid.ToString());
            }
            
            //ReadWriteList rwl = new ReadWriteList();
            //rwl.Run();

            Console.ReadKey();
        }
    }
}
