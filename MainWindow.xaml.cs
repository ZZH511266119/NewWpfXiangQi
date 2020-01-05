using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public View view = new View();
        bool startIsClick = false;//所有点击事件必须是“开始游戏”键按完以后才可以触发       
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            CreateGridWithBoard();
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            if(startIsClick == false)
            {
                startIsClick = true;
                Message.Text = "Red Player";
                RedrawGrid();
            }
        }

        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            if (startIsClick == true)
            {
                view.game.color = "red";
                grid.ColumnDefinitions.Clear();
                grid.RowDefinitions.Clear();
                grid.Children.Clear();
                CreateGridWithBoard();
                Message.Text = "Red Player";
                RedrawGrid();
            }
        }

        private void Restart()
        {
            if (startIsClick == true)
            {
                view.game.color = "red";
                grid.ColumnDefinitions.Clear();
                grid.RowDefinitions.Clear();
                grid.Children.Clear();
                CreateGridWithBoard();
                Message.Text = "";
                startIsClick = false;
            }
        }

        public void CreateGridWithBoard()//here
        {

            ImageBrush b3 = new ImageBrush();
            b3.ImageSource = new BitmapImage(new Uri("C:/Users/周志航/Desktop/问题/WPFImage/WPFImage/Board/Board.jpg", UriKind.Relative));
            b3.Stretch = Stretch.Fill;
            grid.Background = b3;
            view.game.controller.InitializeBorad();
            for (int i = 0; i <= 8; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int j = 0; j <= 9; j++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int row = 0; row <= 9; row++)
            {
                for (int col = 0; col <= 8; col++)
                {
                    Button button = new Button();
                    button.SetValue(XQRowProperty, row);
                    button.SetValue(XQColProperty, col);
                    button.Click += Button_Click;
                    //button.Click += AI;
                    button.BorderBrush = Brushes.Transparent; //按钮边框透明
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    grid.Children.Add(button);
                }
            }


        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int btnRow = (int)((Button)sender).GetValue(XQRowProperty);
            int btnCol = (int)((Button)sender).GetValue(XQColProperty);


            if (view.game.state == "move" && view.game.controller.board[btnRow, btnCol].GetName() == "将" && startIsClick == true)
            {
                if (view.game.WhoWin())
                {
                    HandleClick(btnRow, btnCol);
                    MessageBox.Show("Game over, black player win! Press button restart the game.");
                    Restart();
                }
                else
                {
                    HandleClick(btnRow, btnCol);
                    MessageBox.Show("Game over, red player win! Press button restart the game.");
                    Restart();
                }
            }

            else if(startIsClick == true)
            {
                HandleClick(btnRow, btnCol);
                WhoToPlay();
            }

        }

        private void AI(object sender, RoutedEventArgs e)
        {
            if (view.game.color == "black")
            {
                RedrawGrid();
                view.AIinput();
                view.game.SwitchPlayer();
                RedrawGrid();
            }
        }

        public static readonly DependencyProperty XQRowProperty =
            DependencyProperty.Register("XQRow", typeof(int), typeof(Button));

        public static readonly DependencyProperty XQColProperty =
            DependencyProperty.Register("XQCol", typeof(int), typeof(Button));

        public void RedrawGrid()
        {
            int z = 0;
            foreach (Piece i in view.game.controller.board)
            {
                Button btnSelected = (Button)grid.Children[z];
                btnSelected.SetValue(BackgroundProperty, null);
                btnSelected.SetValue(BackgroundProperty, Brushes.Transparent);
                if (i.GetName() == "nochess")
                {

                    ImageBrush brushEmpty = new ImageBrush();
                    brushEmpty.ImageSource = new BitmapImage(new Uri(i.GetImage(), UriKind.Relative));
                    btnSelected.SetValue(BackgroundProperty, brushEmpty);

                }
                else
                {

                    if (i.GetColor() == "red")
                    {
                        ImageBrush brushRed = new ImageBrush();
                        brushRed.ImageSource = new BitmapImage(new Uri(i.GetImage(), UriKind.Relative));
                        btnSelected.Background = brushRed;
                        btnSelected.SetValue(BackgroundProperty, brushRed);

                    }
                    else if (i.GetColor() == "black")
                    {
                        ImageBrush brushBlack = new ImageBrush();
                        brushBlack.ImageSource = new BitmapImage(new Uri(i.GetImage(), UriKind.Relative));
                        btnSelected.Background = brushBlack;
                        btnSelected.SetValue(BackgroundProperty, brushBlack);
                    }
                }
                if (i.canGo == true)
                {
                    if (i.GetName() == "nochess")
                    {
                        ImageBrush brushGo = new ImageBrush();
                        brushGo.ImageSource = new BitmapImage(new Uri("C:/Users/周志航/Desktop/问题/WPFImage//WPFImage/Chess/OOS.gif", UriKind.Relative));
                        btnSelected.Background = brushGo;
                    }
                    else
                    {
                        ImageBrush brushEat = new ImageBrush();
                        brushEat.ImageSource = new BitmapImage(new Uri(i.GetImageEat(), UriKind.Relative));
                        btnSelected.Background = brushEat;
                    }
                }
                z++;
            }

        }

        public void HandleClick(int row, int col)//here
        {
            
            switch (view.game.state)
            {
                case "choose":
                    try
                    {
                        view.PlayerChoose(row, col);
                        view.game.ChangeState();
                    }
                    catch (MyException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "move":
                    try
                    {
                        view.PlayerMove(row, col);
                        view.game.ChangeState();
                        view.game.SwitchPlayer();
                    }
                    catch (MyException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

            }
            /**
            if(view.game.color == "red")
            {
                switch (view.game.state)
                {
                    case "choose":
                        try
                        {
                            view.PlayerChoose(row, col);
                            view.game.ChangeState();
                        }
                        catch (MyException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    case "move":
                        try
                        {
                            view.PlayerMove(row, col);
                            view.game.ChangeState();
                            view.game.SwitchPlayer();
                        }
                        catch (MyException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                }
            }
            **/
            RedrawGrid();
        }

        public void WhoToPlay()
        {
            switch (view.game.color)
            {
                case "red":
                    Message.Text = "Red Player";
                    break;

                case "black":
                    Message.Text = "Black Player";
                    break;
            }
        }


    }
}
