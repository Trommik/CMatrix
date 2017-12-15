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
    /// Interaktionslogik für GeneratorBlack.xaml
    /// </summary>
    public partial class GeneratorBlack : UserControl, IGenerator
    {
        public MatrixSizeInfo MatrixInfo { get; set; }
        public GeneratorInfo GenInfo { get; set; }

        private int sizeX;
        private int sizeY;


        public int Speed { get; set; }

        // For xaml
        public GeneratorBlack()
        {
            InitializeComponent();
        }

        public GeneratorBlack(MatrixSizeInfo info)
        {
            InitializeComponent();

            sizeX = info.width;
            sizeY = info.height;
        }


        public void GenerateImage(ref Color[] image)
        {
            for (int i = 0; i < sizeX * sizeY; i++)
            {
                image[i] = Color.FromRgb(0, 255, 0); // BLACK
            }
        }
    }
}
