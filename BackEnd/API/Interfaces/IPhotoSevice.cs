using System;
using CloudinaryDotNet.Actions;

namespace API.Interfaces;

public interface IPhotoSevice
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file); // Task<ImageUploadResult>
    Task<DeletionResult> DeletionResultAsync(string publicId);
}
