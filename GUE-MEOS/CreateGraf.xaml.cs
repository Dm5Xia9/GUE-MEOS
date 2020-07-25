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
using System.Windows.Shapes;

namespace GUE_MEOS
{
    /// <summary>
    /// Логика взаимодействия для CreateGraf.xaml
    /// </summary>
    public partial class CreateGraf : Window
    {
        //Объект класса с гравным окном
        MainWindow mainWindow;
        Topology topology = new Topology(4);
        
        public CreateGraf(MainWindow f)
        {
            InitializeComponent();
            //Задание актуальной версии окна
            mainWindow = f;
            //задание параметров по умолчанию
            NameGraf.Text = "Без-имени1";
            HeightGraf.Text = "1000";
            WidthGraf.Text = "4";
        }

        private void CreateGrafOk_Click(object sender, RoutedEventArgs e)
        {
            if(DeckSystemCord.IsSelected == true)
            {
                topology.NameGraf = NameGraf.Text;
                topology.HeightGraf = Convert.ToInt32(HeightGraf.Text);
                topology.WidthGraf = Convert.ToInt32(WidthGraf.Text);

                //вызов функции для отрисовки декатовых координат
                mainWindow.GrafDeckCreate(topology);
                //Закрытие окна с созданием графика
                this.Close();
            }
            else if(PolarSystemCord.IsSelected == true)
            {
                ColorGraf.Text = "Полярные";
            }
            else
            {
                ColorGraf.Text = "Никакие";
            }
        }
    }
}
