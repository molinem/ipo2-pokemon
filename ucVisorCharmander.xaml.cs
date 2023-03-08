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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace PokeApp
{
    public sealed partial class ucVisorCharmander : UserControl
    {
        public ucVisorCharmander()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Oculta los path de salud
        /// </summary>
        private void ocultarSalud()
        {
            this.salud1.Visibility = Visibility.Collapsed;
            this.salud2.Visibility = Visibility.Collapsed;
            this.salud3.Visibility = Visibility.Collapsed;
            this.salud4.Visibility = Visibility.Collapsed;
            this.salud5.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Habilitar botones
        /// </summary>
        private void habilitarBotones()
        {
            btnSalud.IsEnabled = true;
            btnEnergia.IsEnabled = true;
            btnMana.IsEnabled = true;
        }

        /// <summary>
        /// Cuando la animación de salud es completada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimacionSalud_Completed(object sender, object e)
        {
            ocultarSalud();
            habilitarBotones();
        }

        /// <summary>
        /// Ocultar estrellas
        /// </summary>
        private void ocultarEstrellas()
        {
            this.estrella1.Visibility = Visibility.Collapsed;
            this.estrella2.Visibility = Visibility.Collapsed;
            this.estrella3.Visibility = Visibility.Collapsed;
            this.estrella4.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Cuando se completa la 
        /// animación de estrellas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimacionEstrellas_Completed(object sender, object e)
        {
            ocultarEstrellas();
            habilitarBotones();
        }

        /// <summary>
        /// Cuando se completa la 
        /// animación del maná
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimacionMana_Completed(object sender, object e)
        {
            habilitarBotones();
        }

        /// <summary>
        /// Oculta los elementos del logro
        /// </summary>
        private void OcultarLogro()
        {
            this.rectangle.Visibility = Visibility.Collapsed;
            this.pokBase.Visibility = Visibility.Collapsed;
            this.path10.Visibility = Visibility.Collapsed;
            this.path11.Visibility = Visibility.Collapsed;
            this.pokBoton.Visibility = Visibility.Collapsed;
            this.pokBoton2.Visibility = Visibility.Collapsed;
            this.txtLogro.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Cuando se completa la animación del logro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimacionLogro_Completed(object sender, object e)
        {
            OcultarLogro();
        }

        private void btnSalud_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEnergia_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMana_Click(object sender, RoutedEventArgs e)
        {

        }

        
        /// <summary>
        /// Getter/ setter atributo pgSalud
        /// </summary>
        public double salud
        {
            get { return this.pgSalud.Value; }
            set { this.pgSalud.Value = value; }
        }

        /// <summary>
        /// Getter/setter atributo pgEnergia
        /// </summary>
        public double energia
        {
            get { return this.pgEnergia.Value; }
            set { this.pgEnergia.Value = value; }
        }

        /// <summary>
        /// Getter/setter atributo pgMana
        /// </summary>
        public double mana
        {
            get { return this.pgMana.Value; }
            set { this.pgMana.Value = value; }
        }

    }

    
}
