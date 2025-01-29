
namespace Maui.ImageCropper.Platforms.iOS
{
    public class Platform
    {
        public void Init()
        {
            DependencyService.Register<IImageCropperWrapper, PlatformImageCropper>();
        }
    }
}
