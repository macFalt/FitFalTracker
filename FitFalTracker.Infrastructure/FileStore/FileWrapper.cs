using FitFalTracker.Application.Common.Interfaces;

namespace FitFalTracker.Infrastructure.FileStore;

public class FileWrapper : IFileWrapper
{
    public void WriteAllBytes(string outputFile, byte[] content)
    {
        File.WriteAllBytes(outputFile, content);
    }
}