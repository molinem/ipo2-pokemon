using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace pokemon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer tHealth;
        DispatcherTimer tEnergy;


        public MainPage()
        {
            this.InitializeComponent();
        }

        

        private void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 0.4;
            if (pbHealth.Value >= 100)
            {
                this.tHealth.Stop();
                this.imgHealth.Opacity = 1;
            }
        }

        private void increaseEnergy(object sender, object e)
        {
            this.pbEnergy.Value += 0.4;

            if (this.imgEnergy.Opacity == 1)
            {
                this.imgEnergy.Opacity = 0.5;
            }
            else
            {
                this.imgEnergy.Opacity = 1;
            }
            
            if (pbEnergy.Value >= 100)
            {
                this.tEnergy.Stop();
                this.imgEnergy.Opacity = 1;
            }
        }

        private void btnHealth_Click(object sender, RoutedEventArgs e)
        {
            tHealth = new DispatcherTimer();
            tHealth.Interval = TimeSpan.FromMilliseconds(100);
            tHealth.Tick += increaseHealth;
            tHealth.Start();
            this.imgHealth.Opacity = 0.5;
        }

        private void btnEnergy_Click(object sender, RoutedEventArgs e)
        {
            tEnergy = new DispatcherTimer();
            tEnergy.Interval = TimeSpan.FromMilliseconds(100);
            tEnergy.Tick += increaseEnergy;
            tEnergy.Start();
            this.imgEnergy.Opacity = 0.5;
        }

        
    }
}
