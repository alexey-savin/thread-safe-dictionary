using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadSafeDictionary
{
    public class ReadWriteList
    {
        private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

        private List<int> _items = new List<int>();
        private Random _rand = new Random();

        public void Run()
        {
            new Thread(Read).Start();
            new Thread(Read).Start();
            new Thread(Read).Start();

            new Thread(Write).Start("A");
            new Thread(Write).Start("B");
        }

        private void Read()
        {
            while (true)
            {
                rwLock.EnterReadLock();
                foreach (var item in _items)
                {
                    Thread.Sleep(10);
                }
                rwLock.ExitReadLock();
            }
        }

        private void Write(object threadId)
        {
            while (true)
            {
                int newNum = GetRandNum(50);

                rwLock.EnterWriteLock();
                _items.Add(newNum);
                rwLock.ExitWriteLock();

                Console.WriteLine($"Thread {threadId} added {newNum}");
                Thread.Sleep(100);
            }
        }

        private int GetRandNum(int max)
        {
            return _rand.Next(max);
        }
    }
}
