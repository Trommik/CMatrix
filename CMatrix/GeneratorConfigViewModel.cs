﻿using CMatrix.Generator;
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

            // Add event handler
            myItem.Delete_Clicked += Delete_Tab;

            GeneratorTabItem myItem2 = new GeneratorTabItem
            {
                Header = "Text",
                Generator = new GeneratorText()
                {
                    GenInfo = GeneratorTypes.TEXT.GetInfo()
                }
            };
            TabItems.Add(myItem2);

            // Add event handler
            myItem2.Delete_Clicked += Delete_Tab;


            //END DEBUG
        }

        private void Delete_Tab(object sender, GeneratorTabItemEventArgs e)
        {
            for(int i = TabItems.Count - 1; i > -1; i--)
            {
                var tab = TabItems[i];

                if (tab.ID == e.ID)
                {
                    TabItems.Remove(tab);
                }
            }
        }

    }

    public class GeneratorTabItem
    {
        public Guid ID { get; private set; }

        public string Header { get; set; }
        private UserControl content;
        public UserControl Content { get { return content; } }

        private IGenerator generator;
        public IGenerator Generator { get { return generator; } set { generator = value; content = (UserControl)Generator; } }


        public GeneratorTabItem()
        {
            ID = Guid.NewGuid();
        }


        /// <summary>
        /// Event handler for deleting a TabItem when the cross in the Header is clicked.
        /// </summary>
        public event EventHandler<GeneratorTabItemEventArgs> Delete_Clicked;
        public void DeleteButtonClicked()
        {
            // Fire Delete_Clicked Event with the unique ID of the TabItem
            Delete_Clicked?.Invoke(this, new GeneratorTabItemEventArgs(ID));
        }
    }

    public class GeneratorTabItemEventArgs : EventArgs
    {
        public Guid ID { get; private set; }

        public GeneratorTabItemEventArgs(Guid tabID)
        {
            ID = tabID;
        }
    }
}
