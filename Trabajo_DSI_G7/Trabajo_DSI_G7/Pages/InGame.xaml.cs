using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Trabajo_DSI_G7.Game;
using Trabajo_DSI_G7;
using Trabajo_DSI_G7.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

using Windows.UI.Xaml.Navigation;
using Windows.UI;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Animation;
using static System.Net.WebRequestMethods;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Trabajo_DSI_G7.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class InGame : Page
    {
        static Random random = new Random();
        public ObservableCollection<CardVM> unusedCards { set; get; } = new ObservableCollection<CardVM>();//de la lista
        public ObservableCollection<CardVM> usedCards { set; get; } = new ObservableCollection<CardVM>(); //de la lista
        public List<int> cardId { set; get; } //de la lista

        GameManager GM = null;
        public InGame()
        {

            this.InitializeComponent();
            //Play_Confirmation_Dialog.XamlRoot = this.XamlRoot;
            
        }

        private void iniciaLizeEnemies()
        {
            createEnemy(Enemy1,0);
            createEnemy(Enemy2,1);
            createEnemy(Enemy3,2);
        }

        private void createEnemy(StackPanel enemy,int i)
        {
            EnemyVM enem = GM.getEnemy(i);
            Image img = new Image();
            img.Source = enem.Img.Source;
            //img.Width = 180;
            //img.Height = 180;
            img.HorizontalAlignment = HorizontalAlignment.Center;
            img.VerticalAlignment = VerticalAlignment.Center;
            img.Margin = new Thickness(10);

            ProgressBar pb = new ProgressBar();
            pb.HorizontalAlignment = HorizontalAlignment.Stretch;
            pb.Foreground = new SolidColorBrush(Colors.Red);
            pb.Background = new SolidColorBrush(Colors.White);
            pb.Height = 15;
            pb.CornerRadius = new CornerRadius(5);
            pb.Value = enem.ActLife;
            pb.Maximum = enem.MaxLife;

           // Ellipse e=new Ellipse();
           // e.Width = 200;
           // e.Height = 40;
           // e.Margin = new Thickness(20);
           // e.Fill = new SolidColorBrush(Colors.White);
           //e.HorizontalAlignment = HorizontalAlignment.Center;
           //e.VerticalAlignment = VerticalAlignment.Bottom;
           // e.Fill.Opacity = 40;


            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.Margin = new Thickness(10);
            tb.FontSize =20;
           // tb.Style= (Style)Application.Current.FindResource("myStyle");
            tb.Text = $"{enem.ActLife}/{enem.MaxLife}";
          //  tb.Style = Application.Current.Resources["ThemeText"] as Style;

            enemy.Children.Add(img);
            enemy.Children.Add(pb);
            enemy.Children.Add(tb);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e?.Parameter is GameManager gm)
                this.GM = gm;

            base.OnNavigatedTo(e);
           GM.copyCards( unusedCards);
            iniciaLizeEnemies();
            inicializeCard();
        }
        private void inicializeCard()
        {
            if (unusedCards.Count() < 5)  reinicializeCard();
            
          else for(int i=0; i < 5; i++) drawCard(i);
            
        }
        private void reinicializeCard()
        {
            GM.copyCards( unusedCards);
        }
        private void drawCard(int i)
        {
            CardVM card = unusedCards.ElementAt(random.Next(0, unusedCards.Count()));
            (Cards.Children[i] as ContentControl).Width = 200;
            (Cards.Children[i] as ContentControl).HorizontalAlignment = HorizontalAlignment.Center;
            (Cards.Children[i] as ContentControl).VerticalAlignment = VerticalAlignment.Bottom;
            (Cards.Children[i] as ContentControl).RenderTransformOrigin= new Point(0.5,1);
            (Cards.Children[i] as ContentControl).CanDrag = true;
           ((Cards.Children[i] as ContentControl).Content as Image).Source = card.Img.Source;
            unusedCards.Remove(card);

        }
        private void onButtonHolding(object sender, PointerRoutedEventArgs e)
        {
            Image img = (sender as Button).Content as Image;

            ((sender as Button).Content as Image).Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\Assets\\ui\\button_hover\\" + img.Name + "_hover.png"));

        }

        private void onButtonExit(object sender, PointerRoutedEventArgs e)
        {
            Image img = (sender as Button).Content as Image;

            ((sender as Button).Content as Image).Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\Assets\\ui\\button_yellow/" + img.Name + ".png"));
        }

        private async void OnSaveAndExitClick(object sender, RoutedEventArgs e)
        {
            InGameOptions.Hide();
            ConfirmMenu.XamlRoot = this.Content.XamlRoot;
            await ConfirmMenu.ShowAsync();
        }

        private void OnRestartGameClick(object sender, RoutedEventArgs e)
        {
            ConfirmMenu.Hide();
            InGameOptions.Hide();
            Frame.Navigate(typeof(InGame), GM);
        }

        private void OnConfirmExitClick(object sender, RoutedEventArgs e)
        {
            if (!Frame.CanGoBack) return;
            ConfirmMenu.Hide();
            InGameOptions.Hide();
            Frame.GoBack();
        }

        private void OnConfirmCancelClick(object sender, RoutedEventArgs e)
        {
            ConfirmMenu.Hide();

        }

        private async void OnSettingClick(object sender, RoutedEventArgs e)
        {
            InGameOptions.XamlRoot = this.Content.XamlRoot;
            await InGameOptions.ShowAsync();
        }

        private void OnExitSettingClick(object sender, RoutedEventArgs e)
        {
            InGameOptions.Hide();
        }
    }
}
