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

            //Animaciones permanentes
            animacPermanentes("AnimacionFuegos");
            

            ocultarSalud();
            ocultarEstrellas();

            pgSalud.Value = 100;
            pgEnergia.Value = 100;
            pgMana.Value = 100;

            tim = new DispatcherTimer();
            tim.Interval = TimeSpan.FromMilliseconds(milli_seconds);
            tim.Tick += (sender, e) => clock(sender, (EventArgs)e);
            tim.Start();
        }

        /// <summary>
        /// Clock que realiza las tareas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clock(object sender, EventArgs e)
        {
            pgSalud.Value -= salud;
            pgEnergia.Value -= energia;
            pgMana.Value -= mana;

            gestionNiveles();

            //Perdemos una vez los valores llegan a 0 :)
            if (pgSalud.Value == 0 || pgEnergia.Value == 0 || pgMana.Value == 0)
            {
                btnSalud.IsEnabled = false;
                btnEnergia.IsEnabled = false;
                btnMana.IsEnabled = false;

                salud = 0; energia = 0; mana = 0;
                tim.Stop();

                //Evento al morir


            }
            else if (puntos_conseguidos >= 850) //El jugador/a gana
            {
                //MessageBox
            }

        }

        /// <summary>
        /// Gestión de niveles + upgrades de progreso
        /// </summary>
        private void gestionNiveles()
        {
            if (puntos_conseguidos < 40)
            {
                nivel = 0;

                salud = 1.6;
                energia = 1.6;
                mana = 1.6;
            }

            if (puntos_conseguidos >= 40 && puntos_conseguidos < 80 && !realizadoF1)
            {
                puntos_conseguidos += 15;
                lanzarAnimacion("AnimacionNivel", 3);
                txtNivel.Text = "1";
                //Lanzar animación Nivel Visual
                realizadoF1 = true;
            }

            if (puntos_conseguidos >= 90 && puntos_conseguidos < 200 && !realizadoF2)
            {
                puntos_conseguidos += 25;
                //Lanzar animación Nivel Visual
                realizadoF2 = true;
            }

            if (puntos_conseguidos >= 125 && puntos_conseguidos < 600 && !realizadoF3)
            {
                puntos_conseguidos += 30;
                lanzarAnimacion("AnimacionNivel", 3);
                txtNivel.Text = "2";
                //Lanzar animación Nivel Visual
                realizadoF3 = true;
            }

            if (puntos_conseguidos >= 320 && puntos_conseguidos < 650 && !realizadoF4)
            {
                lanzarAnimacion("AnimacionNivel", 3);
                txtNivel.Text = "3";
                //Lanzar animación Nivel Visual
                realizadoF4 = true;
            }

            if (puntos_conseguidos >= 420 && puntos_conseguidos < 720 && !realizadoF5)
            {
                puntos_conseguidos += 40;
                lanzarAnimacion("AnimacionNivel", 3);
                txtNivel.Text = "4";
                //Lanzar animación Nivel Visual
                realizadoF5 = true;
            }

            if (puntos_conseguidos >= 520 && puntos_conseguidos < 800 && !realizadoF6)
            {
                puntos_conseguidos += 40;
                lanzarAnimacion("AnimacionNivel", 3);
                txtNivel.Text = "5";
                //Lanzar animación Nivel Visual
                realizadoF6 = true;
            }

            if (puntos_conseguidos >= 850 && !realizadoF7)
            {
                puntos_conseguidos += 50;
                lanzarAnimacion("AnimacionNivel", 3);
                txtNivel.Text = "6";
                //Lanzar animación Nivel Visual
                realizadoF7 = true;
            }
        }

        /// <summary>
        /// Asigna los puntos según el nivél
        /// </summary>
        private void asignarPuntosBoton()
        {
            switch (nivel)
            {
                case 0:
                    puntos_conseguidos += 10;
                    break;
                case 1:
                    puntos_conseguidos += 20;
                    break;
                case 2 | 3:
                    puntos_conseguidos += 40;
                    break;
                case 4 | 6 | 7:
                    puntos_conseguidos += 40;
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Click en botón salud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalud_Click(object sender, RoutedEventArgs e)
        {
            asignarPuntosBoton();
            this.pgSalud.Value += 25;

            mostrarSalud();
            deshabilitarBotones();
            lanzarAnimacion("AnimacionPgVida", 2);
            lanzarAnimacion("AnimacionSalud", 2);
        }

        /// <summary>
        /// Encargado de lanzar la animación
        /// dada con el número de repeticiones
        /// que ha sido proporcionado
        /// </summary>
        /// <param name="animacion"></param>
        /// <param name="repeticiones"></param>
        private void lanzarAnimacion(String animacion, int repeticiones)
        {
            Storyboard sb = (Storyboard)FindName(animacion);
            if (sb != null)
            {
                sb.RepeatBehavior = new RepeatBehavior(repeticiones);
                sb.Begin();
            }
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
        /// Habilitar botones
        /// </summary>
        private void habilitarBotones()
        {
            btnSalud.IsEnabled = true;
            btnEnergia.IsEnabled = true;
            btnMana.IsEnabled = true;
        }

        /// <summary>
        /// Al presionar la poción de energía
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnergia_Click(object sender, RoutedEventArgs e)
        {
            asignarPuntosBoton();
            this.pgEnergia.Value += 28;

            mostrarEstrellas();
            deshabilitarBotones();
            lanzarAnimacion("AnimacionOjos", 2);
            lanzarAnimacion("AnimacionPgEnergia", 2);
            lanzarAnimacion("AnimacionEstrellitas", 3);
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
        /// Evento al pulsar la poción
        /// que se corresponde al maná
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMana_Click(object sender, RoutedEventArgs e)
        {
            asignarPuntosBoton();
            this.pgMana.Value += 25;

            deshabilitarBotones();
            lanzarAnimacion("AnimacionPgMana", 2);
            lanzarAnimacion("AnimacionMana", 3);

            visibleLogro();
            txtLogro.Text = "Ganas 10 puntos";
            lanzarAnimacion("AnimacionLogro", 1);
        }

        /// <summary>
        /// Hace visible el logro
        /// </summary>
        private void visibleLogro()
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
        /// Cuando se completa la animación del logro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimacionLogro_Completed(object sender, object e)
        {
            OcultarLogro();
        }

        /// <summary>
        /// Habilitar botones
        /// </summary>
        private void deshabilitarBotones()
        {
            btnSalud.IsEnabled = false;
            btnEnergia.IsEnabled = false;
            btnMana.IsEnabled = false;
        }

        
        /// <summary>
        /// Hace visible los path de salud
        /// </summary>
        private void mostrarSalud()
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
        private void ocultarSalud()
        {
            this.salud1.Visibility = Visibility.Collapsed;
            this.salud2.Visibility = Visibility.Collapsed;
            this.salud3.Visibility = Visibility.Collapsed;
            this.salud4.Visibility = Visibility.Collapsed;
            this.salud5.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Mostrar estrellas
        /// </summary>
        private void mostrarEstrellas()
        {
            this.estrella1.Visibility = Visibility.Visible;
            this.estrella2.Visibility = Visibility.Visible;
            this.estrella3.Visibility = Visibility.Visible;
            this.estrella4.Visibility = Visibility.Visible;
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
        /// Lanza animaciones permanentes
        /// </summary>
        /// <param name="nombre"></param>
        private void animacPermanentes(String nombre)
        {
            Storyboard sbA = (Storyboard)FindName(nombre);
            if (sbA != null)
            {
                sbA.RepeatBehavior = RepeatBehavior.Forever;
                sbA.Begin();
            }
        }



    }
}
