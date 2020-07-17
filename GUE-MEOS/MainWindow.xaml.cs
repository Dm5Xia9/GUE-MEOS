using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System;
using System.Windows.Shapes;

namespace GUE_MEOS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml Ебать ааааааааааааааааа
    /// </summary>
    public partial class MainWindow : Window
    {
        //Объект класса с разметкой и расчетом введеной пользователем функции
        TextCheck textCheck = new TextCheck();
        //Создание объекта класса с панелью ввода функции
        TextBox TextBoxF = new TextBox();
        //Создание объекта класса с топологией программы
        Topology topology = new Topology();

        Polyline Graf = new Polyline();

        bool kio = true;

        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void FClick(object sender, RoutedEventArgs e)
        {
            if (topology.NumClickF)
            {
                Menu MenuSettindCordPlos = new Menu();
                Label LabelF = new Label();

                //Настройка меню
                MenuSettindCordPlos.Style = (Style)FindResource("TopPanelSetting");
                //Настройка дочерних объектов
                LabelF.Content = "f(x) = ";
                LabelF.Style = (Style)FindResource("ButtonTopPanel");
                TextBoxF.Text = "";
                TextBoxF.Style = (Style)FindResource("TextBoxStyle");
                TextBoxF.Width = 200;
                if (topology.DeckBool)
                    TextBoxF.TextChanged += TextBoxF_TextChanged;

                //Добавление дочерних объектов к меню
                MenuSettindCordPlos.Items.Add(LabelF);
                MenuSettindCordPlos.Items.Add(TextBoxF);
                //Вывод меню
                WinCordPlos.Children.Add(MenuSettindCordPlos);
                
                //отлючение возможности нажать на кнопку второй раз
                topology.NumClickF = false;
            }
            


        }
        //метод создания декатовой координатной плоскости
        public void GrafDeckCreate(string NameGraf, int HeightGraf, int WidthGraf)
        {
            //сохранение пользовательский настроек
            topology.DeckBool = true;
            topology.NameGraf = NameGraf;
            topology.HeightGraf = HeightGraf;
            topology.WidthGraf = WidthGraf;
            //Создание объекта класса с создание декатовой координатной плоскости
            GrafCord grafCord = new GrafCord();
            //Обновление canvas с добавление координатной плоскости
            CordPlos = grafCord.Cord(CordPlos.ActualHeight, CordPlos.ActualWidth, CordPlos);
            FFF.Text = Convert.ToString(CordPlos.ActualWidth / 2);
        }

        
        private void TextBoxF_TextChanged(object sender, TextChangedEventArgs e)
        {
            //вызов метода для отрисовки функции
            PaintGraf(textCheck.Tex(TextBoxF.Text));
            
        }
        //метод для отрисовки функции
        private void PaintGraf(List<double> ResOtv)
        {
            //удаление всех точек функции
            Graf.Points.Clear();
            Graf.StrokeThickness = 3;
            Graf.StrokeLineJoin = PenLineJoin.Round;

            //добавление новых точек функции
            for (int i = 0; i < ResOtv.Count; i++)
            {
                Graf.Points.Add(new Point(-20 * topology.Format + i * topology.Format + CordPlos.ActualWidth / 2, CordPlos.ActualHeight / 2 - ResOtv[i] * topology.Format));
            }
            //задание цвета для графика функции
            Graf.Stroke = Brushes.Red;
            if (kio)
            CordPlos.Children.Add(Graf);
            kio = false;
        }
        private void CreateGraf_click(object sender, RoutedEventArgs e)
        {
            //Создание объекта класса с окном для создания графика
            CreateGraf taskWindow = new CreateGraf(this);
            //задание главного окна
            taskWindow.Owner = this;
            //вывод окна
            taskWindow.Show();
        }
        

       

    }
}
