using ReadWriteLockDemo.FileUtilities;
using Xunit;

namespace ReadWriteLockDemo.FileUtilitiesTests;

public class FileServiceTests
{
    private readonly string _filePath;

    public FileServiceTests()
    {
        _filePath = "<put your text file path here>";
    }

    [Fact]
    public void MonitorLockFileService()
    {
        Parallel.For(0, 10, i =>
        {
            ReadWrite(new MonitorLockFileService(_filePath));
        });
    }

    [Fact]
    public void ReadWriteLockFileServiceTest()
    {
        Parallel.For(0, 10, i =>
        {
            ReadWrite(new ReadWriteLockFileService(_filePath));
        });
    }

    private void ReadWrite(IFileService fileService)
    {
        fileService.Write("hello");
        string contents = fileService.Read();
    }
}