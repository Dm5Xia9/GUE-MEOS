using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUE_MEOS
{
    public class Topology
    {
        public string NameGraf { get; set; }
        public int HeightGraf { get; set; }
        public int WidthGraf { get; set; }
        public bool NumClickF { get; set; } = true;
        public int Format { get; set; } = 10;
        public TextCheck[] textCheckF { get; set; }
        public TextCheck[] textCheckP { get; set; }
        public TextBox[] TextBoxF { get; set; }
        public TextBox[] TextBoxOtF { get; set; }
        public TextBox[] TextBoxDoF { get; set; }
        public TextBox[] TextBoxColorF { get; set; }
        public TextBox[] TextBoxThicknessF { get; set; }
        public TextBox[] TextBoxPX { get; set; }
        public TextBox[] TextBoxPY { get; set; }
        public TextBox[] TextBoxOtP { get; set; }
        public TextBox[] TextBoxDoP { get; set; }
        public TextBox[] TextBoxColorP { get; set; }
        public TextBox[] TextBoxThicknessP { get; set; }
        public Menu[] FMenuSet { get; set; }
        public Polyline[] Graf { get; set; }
        public int NumF { get; set; } = 0;
        public int NumP { get; set; } = 0;
        public int Num { get; set; } = 0;
        public bool DetectBoolSet { get; set; } = true;
        public bool DetectGrafCord { get; set; } = false;
        public bool[] kio { get; set; }
        public Style TopPanelSetting { get; set; }
        public Style ButtonTopPanel { get; set; }
        public Style TextBoxStyle { get; set; }
        public Topology() { }
        public Topology(int num)
        {
            textCheckF = new TextCheck[num];
            textCheckP = new TextCheck[num];
            TextBoxF = new TextBox[num];
            TextBoxOtF = new TextBox[num];
            TextBoxDoF = new TextBox[num];
            TextBoxColorF = new TextBox[num];
            TextBoxThicknessF = new TextBox[num];
            TextBoxPX = new TextBox[num];
            TextBoxPY = new TextBox[num];
            TextBoxOtP = new TextBox[num];
            TextBoxDoP = new TextBox[num];
            TextBoxColorP = new TextBox[num];
            TextBoxThicknessP = new TextBox[num];
            FMenuSet = new Menu[num*4];
            Graf = new Polyline[num];
            kio = new bool[num];
            for (int i = 0; i < num; i++) { Graf[i] = new Polyline(); kio[i] = true; }
            
        }
    }
}
