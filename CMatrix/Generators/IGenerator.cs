using CMatrix.Generator;
using System;
using System.Collections.Generic;
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

    public enum GeneratorTypes : int
    {
        BLACK = 0,
        ANIMATED_GIF = 1,
        CAPTURE = 2,
        EXPANDING_OBJECTS = 3,
        FADE_AND_SCROLL = 4,
        FADING_PIXELS = 5,
        FALLING_OBJECTS = 6,
        FIRE = 7,
        FRACTAL = 8,
        GRID = 9,
        KNIGHT_RIDER = 10,
        META_BALLS = 11,
        OBJECTS_3D = 12,
        PLASMA = 13,
        RANDOM_PIXEL = 14,
        TEXT = 15,
        SIMPLE_SPECTRUM = 16,
        STROBO = 17,
        WAVE = 18,
    }

    public static class GeneratorTypesExtensionMethods
    {
        public static GeneratorInfo GetInfo(this GeneratorTypes type)
        {
            // Try to get the info object
            return generatorInfos.Find(x => x.GenType == type);
        }


        public static List<GeneratorInfo> generatorInfos = new List<GeneratorInfo>
        {
            new GeneratorInfo(GeneratorTypes.BLACK, "Black") ,
            new GeneratorInfo(GeneratorTypes.ANIMATED_GIF, "Animated GIF") ,
            new GeneratorInfo(GeneratorTypes.CAPTURE, "Capture") ,
            new GeneratorInfo(GeneratorTypes.EXPANDING_OBJECTS, "Expanding Objects") ,
            new GeneratorInfo(GeneratorTypes.FADE_AND_SCROLL, "Fade and Scroll", "Generator/FadeScroll.xaml") ,
            new GeneratorInfo(GeneratorTypes.FADING_PIXELS, "Fading Pixels") ,
            new GeneratorInfo(GeneratorTypes.FRACTAL, "Fractal") ,
            new GeneratorInfo(GeneratorTypes.FALLING_OBJECTS, "Falling Objects") ,
            new GeneratorInfo(GeneratorTypes.FIRE, "Fire") ,
            new GeneratorInfo(GeneratorTypes.GRID, "Grid") ,
            new GeneratorInfo(GeneratorTypes.KNIGHT_RIDER, "Knight Rider") ,
            new GeneratorInfo(GeneratorTypes.META_BALLS, "Meta Balls") ,
            new GeneratorInfo(GeneratorTypes.OBJECTS_3D, "Objects 3D") ,
            new GeneratorInfo(GeneratorTypes.PLASMA, "Plasma") ,
            new GeneratorInfo(GeneratorTypes.RANDOM_PIXEL, "Random Pixels") ,
            new GeneratorInfo(GeneratorTypes.TEXT, "Text") ,
            new GeneratorInfo(GeneratorTypes.SIMPLE_SPECTRUM, "Simple Spectrum") ,
            new GeneratorInfo(GeneratorTypes.STROBO, "Strobo") ,
            new GeneratorInfo(GeneratorTypes.WAVE, "Wave") ,
        };
     
    }
}
