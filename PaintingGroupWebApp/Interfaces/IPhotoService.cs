using CloudinaryDotNet.Actions;

namespace PaintingGroupWebApp.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsyc(IFormFile file);
        Task<DeletionResult> DeletePhotoAsyc(string publicId);
    }
}
