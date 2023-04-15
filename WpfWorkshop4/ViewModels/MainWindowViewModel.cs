using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfWorkshop4.Models;

namespace WpfWorkshop4.ViewModels
{
    class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Racer> Racers { get; set; }
        public ObservableCollection<Racer> Participants { get; set; }

        private Racer selectedFromList;

        public Racer SelectedFromList
        {
            get { return selectedFromList; }
            set 
            { 
                SetProperty(ref selectedFromList, value);
                (AddToRace as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Racer selectedToRace;

        public Racer SelectedToRace
        {
            get { return selectedToRace; }
            set 
            { 
                SetProperty(ref selectedToRace, value);
                (RemoveFromRace as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand LoadRacers { get; set; }
        public ICommand AddToRace { get; set; }
        public ICommand RemoveFromRace { get; set; }

        public MainWindowViewModel()
        {
            Participants = new ObservableCollection<Racer>();
            Racers = new ObservableCollection<Racer>
            {
                new Racer("John Adams", 17.3, 16.4, true, "Chicago Bulls", 7),
                new Racer("Thomas Jenkins", 18.9, 15.1, false, "Chicago Bulls", 14),
                new Racer("Josh Williams", 14.1, 12.5, true, "Lakers", 77)
            };

            AddToRace = new RelayCommand(
                () => Participants.Add(SelectedFromList),
                () => SelectedFromList != null
            );

            RemoveFromRace = new RelayCommand(
                () => Participants.Remove(SelectedToRace),
                () => SelectedToRace != null
            );
        }
    }
}
