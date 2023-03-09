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
            animacPermanentes(ucVisorCharmander.animFuegos);
            
            //progressBar values
            ucVisorCharmander.salud = 100;
            ucVisorCharmander.energia = 100;
            ucVisorCharmander.mana = 100;

            //DispatcherTimer
            tim = new DispatcherTimer();
            tim.Interval = TimeSpan.FromMilliseconds(milli_seconds);
            tim.Tick += (sender, e) => clock(sender, (EventArgs)e);
            tim.Start();

            //Link buttons click event
            ucVisorCharmander.buttonSalud.Click += btnSalud_Click;
            ucVisorCharmander.buttonEnergia.Click += btnEnergia_Click;
            ucVisorCharmander.buttonMana.Click += btnMana_Click;

            //Event completed animaciones
            ucVisorCharmander.animSalud.Completed += AnimSalud_Completed;
            ucVisorCharmander.animEstrellas.Completed += AnimEstrellas_Completed;
            ucVisorCharmander.animMana.Completed += AnimMana_Completed;
            ucVisorCharmander.animLogro.Completed += AnimLogro_Completed;

        }

        /// <summary>
        /// Cuando la animación de salud es completada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimSalud_Completed(object sender, object e)
        {
            ucVisorCharmander.ocultarSalud();
            ucVisorCharmander.habilitarBotones();
        }

        /// <summary>
        /// Cuando se completa la 
        /// animación del maná
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimMana_Completed(object sender, object e)
        {
            ucVisorCharmander.habilitarBotones();
        }

        /// <summary>
        /// Cuando se completa la 
        /// animación de estrellas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimEstrellas_Completed(object sender, object e)
        {
            ucVisorCharmander.ocultarEstrellas();
            ucVisorCharmander.habilitarBotones();
        }

        /// <summary>
        /// Cuando se completa la animación del logro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimLogro_Completed(object sender, object e)
        {
            ucVisorCharmander.OcultarLogro();
        }

        /// <summary>
        /// Clock que realiza las tareas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clock(object sender, EventArgs e)
        {
            ucVisorCharmander.salud -= salud;
            ucVisorCharmander.energia -= energia;
            ucVisorCharmander.mana -= mana;

            gestionNiveles();

            //Perdemos una vez los valores llegan a 0 :)
            if (ucVisorCharmander.salud == 0 || ucVisorCharmander.energia == 0 || ucVisorCharmander.mana == 0)
            {
                ucVisorCharmander.buttonSalud.IsEnabled = false;
                ucVisorCharmander.buttonEnergia.IsEnabled = false;
                ucVisorCharmander.buttonMana.IsEnabled = false;

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
                lanzarAnimacion(ucVisorCharmander.animNivel, 3);
                ucVisorCharmander.txNivel.Text = "1";
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
                lanzarAnimacion(ucVisorCharmander.animNivel, 3);
                ucVisorCharmander.txNivel.Text = "2";
                realizadoF3 = true;
            }

            if (puntos_conseguidos >= 320 && puntos_conseguidos < 650 && !realizadoF4)
            {
                lanzarAnimacion(ucVisorCharmander.animNivel, 3);
                ucVisorCharmander.txNivel.Text = "3";
                //Lanzar animación Nivel Visual
                realizadoF4 = true;
            }

            if (puntos_conseguidos >= 420 && puntos_conseguidos < 720 && !realizadoF5)
            {
                puntos_conseguidos += 40;
                lanzarAnimacion(ucVisorCharmander.animNivel, 3);
                ucVisorCharmander.txNivel.Text = "4";
                //Lanzar animación Nivel Visual
                realizadoF5 = true;
            }

            if (puntos_conseguidos >= 520 && puntos_conseguidos < 800 && !realizadoF6)
            {
                puntos_conseguidos += 40;
                lanzarAnimacion(ucVisorCharmander.animNivel, 3);
                ucVisorCharmander.txNivel.Text = "5";
                //Lanzar animación Nivel Visual
                realizadoF6 = true;
            }

            if (puntos_conseguidos >= 850 && !realizadoF7)
            {
                puntos_conseguidos += 50;
                lanzarAnimacion(ucVisorCharmander.animNivel, 3);
                ucVisorCharmander.txNivel.Text = "6";
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
        /// Encargado de lanzar la animación
        /// dada con el número de repeticiones
        /// que ha sido proporcionado
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="repeticiones"></param>
        private void lanzarAnimacion(Storyboard sb, int repeticiones)
        {
            if (sb != null)
            {
                sb.RepeatBehavior = new RepeatBehavior(repeticiones);
                sb.Begin();
            }
        }

        /// <summary>
        /// Lanza animaciones permanentes
        /// </summary>
        /// <param storyBoard="sbA"></param>
        private void animacPermanentes(Storyboard sbA)
        {
            if (sbA != null)
            {
                sbA.RepeatBehavior = RepeatBehavior.Forever;
                sbA.Begin();
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
            ucVisorCharmander.salud += 25;

            ucVisorCharmander.mostrarSalud();
            ucVisorCharmander.deshabilitarBotones();
            lanzarAnimacion(ucVisorCharmander.animPgVida, 2);
            lanzarAnimacion(ucVisorCharmander.animSalud, 2);
        }

        /// <summary>
        /// Al presionar la poción de energía
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnergia_Click(object sender, RoutedEventArgs e)
        {
            asignarPuntosBoton();
            ucVisorCharmander.energia += 28;

            ucVisorCharmander.mostrarEstrellas();
            ucVisorCharmander.deshabilitarBotones();
            lanzarAnimacion(ucVisorCharmander.animPgEnergia, 2);
            lanzarAnimacion(ucVisorCharmander.animEstrellas, 3);
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
            ucVisorCharmander.mana += 25;

            ucVisorCharmander.deshabilitarBotones();
            lanzarAnimacion(ucVisorCharmander.animPgMana, 2);
            lanzarAnimacion(ucVisorCharmander.animMana, 3);
        }
    }
}
