using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScreenFixer
{
    internal class MainPageViewModel: INotifyPropertyChanged
    {

        private ScreenFix whiteBarsFix;
        private ScreenFix stuckPixelFix;
        private ScreenFix cycleColorFix;
        private ScreenFix selectedFix;
        ICommand selectStuckPixelFixCommand;
        ICommand selectWhiteBarsFixCommand;
        ICommand cycleColorFixCommand;


        public ScreenFix WhiteBarsFix
        {
            get
            {
                return whiteBarsFix;
            }

            set
            {
                whiteBarsFix = value;
                NotifyPropertyChanged("WhiteBarsFix");
            }
        }

        public ScreenFix StuckPixelFix
        {
            get
            {
                return stuckPixelFix;
            }

            set
            {
                stuckPixelFix = value;
                NotifyPropertyChanged("StuckPixelFix");
            }
        }

        public ScreenFix SelectedFix
        {
            get
            {
                return selectedFix;
            }

            set
            {
                selectedFix = value;
                NotifyPropertyChanged("SelectedFix");
            }
        }

        public ScreenFix CycleColorFix
        {
            get
            {
                return cycleColorFix;
            }

            set
            {
                cycleColorFix = value;
                NotifyPropertyChanged("SelectedFix");
            }
        }

        public ICommand SelectStuckPixelFixCommand
        {
            get
            {
                return selectStuckPixelFixCommand;
            }

            set
            {
                selectStuckPixelFixCommand = value;
            }
        }

        public ICommand SelectWhiteBarsFixCommand
        {
            get
            {
                return selectWhiteBarsFixCommand;
            }

            set
            {
                selectWhiteBarsFixCommand = value;
            }
        }

        public ICommand CycleColorFixCommand
        {
            get
            {
                return cycleColorFixCommand;
            }

            set
            {
                cycleColorFixCommand = value;
            }
        }

        internal MainPageViewModel()
        {
            CreateFixes();
            selectStuckPixelFixCommand = new RelayCommand(SelectPixelFix);
            selectWhiteBarsFixCommand = new RelayCommand(SelectWhiteBarsFix);
            cycleColorFixCommand = new RelayCommand(SelectCycleColorFix);

            SelectedFix = WhiteBarsFix;
        }

        private void SelectPixelFix(object obj)
        {
            SelectedFix = stuckPixelFix;
        }

        private void SelectWhiteBarsFix(object obj)
        {
            SelectedFix = whiteBarsFix;
        }

        private void SelectCycleColorFix(object obj)
        {
            SelectedFix = cycleColorFix;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CreateFixes()
        {
            WhiteBarsFix = new ScreenFix
            {
                Title = "Scrolling White Bar",
                Description = "Scrolling White bars to remove image retention",
                PageType = typeof(ScrollingWhite)
            };

            StuckPixelFix = new ScreenFix
            {
                Title = "Stuck Pixel Fix",
                Description = "Fixes stuck pixels by flashing colors on screen",
                PageType = typeof(StuckPixelFix)
            };

            CycleColorFix = new ScreenFix
            {
                Title = "Cycle Colors",
                Description = "Cycle through different slides of colors.  This can be used to fix image retention," +
                              "check for stuck or dead pixels, or  break in plasma screens.",
                PageType = typeof(ColorCycle)
            };
        }
    }
}
