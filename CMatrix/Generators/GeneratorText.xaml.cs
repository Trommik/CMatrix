using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CMatrix.Generators
{
    /// <summary>
    /// Interaktionslogik für GeneratorText.xaml
    /// </summary>
    public partial class GeneratorText : UserControl, IGenerator
    {
        public MatrixSizeInfo MatrixInfo { get; set; }
        public Generator.Info GenInfo { get; set; }

        private int sizeX;
        private int sizeY;

        public int Speed { get; set; }

        // For xaml
        public GeneratorText()
        {
            InitializeComponent();
        }

        public GeneratorText(MatrixSizeInfo info)
        {
            InitializeComponent();

            sizeX = info.width;
            sizeY = info.height;
        }

        public void GenerateImage(ref Color[] image)
        {
            throw new NotImplementedException();
        }
    }
}
/*
    public class GeneratorText : AbstractGenerator
    {
        public GeneratorText(int sizeX, int sizeY, int speed) : base(sizeX, sizeY, speed)
        {

        }

        public override void GenerateImage(ref System.Windows.Media.Color[] image)
        {
            // All installed fonts 
            List<string> fonts = new List<string>();

            foreach (FontFamily font in FontFamily.Families)
            {
                fonts.Add(font.Name);
            }



            int gapLeft = 0;
            int gapTop = 5;

            float textSize = 12;

            FontStyle textStyle = FontStyle.Strikeout | FontStyle.Bold;

            Color textColor = Color.FromArgb(255, 88, 0);


            string text = "CMAtrix";



            // Create a new Bitmap with the size of the Matrix
            Bitmap bitmapImg = new Bitmap(sizeX, sizeY);
            Graphics g = Graphics.FromImage(bitmapImg);

            // Disable Antialising for text
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

            // Create a rectangle with the matrix bounds in which the text gets written
            RectangleF textContainer = new RectangleF(gapLeft, gapTop, sizeX - gapLeft, sizeY - gapTop);


            // Create a font
            Font usedFont = new Font(fonts[1], textSize, textStyle);

            // Draw the string to the bitmap 
            g.DrawString(text, usedFont, new SolidBrush(textColor), textContainer);
            g.Flush();


            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    // Get the color of the pixel in the create bitmap
                    System.Drawing.Color clr = bitmapImg.GetPixel(i, Math.Abs(j - (sizeY - 1)));

                    // Convert it to a Media.Color (new WPF Color class!)
                    image[j * sizeX + i] = System.Windows.Media.Color.FromRgb(clr.R, clr.G, clr.B);
                }
            }

        }
    }*/
