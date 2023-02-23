using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using System.Windows;
using System.Runtime;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CharmanderApp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            animacColaFuego();
            animacCuadro();
            ocultarSalud();
        }

        
        private void ocultarSalud()
        {
            this.salud1.Visibility = Visibility.Collapsed;
            this.salud2.Visibility = Visibility.Collapsed;
            this.salud3.Visibility = Visibility.Collapsed;
            this.salud4.Visibility = Visibility.Collapsed;
            this.salud5.Visibility = Visibility.Collapsed;
        }

        
        private void animacColaFuego() 
        {
            Storyboard sb = (Storyboard)FindName("AnimacionFuego");
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }

        private void animacCuadro()
        {
            Storyboard sb = (Storyboard)FindName("AnimacionCuadro");
           // Storyboard sb = (Storyboard)FindName("AnimacionNivel");
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }


        private void btnSalud_Click(object sender, RoutedEventArgs e)
        {
            this.salud1.Visibility = Visibility.Visible;
            this.salud2.Visibility = Visibility.Visible;
            this.salud3.Visibility = Visibility.Visible;
            this.salud4.Visibility = Visibility.Visible;
            this.salud5.Visibility = Visibility.Visible;
            Storyboard sb = (Storyboard)FindName("AnimacionSalud");
            sb.RepeatBehavior = new RepeatBehavior(7);
            sb.Begin();
        }

        private void AnimacionSalud_Completed(object sender, object e)
        {
            ocultarSalud();
        }
    }
}
