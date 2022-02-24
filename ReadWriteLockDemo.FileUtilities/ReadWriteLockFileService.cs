namespace ReadWriteLockDemo.FileUtilities;

public class ReadWriteLockFileService : IFileService
{
    private static readonly ReaderWriterLock _readerWriterLock;
    private readonly string _filePath;

    static ReadWriteLockFileService()
    {
        _readerWriterLock = new ReaderWriterLock();
    }

    public ReadWriteLockFileService(string filePath)
    {
        _filePath = filePath;
    }

    string IFileService.FilePath => _filePath;

    string IFileService.Read()
    {
        _readerWriterLock.AcquireReaderLock(TimeSpan.FromMinutes(1));
        try
        {
            Thread.Sleep(500);
            return File.ReadAllText(_filePath);
        }
        finally
        {
            if (_readerWriterLock.IsReaderLockHeld)
            {
                _readerWriterLock.ReleaseReaderLock();
            }
        }
    }

    void IFileService.Write(string content)
    {
        _readerWriterLock.AcquireWriterLock(TimeSpan.FromMinutes(1));
        try
        {
            Thread.Sleep(500);
            File.WriteAllText(_filePath, content);
        }
        finally
        {
            if (_readerWriterLock.IsWriterLockHeld)
            {
                _readerWriterLock.ReleaseWriterLock();
            }
        }
    }
}