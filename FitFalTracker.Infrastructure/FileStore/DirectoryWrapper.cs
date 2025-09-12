using FitFalTracker.Application.Common.Interfaces;

namespace FitFalTracker.Infrastructure.FileStore;

public class DirectoryWrapper : IDirectoryWrapper
{
    public void CreateDirectory(string path)
    {
        Directory.CreateDirectory(path);
    }
}