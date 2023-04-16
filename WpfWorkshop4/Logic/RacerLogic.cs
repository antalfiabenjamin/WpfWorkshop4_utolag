using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfWorkshop4.Models;

namespace WpfWorkshop4.Logic
{
    public class RacerLogic : IRacerLogic
    {
        IList<Racer>? racers;
        IList<Racer>? participants;

        readonly IMessenger messenger;

        public int ParticipantCount { get { return participants.Count; } }

        public RacerLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void SetupCollections(IList<Racer> racers, IList<Racer> participants)
        {
            this.racers = racers;
            this.participants = participants;
        }

        public void LoadRacers()
        {
            racers?.Add(new Racer("John Adams", 17.3, 16.4, true, "Chicago Bulls", 7));
            racers?.Add(new Racer("Thomas Jenkins", 18.9, 15.1, false, "Chicago Bulls", 14));
            racers?.Add(new Racer("Josh Williams", 14.1, 12.5, true, "Lakers", 77));
        }

        public void AddToRace(Racer racer)
        {
            if (racer.HasPermission)
            {
                participants?.Add(racer);
                messenger.Send("Racer added", "RacerInfo");
            } else MessageBox.Show("The selected racer doesn't have permission to participate!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void RemoveFromRace(Racer racer)
        {
            participants?.Remove(racer);
            messenger.Send("Racer removed", "RacerInfo");
        }

        public void ShowDetails(Racer racer)
        {
            new RacerDataWindow(racer).Show();
        }

        public void SaveRace()
        {
            string path = "PéldaVerseny_" + DateTime.Today.ToString("ddMMyyyy") + ".json";
            string jsonContent = JsonConvert.SerializeObject(participants, Formatting.Indented);

            File.WriteAllText(path, jsonContent);
            MessageBox.Show($"Race saved to {path}", "Race Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
