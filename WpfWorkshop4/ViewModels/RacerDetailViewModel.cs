using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWorkshop4.Models;

namespace WpfWorkshop4.ViewModels
{
    internal class RacerDetailViewModel
    {
        public Racer? Actual { get; set; }

        public void Setup(Racer racer) { Actual = racer; }
        public RacerDetailViewModel() { }
    }
}
