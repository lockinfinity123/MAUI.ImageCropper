﻿using Com.Canhub.Cropper;
using System.Diagnostics;
using Android.Graphics;
using androidplatform = Android.Net;

namespace Maui.ImageCropper.Platforms.Android
{
    // All the code in this file is only included on Android.
    public class PlatformImageCropper : IImageCropperWrapper
    {
        public void ShowFromFile(ImageCropper imageCropper, string imageFile)
        {
            try
            {
                var platform = new Platform();
                var cropImageOptions = new CropImageOptions();

                cropImageOptions.CropMenuCropButtonTitle = new Java.Lang.String(imageCropper.CropButtonTitle);
                cropImageOptions.OutputCompressFormat = Bitmap.CompressFormat.Png;

                if (imageCropper.CropShape == ImageCropper.CropShapeType.Oval)
                    cropImageOptions.CropShape = CropImageView.CropShape.Oval;

                if (imageCropper.CropShape == ImageCropper.CropShapeType.RectangleHorizontalOnly)
                    cropImageOptions.CropShape = CropImageView.CropShape.RectangleHorizontalOnly;

                if (imageCropper.CropShape == ImageCropper.CropShapeType.RectangleVerticalOnly)
                    cropImageOptions.CropShape = CropImageView.CropShape.RectangleVerticalOnly;
                else
                    cropImageOptions.CropShape = CropImageView.CropShape.Rectangle;

                if (imageCropper.AspectRatioX > 0 && imageCropper.AspectRatioY > 0)
                {
                    cropImageOptions.FixAspectRatio = true;
                    cropImageOptions.AspectRatioX = imageCropper.AspectRatioX;
                    cropImageOptions.AspectRatioY = imageCropper.AspectRatioY;
                }
                else
                {
                    cropImageOptions.FixAspectRatio = false;
                }

                if (!string.IsNullOrWhiteSpace(imageCropper.PageTitle))
                {
                    cropImageOptions.ActivityTitle = new Java.Lang.String(imageCropper.PageTitle);
                }
                
                Platform.ImageCropperActivityResultLauncher.Launch(new CropImageContractOptions(androidplatform.Uri.FromFile(new Java.IO.File(imageFile)), cropImageOptions));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}