using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUE_MEOS
{
    class Topology
    {
        //рисовать график на участке от:
        public int CauntTextOt = 20;
        //до:
        public int CauntTextDo = -20;
        //Созданы декатовы координаты?
        public bool DeckBool = false;
        //Название графика
        public string NameGraf = "Оаоааоаоао";
        //Ширина графика
        public int HeightGraf;
        //Длинна графика
        public int WidthGraf;
        //Можно ли вывести меню с вводом функции? 
        public bool NumClickF = true;
        public DoubleCollection StrokeDashArray = new DoubleCollection() { 2, 3 };
        public int Format = 10;
    }
}
