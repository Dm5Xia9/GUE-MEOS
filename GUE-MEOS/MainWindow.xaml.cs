using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GUE_MEOS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        Topology topology;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PClick(object sender, RoutedEventArgs e)
        {
            if (topology.DetectBoolSet && topology.NumP != 4 && topology.DetectGrafCord)
            {

                CreateMenu creatMenu = new CreateMenu(this);

                topology.NumP++;
                topology.Num++;

                topology.FMenuSet[topology.Num - 1] = new Menu();
                topology.FMenuSet[topology.Num - 1] = creatMenu.PMenu(topology, "x");

                CordPlos.Children.Add(topology.FMenuSet[topology.Num - 1]);

                topology.Num++;

                topology.FMenuSet[topology.Num - 1] = new Menu();
                topology.FMenuSet[topology.Num - 1] = creatMenu.PMenu(topology, "y");

                CordPlos.Children.Add(topology.FMenuSet[topology.Num - 1]);

            }
            else if (!topology.DetectBoolSet)
            {
                for (int i = 0; i < topology.Num; i++)
                    CordPlos.Children.Add(topology.FMenuSet[i]);
                topology.DetectBoolSet = true;
            }
        }
        private void FClick(object sender, RoutedEventArgs e)
        {
            if (topology.DetectBoolSet && topology.NumF != 4 && topology.DetectGrafCord)
            {
                CreateMenu creatMenu = new CreateMenu(this);

                topology.NumF++;
                topology.Num++;

                topology.FMenuSet[topology.Num - 1] = new Menu();
                topology.FMenuSet[topology.Num - 1] = creatMenu.FMenu(topology);
                
                CordPlos.Children.Add(topology.FMenuSet[topology.Num - 1]);

                topology.NumClickF = false;
            }
            else if (!topology.DetectBoolSet)
            {
                for (int i = 0; i < topology.Num; i++)
                    CordPlos.Children.Add(topology.FMenuSet[i]);

                topology.DetectBoolSet = true;
            }
        }
        private void CordPlos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < topology.FMenuSet.Length; i++)
                CordPlos.Children.Remove(topology.FMenuSet[i]);

            topology.DetectBoolSet = false;
        }
        public void GrafDeckCreate(Topology _topology)
        {
            GrafCord grafCord = new GrafCord();

            topology = _topology;

            StyleMenu();

            topology.DetectGrafCord = true;

            CordPlos = grafCord.Cord(CordPlos.ActualHeight, CordPlos.ActualWidth, CordPlos);
        }
        private void StyleMenu()
        {
            topology.TopPanelSetting = (Style)FindResource("TopPanelSetting");
            topology.ButtonTopPanel = (Style)FindResource("ButtonTopPanel");
            topology.TextBoxStyle = (Style)FindResource("TextBoxStyle");
        }
        public void TextBoxF_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < topology.NumF; i++)
            {
                Paint paint = new Paint();

                topology.textCheckF[i] = new TextCheck();

                CordPlos = paint.PaintGrafF(topology, CordPlos, i);
            }
        }
        public void TextBoxPX_TextChanged(object sender, TextChangedEventArgs e)
        {
            for(int i = 0; i < topology.NumP; i++)
            {
                Paint paint = new Paint();

            }
        }
        public void TextBoxPY_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void CreateGraf_click(object sender, RoutedEventArgs e)
        {
            CreateGraf taskWindow = new CreateGraf(this);

            taskWindow.Owner = this;

            taskWindow.Show();
        }


    }
}
