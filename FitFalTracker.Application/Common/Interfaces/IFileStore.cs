namespace FitFalTracker.Application.Common.Interfaces;

public interface IFileStore
{
     string SaveWriteFile(byte[] content, string sourceFileName, string path);

}