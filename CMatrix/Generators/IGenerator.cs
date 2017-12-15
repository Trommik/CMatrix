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
        Generator.Info GenInfo { get; set; }

        // Not sure maybe not here!
        int Speed { get; set; }

        void GenerateImage(ref Color[] image);
    }
}
