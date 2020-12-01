namespace ReadWriteLockDemo.FileUtilities
{
    public interface IFileService
    {
        string FilePath { get; }

        string Read();

        void Write(string content);
    }
}
