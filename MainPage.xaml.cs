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
using System.Threading.Tasks;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PokeApp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Timer
        DispatcherTimer tim;
        int milli_seconds = 1000;

        //Value progress bar
        double salud = 1.2;
        double energia = 1.3;
        double mana = 1.4;

        //Nivel
        int nivel = 0;

        //Puntos totales conseguidos
        int puntos_conseguidos = 0;

        //Control para saber si se alcanza cierto punto
        bool realizadoF1, realizadoF2, realizadoF3, realizadoF4, realizadoF5, realizadoF6, realizadoF7 = false;

        /// <summary>
        /// Método principal
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            
        }

 

    }
}
