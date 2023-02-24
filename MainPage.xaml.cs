﻿using System;
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

namespace CharmanderApp
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


        public MainPage()
        {
            this.InitializeComponent();

            //Animaciones permanentes
            animacPermanentes("AnimacionCuadro");
            animacPermanentes("AnimacionFuego");

            ocultarSalud();

            pgSalud.Value = 100;
            pgEnergia.Value = 100;
            pgMana.Value = 100;

            tim = new DispatcherTimer();
            tim.Interval = TimeSpan.FromMilliseconds(milli_seconds);
            tim.Tick += (sender, e) => clock(sender, (EventArgs)e);
            tim.Start();
        }


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

            }

        }

        private void gestionNiveles()
        {
            
        }

        private void btnSalud_Click(object sender, RoutedEventArgs e)
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

            this.pgSalud.Value += 25;

            mostrarSalud();
            deshabilitarBotones();
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
            sb.RepeatBehavior = new RepeatBehavior(repeticiones);
            sb.Begin();
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
        /// Lanza animaciones permanentes
        /// </summary>
        /// <param name="nombre"></param>
        private void animacPermanentes(String nombre)
        {
            Storyboard sb = (Storyboard)FindName(nombre);
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }


        

        
    }
}
