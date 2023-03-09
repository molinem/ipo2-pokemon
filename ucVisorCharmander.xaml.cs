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
using Windows.UI.Xaml.Media.Animation;
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
        /// Hace visible los path de salud
        /// </summary>
        public void mostrarSalud()
        {
            this.salud1.Visibility = Visibility.Visible;
            this.salud2.Visibility = Visibility.Visible;
            this.salud3.Visibility = Visibility.Visible;
            this.salud4.Visibility = Visibility.Visible;
            this.salud5.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Oculta los path de salud
        /// </summary>
        public void ocultarSalud()
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
        public void habilitarBotones()
        {
            btnSalud.IsEnabled = true;
            btnEnergia.IsEnabled = true;
            btnMana.IsEnabled = true;
        }

        /// <summary>
        /// Habilitar botones
        /// </summary>
        public void deshabilitarBotones()
        {
            btnSalud.IsEnabled = false;
            btnEnergia.IsEnabled = false;
            btnMana.IsEnabled = false;
        }

        /// <summary>
        /// Mostrar estrellas
        /// </summary>
        public void mostrarEstrellas()
        {
            this.estrella1.Visibility = Visibility.Visible;
            this.estrella2.Visibility = Visibility.Visible;
            this.estrella3.Visibility = Visibility.Visible;
            this.estrella4.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Ocultar estrellas
        /// </summary>
        public void ocultarEstrellas()
        {
            this.estrella1.Visibility = Visibility.Collapsed;
            this.estrella2.Visibility = Visibility.Collapsed;
            this.estrella3.Visibility = Visibility.Collapsed;
            this.estrella4.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Hace visible el logro
        /// </summary>
        public void visibleLogro()
        {
            this.rectangle.Visibility = Visibility.Visible;
            this.pokBase.Visibility = Visibility.Visible;
            this.path10.Visibility = Visibility.Visible;
            this.path11.Visibility = Visibility.Visible;
            this.pokBoton.Visibility = Visibility.Visible;
            this.pokBoton2.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Oculta los elementos del logro
        /// </summary>
        public void OcultarLogro()
        {
            this.rectangle.Visibility = Visibility.Collapsed;
            this.pokBase.Visibility = Visibility.Collapsed;
            this.path10.Visibility = Visibility.Collapsed;
            this.path11.Visibility = Visibility.Collapsed;
            this.pokBoton.Visibility = Visibility.Collapsed;
            this.pokBoton2.Visibility = Visibility.Collapsed;
            this.txtLogro.Visibility = Visibility.Collapsed;
        }


        //----------------------------------------
        //              ProgressBar
        //----------------------------------------

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


        //----------------------------------------
        //              storyBoard
        //----------------------------------------

        /// <summary>
        /// Getter/Setter Storyboard AnimacionFuego
        /// </summary>
        public Storyboard animFuegos
        {
            get { return this.AnimacionFuegos; }
            set { this.AnimacionFuegos = value; }
        }

        /// <summary>
        /// Getter/Setter Storyboard AnimacionNivel
        /// </summary>
        public Storyboard animNivel
        {
            get { return this.AnimacionNivel; }
            set { this.AnimacionNivel = value; }
        }

        /// <summary>
        /// Getter/Setter Storyboard AnimacionLogro
        /// </summary>
        public Storyboard animLogro
        {
            get { return this.AnimacionLogro; }
            set { this.AnimacionLogro = value; }
        }

        /// <summary>
        /// Getter/Setter Storyboard AnimacionSalud
        /// </summary>
        public Storyboard animSalud
        {
            get { return this.AnimacionSalud; }
            set { this.AnimacionSalud = value; }
        }

        /// <summary>
        /// Getter/Setter Storyboard AnimacionEstrellas
        /// </summary>
        public Storyboard animEstrellas
        {
            get { return this.AnimacionEstrellitas; }
            set { this.AnimacionEstrellitas = value; }
        }

        /// <summary>
        /// Getter/Setter Storyboard AnimacionMana
        /// </summary>
        public Storyboard animMana
        {
            get { return this.AnimacionMana; }
            set { this.animMana = value; }
        }

        /// <summary>
        /// Getter/Setter Storyboard AnimacionPgVida
        /// </summary>
        public Storyboard animPgVida
        {
            get { return this.AnimacionPgVida; }
            set { this.AnimacionPgVida = value; }
        }

        /// <summary>
        /// Getter/Setter Storyboard AnimacionPgEnergia
        /// </summary>
        public Storyboard animPgEnergia
        {
            get { return this.AnimacionPgEnergia; }
            set { this.AnimacionPgEnergia = value; }
        }

        /// <summary>
        /// Getter/Setter Storyboard AnimacionPgMana
        /// </summary>
        public Storyboard animPgMana
        {
            get { return this.AnimacionPgMana; }
            set { this.AnimacionPgMana = value; }
        }

        //----------------------------------------
        //              BUTTONS
        //----------------------------------------

        /// <summary>
        /// Getter/Setter Button Salud
        /// </summary>
        public Button buttonSalud
        {
            get { return this.btnSalud; }
            set { this.btnSalud = value; }
        }

        /// <summary>
        /// Getter/Setter Button Energía
        /// </summary>
        public Button buttonEnergia
        {
            get { return this.btnEnergia; }
            set { this.btnEnergia = value; }
        }

        /// <summary>
        /// Getter/Setter Button Mana
        /// </summary>
        public Button buttonMana
        {
            get { return this.btnMana; }
            set { this.btnMana = value; }
        }

        //----------------------------------------
        //              TextBox
        //----------------------------------------

        /// <summary>
        /// Getter/Setter TextBox Nivel
        /// </summary>
        public TextBox txNivel
        {
            get { return this.txtNivel; }
            set { this.txtNivel = value; }
        }

        /// <summary>
        /// Getter/Setter TextBox logro
        /// </summary>
        public TextBox txLogro
        {
            get { return this.txtLogro; }
            set { this.txtLogro = value; }
        }
    }

    
}
