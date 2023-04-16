using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWorkshop4.Models
{
    public class Racer
    {
        public string Name { get; set; }
        public double PB { get; set; }
        public double YB { get; set; }
        public bool HasPermission { get; set; }
        public string Club { get; set; }
        public int Number { get; set; }
        public double MarketValue 
        { 
            get 
            {
                return Math.Round(PB * YB, 2);    
            } 
        }

        public Racer(string name, double pb, double yb, bool haspermission, string club, int number)
        {
            Name = name;
            PB = pb;
            YB = yb;
            HasPermission = haspermission;
            Club = club;
            Number = number;
        }
    }
}
