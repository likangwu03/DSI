using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_DSI_G7;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
namespace Trabajo_DSI_G7.Input
{

    internal class MainMenuGameLoop
    {
        //Manejar el Timer
        public DispatcherTimer GameTimer;
        Pages.MainMenu MiPagina = null;
       // Controlador MiControl = null;

        public MainMenuGameLoop(Pages.MainMenu Pagina)
        {
            MiPagina = Pagina;
          //  MiControl = Control;
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Tick += GameTimer_Tick;// dispatcherTimer_Tick;
            GameTimer.Interval = new TimeSpan(100000); //100000*10^-7s=1cs;

        }
        void GameTimer_Tick(object sender, object e)
        {   //Los Drones se simulan a nivel de aplicación cada 0.1s
            if (MiPagina != null)
            {
               
                    //MiControl.LeeMando();                      //Lee GamePAd
                    //MiControl.DetectaGestosMando();            //Detecta Gestos del Mando
                    //MiControl.ZMMando();                       //ZonaMuerta JoyStick y Triggers
                    //MiPagina.AplicaGesto();                    //Aplica Gestos en IU
                    //MiPagina.AplicaTecladoContinuo();          //Aplica Teclado continuo en IU
                    //MiPagina.ActualizaIU();                    //Aplica cambios en IU y VM
                    //MiControl.FeedBack();                      //Activa motores del Mando
                
            }
        }
    }

}
