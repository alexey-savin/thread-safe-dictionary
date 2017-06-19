using System;

namespace ThreadSafeDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //DictionaryService ds = new DictionaryService();
            //var guid = ds.GetKeyByName(null);
            //Console.WriteLine(guid.ToString());

            ReadWriteList rwl = new ReadWriteList();
            rwl.Run();

            Console.ReadKey();
        }
    }
}
