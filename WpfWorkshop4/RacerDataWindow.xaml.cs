using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfWorkshop4.Models;
using WpfWorkshop4.ViewModels;

namespace WpfWorkshop4
{
    /// <summary>
    /// Interaction logic for RacerDataWindow.xaml
    /// </summary>
    public partial class RacerDataWindow : Window
    {
        public RacerDataWindow(Racer racer)
        {
            InitializeComponent();
            DataContext = new RacerDetailViewModel();
            (DataContext as RacerDetailViewModel)?.Setup(racer);
        }
    }
}
