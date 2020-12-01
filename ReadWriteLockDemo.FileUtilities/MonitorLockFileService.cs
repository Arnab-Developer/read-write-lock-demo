using System.IO;
using System.Threading;

namespace ReadWriteLockDemo.FileUtilities
{
    public class MonitorLockFileService : IFileService
    {
        private static readonly object _syncRoot;
        private readonly string _filePath;

        static MonitorLockFileService()
        {
            _syncRoot = new object();
        }

        public MonitorLockFileService(string filePath)
        {
            _filePath = filePath;
        }

        string IFileService.FilePath => _filePath;

        string IFileService.Read()
        {
            Monitor.Enter(_syncRoot);
            try
            {
                Thread.Sleep(500);
                return File.ReadAllText(_filePath);
            }
            finally
            {
                if (Monitor.IsEntered(_syncRoot))
                {
                    Monitor.Exit(_syncRoot);
                }
            }
        }

        void IFileService.Write(string content)
        {
            Monitor.Enter(_syncRoot);
            try
            {
                Thread.Sleep(500);
                File.WriteAllText(_filePath, content);
            }
            finally
            {
                if (Monitor.IsEntered(_syncRoot))
                {
                    Monitor.Exit(_syncRoot);
                }
            }
        }
    }
}
