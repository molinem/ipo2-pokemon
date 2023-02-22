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
using Windows.UI.Xaml.Navigation;

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
            
        }

        public void centerPage() 
        {
            // Obtener el tamaño de la pantalla y la ventana
            var bounds = Window.Current.Bounds;
            var viewBounds = ApplicationView.GetForCurrentView().VisibleBounds;

            // Calcular la posición del centro
            var centerX = viewBounds.Left + (viewBounds.Width - bounds.Width) / 2;
            var centerY = viewBounds.Top + (viewBounds.Height - bounds.Height) / 2;

            // Establecer la posición del elemento para que se centre
            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.VerticalAlignment = VerticalAlignment.Center;

            // Establecer la posición de la página para que se centre
            this.Margin = new Thickness(centerX, centerY, 0, 0);
        }
    }
}
