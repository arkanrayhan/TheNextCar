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
using System.Windows.Navigation;
using System.Windows.Shapes;
using The_Next_Car.Controller;

namespace The_Next_Car
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        private Car nextCar;
        public MainWindow()
        {
            InitializeComponent();

            AccuBatteryController accuBatteryController = new AccuBatteryController(this);
            DoorController doorController = new DoorController(this);

            nextCar = new Car (accuBatteryController, doorController, this);
        }

        private void carEngineStatusChanged (string val, string msg)
        {
            Status.Content = msg;
            StartButton.Content = val;
        }

        private void doorSecurityChanged(string val, string msg)
        {
            this.LockDoorState.Content = msg;
            this.LockDoorButton.Content = val;
        }

        private void doorStatusChanged(string val, string msg)
        {
            this.DoorOpenState.Content = msg;
            this.DoorOpenButton.Content = val;
        }

        private void onPowerChangedStatus(string val, string msg)
        {
            this.AccuState.Content = msg;
            this.AccuButton.Content = val;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleStartEngineButton ();
        }

        private void DoorOpenButton_Click(object sender, RoutedEventArgs e)
        { 
            this.nextCar.toggleTheDoorButton ();
        }

        private void LockDoorButton_Click(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheLockDoorButton ();
        }

        private void AccuButton_Click(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleThePowerButton ();
        }

    }
}
