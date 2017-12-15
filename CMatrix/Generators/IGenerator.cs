using CMatrix.Generators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;




//public enum Directions : int
//{
//    Left_Right = 0,
//    Bottom_Top = 1,
//    BottomLeft_TopRight = 2,
//    TopLeft_BottomRight = 3,
//}




namespace CMatrix
{
    /// <summary>
    /// Defines the Size of a Matrix by setting width and height.
    /// </summary>
    public struct MatrixSizeInfo
    {
        /// <summary>
        /// The Width and Height of the Matrix in pixels.
        /// </summary>
        public int width, height;

        /// <summary>
        /// The number of pixels e.g. width * height (is self calculated).
        /// </summary>
        public int size;
    }


    public interface IGenerator
    {

        MatrixSizeInfo MatrixInfo { get; set; }

        // For what?
        GeneratorInfo GenInfo { get; set; }

        // Not sure maybe not here!
        int Speed { get; set; }

        void GenerateImage(ref Color[] image);
    }


    public struct GeneratorInfo
    {
        public GeneratorTypes GenType { get; }
        public string Text { get; }
        public string ToolTipText { get; }

        public GeneratorInfo(GeneratorTypes type, string text = null, string toolTipText = "")
        {
            // Get the name of the GeneratorType
            GenType = type;

            Text = text;

            // If there is no specific text use the generator Type name
            if (Text == null)
                Text = GenType.ToString("f"); ;

            ToolTipText = toolTipText;
        }
    }
}
