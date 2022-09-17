namespace WebUI.Helpers
{
    public interface IFileUpload
    {
        string FileUploads(IFormFile file);
        string DeleteImage(string Name);
        string DeleteImages(List<string> images);
        string UpdateFile(IFormFile file, string Name);
        List<string> FileListUpload(List<IFormFile> files);
    }
}
