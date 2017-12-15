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
        private ObservableCollection<GeneratorInfo> infosList = new ObservableCollection<GeneratorInfo>();

        private static Generator _infosList = new Generator();
        public static ObservableCollection<GeneratorInfo> GetInfoList
        {
            get { return _infosList.infosList; }
        }

        private Generator()
        {
            infosList.Add(new GeneratorInfo(GeneratorTypes.BLACK, "Black"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.ANIMATED_GIF, "Animated GIF"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.CAPTURE, "Capture"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.EXPANDING_OBJECTS, "Expanding Objects"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.FADE_AND_SCROLL, "Fade and Scroll"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.FADING_PIXELS, "Fading Pixels"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.FRACTAL, "Fractal"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.FALLING_OBJECTS, "Falling Objects"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.FIRE, "Fire"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.GRID, "Grid"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.KNIGHT_RIDER, "Knight Rider"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.META_BALLS, "Meta Balls"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.OBJECTS_3D, "Objects 3D"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.PLASMA, "Plasma"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.RANDOM_PIXEL, "Random Pixels"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.TEXT, "Text"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.SIMPLE_SPECTRUM, "Simple Spectrum"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.STROBO, "Strobo"));
            infosList.Add(new GeneratorInfo(GeneratorTypes.WAVE, "Wave"));
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
        public static GeneratorInfo GetInfo(this GeneratorTypes type)
        {
            // Try to get the info object
            return Generator.GetInfoList.Single(x => x.GenType == type);
        }
    }
}