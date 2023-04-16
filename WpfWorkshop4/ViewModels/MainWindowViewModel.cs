using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfWorkshop4.Logic;
using WpfWorkshop4.Models;

namespace WpfWorkshop4.ViewModels
{
    class MainWindowViewModel : ObservableRecipient
    {
        IRacerLogic logic;
        public ObservableCollection<Racer> Racers { get; set; }
        public ObservableCollection<Racer> Participants { get; set; }

        private Racer selectedFromList;

        public Racer SelectedFromList
        {
            get { return selectedFromList; }
            set 
            { 
                SetProperty(ref selectedFromList, value);
                (AddToRace as RelayCommand)?.NotifyCanExecuteChanged();
                (ShowRacerDetails as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }

        private Racer selectedToRace;

        public Racer SelectedToRace
        {
            get { return selectedToRace; }
            set 
            { 
                SetProperty(ref selectedToRace, value);
                (RemoveFromRace as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }
        public ICommand LoadRacers { get; set; }
        public ICommand AddToRace { get; set; }
        public ICommand RemoveFromRace { get; set; }
        public ICommand ShowRacerDetails { get; set; }
        public ICommand SaveRace { get; set; }

        public MainWindowViewModel() :this(IsInDesignMode ? null : Ioc.Default.GetService<IRacerLogic>())
        {
            
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel(IRacerLogic logic)
        {
            this.logic = logic;
            Participants = new ObservableCollection<Racer>();
            Racers = new ObservableCollection<Racer>();

            logic.SetupCollections(Racers, Participants);

            AddToRace = new RelayCommand(
                () => logic.AddToRace(SelectedFromList),
                () => SelectedFromList != null
            );

            RemoveFromRace = new RelayCommand(
                () => logic.RemoveFromRace(SelectedToRace),
                () => SelectedToRace != null
            );

            LoadRacers = new RelayCommand(
                () => logic.LoadRacers(),
                () => Racers.Count() == 0
            );

            ShowRacerDetails = new RelayCommand(
                () => logic.ShowDetails(SelectedFromList),
                () => SelectedFromList != null
            );

            SaveRace = new RelayCommand(
                () => logic.SaveRace(),
                () => Participants.Count != 0
            );
        }
    }
}
