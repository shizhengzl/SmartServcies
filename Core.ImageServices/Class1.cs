

using System.Drawing;

namespace Core.ImageServices
{
    public class Class1
    {
        public void ReadImage(string imagefile)
        {

            Bitmap img = new Bitmap(imagefile);
            Color[,] allcoloer = new Color[img.Height, img.Width];
            for (int h = 0; h < img.Height; h++)
            {
                for (int w = 0; w < img.Width; w++)
                {
                    Color pixelColor = img.GetPixel(h, w); 
                }
            }
        }
    }
}