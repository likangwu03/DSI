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
using Windows.ApplicationModel.DataTransfer;
using System.Collections;
using System.Reflection;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using Windows.System;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Trabajo_DSI_G7.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class InGame : Page
    {
        static Random random = new Random();
        public ObservableCollection<CardVM> unusedCards { set; get; } = new ObservableCollection<CardVM>();
        public ObservableCollection<CardVM> usedCards { set; get; } = new ObservableCollection<CardVM>();
        public ObservableCollection<CardVM> usingCards { set; get; } = new ObservableCollection<CardVM>();
        public ObservableCollection<EnemyVM> enemies { set; get; } = new ObservableCollection<EnemyVM>();
        public List<int> cardId { set; get; } //de la lista

        private int[] potionsId = { 0, 1, 2 }; //índice de pociones usados para el juego
        public ObservableCollection<PotionVM> inventory { set; get; } = new ObservableCollection<PotionVM>();
        struct CardPosition
        {
            private Thickness margin;
            private float rotation;
            public CardPosition(Thickness margin, float rotation)
            {
                this.margin = margin;
                this.rotation = rotation;
            }
            public Thickness Margin { get { return margin; } }
            public float Rotation { get { return rotation; } }
        };

        private CardPosition[][] cardPosition = new CardPosition[5][]
        {
           new CardPosition[]{
               new CardPosition(new Thickness(0,0,0,0),0),
           },
           new CardPosition[] {
                new CardPosition(new Thickness(0, 0, -100, -20), -8) ,
               new CardPosition(new Thickness(0,0,-100,-20),8)
           },
           new CardPosition[] {
                new CardPosition(new Thickness(0,0,-100,-10), -10) ,
               new CardPosition(new Thickness(0,0,0,10),0),
               new CardPosition(new Thickness(-100,0,0,-10),10)
           },
           new CardPosition[]{
                new CardPosition(new Thickness(0, 0, -100, -20), -14) ,
               new CardPosition(new Thickness(0,0,-50,0),-7),
               new CardPosition(new Thickness(-50,0,0,0),7),
               new CardPosition(new Thickness(-100,0,0,-20),14)
           },
            new CardPosition[] {
               new CardPosition(new Thickness(0, 0, -100, -20), -18) ,
               new CardPosition(new Thickness(0,0,-100,0),-9),
               new CardPosition(new Thickness(0,0,0,10),0),
               new CardPosition(new Thickness(-100,0,0,0),9),
               new CardPosition(new Thickness(-100,0,0,-20),18)
            }


        };
        const float CARD_W = 200;
        int actEnergy;
        int actMagic;
        int actLife;
        ContentControl selectedCard;
        Button selectedPotion;

        GameManager GM = null;
        public InGame()
        {

            this.InitializeComponent();
            //Play_Confirmation_Dialog.XamlRoot = this.XamlRoot;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e?.Parameter is GameManager gm)
                this.GM = gm;

            base.OnNavigatedTo(e);
            restartGame();
        }

        void restartGame()
        {
            selectedCard = null;
            selectedPotion = null;
            Cards.Children.Clear();
            GM.copyCards(unusedCards);
            reinicializeEnemies();
            iniciaLizeEnemies();
            inicializeCard();
            iniciaLizePotions();
            inicializeCost();
        }

        //indicador de energía y magia
        private void inicializeCost()
        {
            actEnergy = GM.maxEnergy;
            Energy.Text = $"{actEnergy}/{GM.maxEnergy}";
            Energy.Foreground = new SolidColorBrush(Colors.White);
            actMagic = GM.maxMagic;
            actLife = GM.maxLife;
            Magic.Text = $"{actMagic}/{GM.maxMagic}";
            Magic.Foreground = new SolidColorBrush(Colors.White);
        }
        //ENEMIGOS...........................................................................................
        private void iniciaLizeEnemies()
        {
            GM.copyEnemies(enemies);//hacer copiar desde GM

            createEnemy(Enemy1, 0);
            createEnemy(Enemy2, 1);
            createEnemy(Enemy3, 2);
        }

        void reinicializeEnemies()
        {
            for (int i = 0; i < Enemies.Children.Count; ++i)
            {
                ((Enemies.Children[i] as ContentControl).Content as StackPanel).Opacity = 1;
                ((Enemies.Children[i] as ContentControl).Content as StackPanel).Children.Clear();
            }
            enemies.Clear();

        }
        //crear enemigos como content control para ser mostrado en xaml
        private void createEnemy(StackPanel enemy, int i)
        {
            enemy.Name = "Enemy" + (i + 1);
            EnemyVM enem = enemies[i];
            StackPanel abilStack = new StackPanel();
            StackPanel enemInfoStack = new StackPanel();
            enemInfoStack.Orientation = Orientation.Horizontal;
            abilStack.Orientation = Orientation.Vertical;

            foreach (AbilityVM abil in enem.Abilities) //cargar habilidades
            {

                Image a = new Image();
                a.Source = abil.Img.Source;
                a.Width = 30;
                a.Height = 30;
                a.HorizontalAlignment = HorizontalAlignment.Center;
                a.VerticalAlignment = VerticalAlignment.Center;
                a.Margin = new Thickness(0, 3, -15, 3);
                abilStack.Children.Add(a);

            }

            enemInfoStack.Children.Add(abilStack);

            enemInfoStack.HorizontalAlignment = HorizontalAlignment.Center;
            enemInfoStack.VerticalAlignment = VerticalAlignment.Center;

            Grid grid = new Grid();
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;

            Ellipse e = new Ellipse();
            e.Height = 30;
            e.Width = 180;
            e.Fill = new SolidColorBrush(Colors.AliceBlue);
            e.VerticalAlignment = VerticalAlignment.Bottom;
            e.Margin = new Thickness(0, 0, 0, 10);
            e.Visibility = Visibility.Collapsed;
            grid.Children.Add(e);


            Image img = new Image();
            img.Source = enem.Img.Source;
            img.Width = 180;
            img.Height = 180;

            img.Margin = new Thickness(10);

            grid.Children.Add(img);

            enemInfoStack.Children.Add(grid);

            //barra vida
            ProgressBar pb = new ProgressBar();
            pb.HorizontalAlignment = HorizontalAlignment.Stretch;
            pb.Foreground = new SolidColorBrush(Colors.Red);
            pb.Background = new SolidColorBrush(Colors.White);
            pb.Height = 15;
            pb.CornerRadius = new CornerRadius(5);
            pb.Value = enem.ActLife;
            pb.Maximum = enem.MaxLife;

            //número vida
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.Margin = new Thickness(10);
            tb.FontSize = 20;

            tb.Text = $"{enem.ActLife} / {enem.MaxLife}";
            tb.Style = Application.Current.Resources["ThemeText"] as Style;

            enemy.Children.Add(enemInfoStack);
            enemy.Children.Add(pb);
            enemy.Children.Add(tb);
        }
        //al trasladar un obj sobre el enemigo
        private async void DragOverOnEnemy(object sender, DragEventArgs e)
        {
            var Oname = await e.DataView.GetTextAsync(); //obtiene la id

            if ((((FindName(Oname.ToString())) as Button)?.Parent as Grid)?.Parent as StackPanel == Inventory || ((FindName(Oname.ToString())) as ContentControl)?.Parent == Cards)
            {
                e.AcceptedOperation = DataPackageOperation.Link;

                ((((sender as StackPanel)?.Children[0] as StackPanel)?.Children[1] as Grid)?.Children[0] as Ellipse).Visibility = Visibility.Visible;
            }

        }
        private async void DropOnEnemy(object sender, DragEventArgs e)
        {
            var Oname = await e.DataView.GetTextAsync(); //obtiene la id

            if ((((FindName(Oname.ToString())) as Button)?.Parent as Grid)?.Parent as StackPanel == Inventory)
                usePotion((FindName(Oname.ToString())) as Button, sender as StackPanel);

            else if (((FindName(Oname.ToString())) as ContentControl)?.Parent == Cards)
                useCard(((FindName(Oname.ToString())) as ContentControl));

            ((((sender as StackPanel)?.Children[0] as StackPanel)?.Children[1] as Grid)?.Children[0] as Ellipse).Visibility = Visibility.Collapsed;
        }
        private void EnemyGettingFocus(UIElement sender, GettingFocusEventArgs args)
        {
            (((((sender as ContentControl).Content as StackPanel)?.Children[0] as StackPanel)?.Children[1] as Grid)?.Children[0] as Ellipse).Visibility = Visibility.Visible;

        }
        private void Enemy_LosingFocus(UIElement sender, LosingFocusEventArgs args)
        {
            (((((sender as ContentControl).Content as StackPanel)?.Children[0] as StackPanel)?.Children[1] as Grid)?.Children[0] as Ellipse).Visibility = Visibility.Collapsed;

        }
        private void OnEnemyKeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.OriginalKey)
            {
                case VirtualKey.GamepadA:
                    if (selectedCard != null)
                    {
                        useCard(selectedCard);
                        selectedCard = null;
                    }
                    else if (selectedPotion != null)
                    {
                        usePotion(selectedPotion, (sender as ContentControl).Content as StackPanel);
                        selectedPotion = null;
                    }
                    break;
                case VirtualKey.GamepadB:
                    if (selectedCard != null)
                    {
                        (sender as ContentControl).Focus(FocusState.Unfocused);
                        selectedCard = null;
                    }
                    if (selectedPotion != null)
                    {
                        (sender as ContentControl).Focus(FocusState.Unfocused);
                        selectedPotion = null;
                    }
                    break;

            }
        }
        private void EnemyDragLeave(object sender, DragEventArgs e)
        {
            ((((sender as StackPanel)?.Children[0] as StackPanel)?.Children[1] as Grid)?.Children[0] as Ellipse).Visibility = Visibility.Collapsed;
        }

        private void Enemies_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.GamepadRightShoulder)
            {
                (FocusManager.FindFirstFocusableElement(Inventory) as Button).Focus(FocusState.Programmatic);
            }
            else if (e.OriginalKey == VirtualKey.GamepadLeftShoulder)
            {
                (FocusManager.FindFirstFocusableElement(Top_Buttons) as Button).Focus(FocusState.Programmatic);
            }
        }

        //POCIONES...........................................................................................
        private void iniciaLizePotions()
        {
            for (int i = 0; i < potionsId.Length; i++)
            {
                PotionVM potion = GM.getPotion(i);
                inventory.Add(potion);
                (((Inventory.Children[i] as Grid).Children[0] as Button).Content as Image).Source = inventory[i].Img.Source;
                if (potion.Amount <= 0)
                    ((Inventory.Children[i] as Grid).Children[0] as Button).IsEnabled = false;
                (((Inventory.Children[i] as Grid).Children[1] as Grid).Children[1] as TextBlock).Text = potion.Amount.ToString();
            }
        }
        private void PotionDragStarting(UIElement sender, DragStartingEventArgs args)
        {
            Button button = (sender as Image).Parent as Button;
            string id = button.Name.ToString();
            args.Data.SetText(id);
            args.Data.RequestedOperation = DataPackageOperation.Link;
        }
        //usar una poción
        private void usePotion(Button button, StackPanel stackPanel)
        {
            string enemyName = stackPanel.Name.ToString();
            EnemyVM enemy = enemies[enemyName[5] - '0' - 1];
            string buttonName = button.Name.ToString();
            enemy.ActLife -= inventory[(buttonName[6]) - '0' - 1].Attack;

            inventory[(buttonName[6]) - '0' - 1].Amount--; //disminuye cantidad de pociones

            (((Inventory.Children[(buttonName[6]) - '0' - 1] as Grid).Children[1] as Grid).Children[1] as TextBlock).Text = inventory[(buttonName[6]) - '0' - 1].Amount.ToString();

            if (inventory[(buttonName[6]) - '0' - 1].Amount <= 0) //si ya no quedan pociones
            {
                button.IsEnabled = false;
                (button.Content as Image).Opacity = 0.5;
            }
            if (enemy.ActLife <= 0)
                stackPanel.Opacity = 0; //no se ve pero sigue reservando espacio
            else
            {
                (stackPanel.Children[1] as ProgressBar).Value = enemy.ActLife;
                (stackPanel.Children[2] as TextBlock).Text = $"{enemy.ActLife} / {enemy.MaxLife}";
            }
            selectedPotion = null;

        } //Button es del inventario y Stackpanel,contenedor de enemigo

        private void Potion_Click(object sender, RoutedEventArgs e)
        {
            selectedPotion = sender as Button; //pocion elegida
            ContentControl Enem = FocusManager.FindFirstFocusableElement(Enemies) as ContentControl;
            Enem.Focus(FocusState.Programmatic);
        }

        private void Inventory_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.GamepadRightShoulder)
            {
                (FocusManager.FindFirstFocusableElement(Cards) as ContentControl).Focus(FocusState.Programmatic);
            }
            else if (e.OriginalKey == VirtualKey.GamepadLeftShoulder)
            {
                ContentControl Enem = FocusManager.FindFirstFocusableElement(Enemies) as ContentControl;
                Enem.Focus(FocusState.Programmatic);
            }
        }

        //CARTAS..............................................................................................
        private void inicializeCard()
        {
            unusedCards.Clear();
            usedCards.Clear();
            usingCards.Clear();

            GM.copyCards(unusedCards);
            for (int i = 0; i < 5; i++) drawCard(i);

        }

        //usar una carta
        private void useCard(ContentControl CC) //CC es la carta
        {
            CardVM card = usingCards[Cards.Children.IndexOf(CC)];

            //Comprueba y actualiza Energía/Magia
            if (card.Type == CostType.Magic)
            {
                if (actMagic - card.Cost < 0) return;
                else
                {
                    if (actMagic - card.Cost == 0)
                        Magic.Foreground = new SolidColorBrush(Colors.Red);
                    actMagic -= card.Cost;
                    Magic.Text = $"{actMagic}/{GM.maxMagic}";
                }
            }
            else if (card.Type == CostType.Energy)
            {
                if (actEnergy - card.Cost < 0) return;
                else
                {
                    if (actEnergy - card.Cost == 0)
                        Energy.Foreground = new SolidColorBrush(Colors.Red);
                    actEnergy -= card.Cost;
                    Energy.Text = $"{actEnergy}/{GM.maxEnergy}";
                }
            }

            //Borrar de las cartas actuales
            Cards.Children.Remove(CC);
            usingCards.Remove(card);

            //añadirlo a la pila de descartes
            usedCards.Add(card);

            //reposicionar cartas
            if (usingCards.Count > 0)
            {
                repositionateCards();
            }

        }

        // Coger 5 cartas
        private void drawCard(int i)
        {

            CardVM card = unusedCards.ElementAt(random.Next(0, unusedCards.Count()));
            ContentControl CC = new ContentControl();
            CC.Name = "Card" + (i + 1);
            CC.DragStarting += CardDragStarting;
            CC.UseSystemFocusVisuals = true;
            CC.IsTabStop = true;
            CC.PointerEntered += CardPointOver;
            CC.PointerExited += CardPointerExit;

            CC.GotFocus += CC_GotFocus;
            CC.LosingFocus += CC_LosingFocus;
            CC.FocusVisualMargin = new Thickness(100);
            CC.KeyDown += CC_KeyDown;

            //ContentControl CC = Cards.Children[i] as ContentControl;
            CC.Width = CARD_W;
            CC.HorizontalAlignment = HorizontalAlignment.Center;
            CC.VerticalAlignment = VerticalAlignment.Bottom;
            CC.RenderTransformOrigin = new Point(0.5, 1);
            CC.CanDrag = true;
            CC.Margin = cardPosition[4][i].Margin;

            CompositeTransform Transformacion = new CompositeTransform();
            Transformacion.TranslateX = 0.0;
            Transformacion.TranslateY = 0.0;
            Transformacion.Rotation = cardPosition[4][i].Rotation;
            CC.RenderTransform = Transformacion;

            Image image = new Image();
            image.Source = card.Img.Source;

            CC.Content = image;
            Cards.Children.Add(CC);
            // ((Cards.Children[i] as ContentControl).Content as Image).Source = card.Img.Source;

            unusedCards.Remove(card);
            usingCards.Add(card);

        }
        //mover a la lista de cartas usadas (pila de descartes)
        private void addToUsedCard()
        {
            int count = usingCards.Count;
            for (int i = 0; i < count; i++)
            {
                CardVM card = usingCards[i];
                usedCards.Add(card);
            }
            usingCards.Clear();
            Cards.Children.Clear();
        }
        //añadir 5 nuevas cartas para usar en el turno actual
        private void addNewCards()
        {
            if (unusedCards.Count < 5) //si ya no hay cartas suficientes en el mazo de cartas, se mueven de la pila de descartes
            {
                int count = usedCards.Count;
                for (var i = 0; i < count; i++)
                {
                    CardVM card = usedCards[i];
                    unusedCards.Add(card);
                }
                usedCards.Clear();
            }
            for (int j = 0; j < 5; j++) drawCard(j); //coge 5 cartas
        }
        private void CardDragStarting(UIElement sender, DragStartingEventArgs args)
        {
            ContentControl CC = sender as ContentControl;
            string id = CC.Name.ToString();
            args.Data.SetText(id);
            args.Data.RequestedOperation = DataPackageOperation.Link;
        }

        //mover sobre las cartas
        private void CardPointOver(object sender, PointerRoutedEventArgs e)
        {

            ContentControl CC = sender as ContentControl;
            CC.Width = 250;
            //(CC.Content as Image).Opacity = 0.5;
        }

        private void CardPointerExit(object sender, PointerRoutedEventArgs e)
        {
            ContentControl CC = sender as ContentControl;
            CC.Width = CARD_W;
            // (CC.Content as Image).Opacity = 1;
        }

        //para mando
        private void CC_GotFocus(object sender, RoutedEventArgs e)
        {
            ContentControl CC = sender as ContentControl;
            CC.Width = 250;
        }
        //para mando
        private void CC_LosingFocus(UIElement sender, LosingFocusEventArgs args)
        {
            ContentControl CC = sender as ContentControl;
            CC.Width = CARD_W;
        }

        //pasar foco de carta a enemigo
        private void CC_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.GamepadA)
            {
                selectedCard = sender as ContentControl; //carta elegida
                ContentControl Enem = FocusManager.FindFirstFocusableElement(Enemies) as ContentControl;
                Enem.Focus(FocusState.Programmatic);
            }
        }
        private void Carts_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.GamepadRightShoulder)
            {
                (FocusManager.FindFirstFocusableElement(Bottom_Buttons) as Button).Focus(FocusState.Programmatic);
            }
            else if (e.OriginalKey == VirtualKey.GamepadLeftShoulder)
            {
                (FocusManager.FindFirstFocusableElement(Inventory) as Button).Focus(FocusState.Programmatic);
            }
        }

        //reposicionar las cartas al cambiar su cantidad
        void repositionateCards()
        {
            for (int i = 0; i < Cards.Children.Count; i++)
            {
                ContentControl CC = Cards.Children[i] as ContentControl;
                CompositeTransform Transformacion = new CompositeTransform();
                Transformacion.TranslateX = 0.0;
                Transformacion.TranslateY = 0.0;
                Transformacion.Rotation = cardPosition[Cards.Children.Count - 1][i].Rotation;
                CC.Margin = cardPosition[Cards.Children.Count - 1][i].Margin;
                CC.RenderTransform = Transformacion;
            }

        }

        //al pusar el botón de finalizar turno
        private void OnFinishTurnClick(object sender, RoutedEventArgs e)
        {
            addToUsedCard();
            addNewCards();
            //Reiniciar Energía
            Energy.Foreground = new SolidColorBrush(Colors.White);
            Magic.Foreground = new SolidColorBrush(Colors.White);
            actEnergy = GM.maxEnergy;
            Energy.Text = $"{actEnergy}/{GM.maxEnergy}";
            GM.playClickedSound();
        }

        //UI.........................................................................................

        //para cambio de imágenes al estar sobre un botón
        private void onButtonHolding(object sender, PointerRoutedEventArgs e)
        {
            Image img = (sender as Button).Content as Image;

            ((sender as Button).Content as Image).Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\Assets\\ui\\button_hover\\" + img.Name + "_hover.png"));

        }

        //al alejarse de un botón
        private void onButtonExit(object sender, PointerRoutedEventArgs e)
        {
            Image img = (sender as Button).Content as Image;

            ((sender as Button).Content as Image).Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\Assets\\ui\\button_yellow/" + img.Name + ".png"));
        }
        //al pulsar sobre el botón de querer salir de la partida
        private async void OnSaveAndExitClick(object sender, RoutedEventArgs e)
        {
            GM.playClickedSound();
            InGameOptions.Hide();
            ConfirmMenu.XamlRoot = this.Content.XamlRoot;
            await ConfirmMenu.ShowAsync();
        }
        //para botón de reempezar partida
        private void OnRestartGameClick(object sender, RoutedEventArgs e)
        {
            GM.playClickedSound();
            ConfirmMenu.Hide();
            InGameOptions.Hide();
            restartGame();
        }

        //confirmación de salir de la partida
        private void OnConfirmExitClick(object sender, RoutedEventArgs e)
        {
            GM.playClickedSound();
            if (!Frame.CanGoBack) return;
            ConfirmMenu.Hide();
            InGameOptions.Hide();
            Frame.GoBack();
        }

        //cancelación de salir de partida
        private void OnConfirmCancelClick(object sender, RoutedEventArgs e)
        {
            ConfirmMenu.Hide();
            GM.playClickedSound();
        }

        //entrar en el menú de opciones
        private async void OnSettingClick(object sender, RoutedEventArgs e)
        {
            GM.playClickedSound();
            InGameOptions.XamlRoot = this.Content.XamlRoot;
            await InGameOptions.ShowAsync();
        }
        //salir del menú de opciones
        private void OnExitSettingClick(object sender, RoutedEventArgs e)
        {
            InGameOptions.Hide();
            GM.playClickedSound();
        }

        private void Page_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.GamepadLeftThumbstickRight)
            {
                FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                e.Handled = true;

            }
            else if (e.OriginalKey == VirtualKey.GamepadLeftThumbstickLeft)
            {
                FocusManager.TryMoveFocus(FocusNavigationDirection.Previous);
                e.Handled = true;
            }
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }



        private void Top_Right_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.GamepadRightShoulder)
            {
                ContentControl Enem = FocusManager.FindFirstFocusableElement(Enemies) as ContentControl;
                Enem.Focus(FocusState.Programmatic);
            }
            else if (e.OriginalKey == VirtualKey.GamepadLeftShoulder)
            {
                (FocusManager.FindFirstFocusableElement(Bottom_Buttons) as Button).Focus(FocusState.Programmatic);
            }
        }

      

        private void Bottom_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == VirtualKey.GamepadRightShoulder)
            {
                (FocusManager.FindFirstFocusableElement(Top_Buttons) as Button).Focus(FocusState.Programmatic);
            }
            else if (e.OriginalKey == VirtualKey.GamepadLeftShoulder)
            {
                (FocusManager.FindFirstFocusableElement(Cards) as ContentControl).Focus(FocusState.Programmatic);
            }
        }

       
    }
}
