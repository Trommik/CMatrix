using CMatrix.Generator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace CMatrix
{
    public class GeneratorConfigViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implemantation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Propertys
        public int type;
        public int Type
        {
            get
            {
                return type;
            }
            set
            {
                Type = value;
                OnPropertyChanged("Type");
            }
        }

        private int mixMode;
        public int MixMode
        {
            get
            {
                return mixMode;
            }
            set
            {
                mixMode = value;
                OnPropertyChanged("MixMode");
            }
        }

        private int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        private int level;
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }
        

        private ObservableCollection<GeneratorTabItem> tabitems = new ObservableCollection<GeneratorTabItem>();
        public ObservableCollection<GeneratorTabItem> TabItems
        {
            get
            {
                return tabitems;
            }
            set
            {
                tabitems = value;
                OnPropertyChanged("TabItems");
            }
        }

        private int selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set
            {
                if (value != selectedTabIndex)
                {
                    selectedTabIndex = value;
                    OnPropertyChanged("SelectedTabIndex");
                    Console.WriteLine("CHANGE!!!!");
                }
            }
        }
        #endregion


        public GeneratorConfigViewModel()
        {
            SelectedTabIndex = 0;


            //DEBUG
            GeneratorTabItem myItem = new GeneratorTabItem
            {
                Header = "Black",
                Generator = new GeneratorBlack()
                {
                    GenInfo = GeneratorTypes.BLACK.GetInfo()

                }
            };
            TabItems.Add(myItem);

            GeneratorTabItem myItem2 = new GeneratorTabItem
            {
                Header = "Text",
                Generator = new GeneratorText()
                {
                    GenInfo = GeneratorTypes.TEXT.GetInfo()
                }
            };
            TabItems.Add(myItem2);
            //END DEBUG
        }

    }

    public class GeneratorTabItem
    {
        public string Header { get; set; }
        private UserControl content;
        public UserControl Content { get { return content; } }

        private IGenerator generator;
        public IGenerator Generator { get { return generator; } set { generator = value; content = (UserControl)Generator; } }


        public void DeleteButtonClicked()
        {
            Console.WriteLine("delete " + Header);
        }
    }
}
