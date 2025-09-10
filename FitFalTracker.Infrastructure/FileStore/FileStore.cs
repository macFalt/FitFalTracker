using FitFalTracker.Application.Common.Interfaces;

namespace FitFalTracker.Infrastructure.FileStore;

public class FileStore : IFileStore
{
    private readonly IDirectoryWrapper _directoryWrapper;
    private readonly IFileWrapper _fileWrapper;

    public FileStore(IDirectoryWrapper directoryWrapper, IFileWrapper fileWrapper)
    {
        _directoryWrapper = directoryWrapper;
        _fileWrapper = fileWrapper;
    }
    
    
    public string SaveWriteFile(byte[] content, string sourceFileName, string path)
    {
        _directoryWrapper.CreateDirectory(path);
        var outputFile=Path.Combine(path, sourceFileName);
        _fileWrapper.WriteAllBytes(outputFile, content);
        return outputFile;
    }
}