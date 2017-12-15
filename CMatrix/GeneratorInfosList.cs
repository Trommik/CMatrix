using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMatrix
{
    /// <summary>
    /// An Class which function returns a ObservableCollection which stores the different GeneratorInfos which can be added dynamically.
    /// #TODO: Save at the end when changes happend!
    /// </summary>
    public class Generator
    {
        private ObservableCollection<Info> infosList = new ObservableCollection<Info>();

        private static Generator staticGeneratorInstance = new Generator();
        public static ObservableCollection<Info> GetInfoList
        {
            get { return staticGeneratorInstance.infosList; }
        }

        private Generator()
        {
            infosList.Add(new Info(GeneratorTypes.BLACK, "Black"));
            infosList.Add(new Info(GeneratorTypes.ANIMATED_GIF, "Animated GIF"));
            infosList.Add(new Info(GeneratorTypes.CAPTURE, "Capture"));
            infosList.Add(new Info(GeneratorTypes.EXPANDING_OBJECTS, "Expanding Objects"));
            infosList.Add(new Info(GeneratorTypes.FADE_AND_SCROLL, "Fade and Scroll"));
            infosList.Add(new Info(GeneratorTypes.FADING_PIXELS, "Fading Pixels"));
            infosList.Add(new Info(GeneratorTypes.FRACTAL, "Fractal"));
            infosList.Add(new Info(GeneratorTypes.FALLING_OBJECTS, "Falling Objects"));
            infosList.Add(new Info(GeneratorTypes.FIRE, "Fire"));
            infosList.Add(new Info(GeneratorTypes.GRID, "Grid"));
            infosList.Add(new Info(GeneratorTypes.KNIGHT_RIDER, "Knight Rider"));
            infosList.Add(new Info(GeneratorTypes.META_BALLS, "Meta Balls"));
            infosList.Add(new Info(GeneratorTypes.OBJECTS_3D, "Objects 3D"));
            infosList.Add(new Info(GeneratorTypes.PLASMA, "Plasma"));
            infosList.Add(new Info(GeneratorTypes.RANDOM_PIXEL, "Random Pixels"));
            infosList.Add(new Info(GeneratorTypes.TEXT, "Text"));
            infosList.Add(new Info(GeneratorTypes.SIMPLE_SPECTRUM, "Simple Spectrum"));
            infosList.Add(new Info(GeneratorTypes.STROBO, "Strobo"));
            infosList.Add(new Info(GeneratorTypes.WAVE, "Wave"));
        }


        public struct Info
        {
            public GeneratorTypes GenType { get; }
            public string Text { get; }
            public string ToolTipText { get; }

            public Info(GeneratorTypes type, string text = null, string toolTipText = null)
            {
                // Get the name of the GeneratorType
                GenType = type;

                Text = text;

                ToolTipText = toolTipText;


                // If there is no specific text use the generator Type name
                if (Text == null)
                    Text = GenType.ToString("f"); ;

                if (toolTipText == null)
                    ToolTipText = Text;

            }
        }
    };

    /// <summary>
    /// Enum which holds every GeneratorType for TypeSafty.
    /// </summary>
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

    /// <summary>
    /// Extension method for the GeneratorType enum which trys to return the GeneratorInfo object associated to the enum GeneratorType.
    /// </summary>
    public static class GeneratorTypesExtensionMethods
    {
        public static Generator.Info GetInfo(this GeneratorTypes type)
        {
            // Try to get the info object
            return Generator.GetInfoList.Single(x => x.GenType == type);
        }
    }
}