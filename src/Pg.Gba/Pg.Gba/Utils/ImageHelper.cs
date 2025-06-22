using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pg.Gba.Utils
{
    internal class ImageHelper
    {
        public static  bool IsImageClicked(Texture2D sampleImage, Vector2 imagePosition, MouseState currentMouseState)
        {
            var isClicked = false;

            // Store pixel data for transparency check
            var sampleImageData = new Color[sampleImage.Width * sampleImage.Height];
            sampleImage.GetData(sampleImageData);

            // Check if click is within image bounds
            Rectangle imageRect = new Rectangle(
                (int)imagePosition.X, (int)imagePosition.Y,
                sampleImage.Width, sampleImage.Height);

            if (imageRect.Contains(currentMouseState.X, currentMouseState.Y))
            {
                int localX = currentMouseState.X - (int)imagePosition.X;
                int localY = currentMouseState.Y - (int)imagePosition.Y;
                int pixelIndex = localY * sampleImage.Width + localX;

                if (pixelIndex >= 0 && pixelIndex < sampleImageData.Length)
                {
                    Color pixel = sampleImageData[pixelIndex];
                    isClicked = pixel.A > 0;
                }
                else
                {
                    isClicked = false;
                }
            }
            else
            {
                isClicked = false;
            }

            return isClicked;
        }
    }
}
