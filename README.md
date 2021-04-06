# 'ReaderWriterLock' demo in C#

This is a demo to show the usage of 'ReaderWriterLock' where we need multiple 
reads at a time but only one write at a time. Also it is faster than normal lock.

There are two classes in this example. One is using `monitor lock` and another is
using `read write lock`. The `monitor lock` is not sweetable where we need multiple
reads at the same time but only one write operation at a time. For this we need to
use `read write lock`.

For `monitor lock` only one read or write is allowed. This makes read process slow.
Because if there is no write operation happening then multiple read opereration
can happen. For this `read write lock` is sweetable.

```c#
namespace ReadWriteLockDemo.FileUtilities
{
    public class MonitorLockFileService : IFileService
    {
        // code here...
    }
}

namespace ReadWriteLockDemo.FileUtilities
{
    public class MonitorLockFileService : IFileService
    {
        // code here...
    }
}
```

Test cases are written for both the cases.

```c#
[Fact]
public void MonitorLockFileService()
{
    // code here...
}

[Fact]
public void ReadWriteLockFileServiceTest()
{
    // code here...
}
```
