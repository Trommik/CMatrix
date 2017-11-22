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

namespace CMatrix
{
    /// <summary>
    /// Interaktionslogik für GeneratorConfig.xaml
    /// </summary>
    public partial class GeneratorConfig : UserControl
    {
        public GeneratorConfig()
        {
            InitializeComponent();
            this.DataContext = new GeneratorConfigViewModel();
        }
    }

    public class GeneratorTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BlackGenTemplate { get; set; }

        public DataTemplate TextGenTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            GeneratorTabItem selectedGenTabItem = (GeneratorTabItem)item;
            IGenerator selectedGen = selectedGenTabItem.Generator;
                
            switch (selectedGen.GenInfo.GenType)
            {
                case GeneratorTypes.BLACK:
                    return BlackGenTemplate;
                case GeneratorTypes.TEXT:
                    return TextGenTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
