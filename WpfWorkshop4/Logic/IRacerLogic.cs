using System.Collections.Generic;
using WpfWorkshop4.Models;

namespace WpfWorkshop4.Logic
{
    public interface IRacerLogic
    {
        void AddToRace(Racer racer);
        void RemoveFromRace(Racer racer);
        void SetupCollections(IList<Racer> racers, IList<Racer> participants);
        void LoadRacers();
    }
}