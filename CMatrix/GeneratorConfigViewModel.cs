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



    /*
    class Model : INotifyPropertyChanged
    {
        private ObservableCollection<MyTabItem> _tabitems = new ObservableCollection<MyTabItem>();

        public Model()
        {
            MyTabItem myItem = new MyTabItem
            {
                Header = "test1",
                Content = "test1"
            };
            TabItems.Add(myItem);

            MyTabItem myItem2 = new MyTabItem
            {
                Header = "test2",
                Content = "test2"
            };
            TabItems.Add(myItem2);
        }

        public ObservableCollection<MyTabItem> TabItems
        {
            get
            {
                return _tabitems;
            }
            set
            {
                _tabitems = value;
                OnPropertyChanged("TabItems");
            }
        }

        public bool Execute()
        {
            MyTabItem myItem = new MyTabItem();
            myItem.Header = "test";
            myItem.Content = "test";
            TabItems.Add(myItem);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }*/

    public class GeneratorTabItem
    {
        public string Header { get; set; }
        private UserControl content;
        public UserControl Content { get { return content; } }

        private IGenerator generator;
        public IGenerator Generator { get { return generator; } set { generator = value; content = (UserControl)Generator; } }
    }



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
        #endregion

        private ObservableCollection<GeneratorTabItem> _tabitems = new ObservableCollection<GeneratorTabItem>();

        public ObservableCollection<GeneratorTabItem> TabItems
        {
            get
            {
                return _tabitems;
            }
            set
            {
                _tabitems = value;
                OnPropertyChanged("TabItems");
            }
        }


        //private int selectedTabIndex;
        //public int SelectedTabIndex
        //{
        //    get { return selectedTabIndex; }
        //    set
        //    {
        //        if (value != selectedTabIndex)
        //        {
        //            selectedTabIndex = value;
        //            OnPropertyChanged("SelectedTabIndex");
        //        }
        //    }
        //}


        public GeneratorConfigViewModel()
        {
            /*  GeneratorBlack myItem = new GeneratorBlack();
              myItem.Header = "test";
              myItem.Content = "test";
              TabItems.Add(myItem);

              tabCollection.Add(new GeneratorBlack(){Speed = 85});
              tabCollection.Add(new GeneratorBlack());
              SelectedTabIndex = 0;
              */

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
        }
    }
}
