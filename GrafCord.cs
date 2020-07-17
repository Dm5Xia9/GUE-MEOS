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


namespace GUE_MEOS
{
    class GrafCord
    {
       
        public Canvas Cord(double actualHeight, double actualWidth, Canvas CordPlos)
        {
            Line VertLine = new Line();
            Line GorisLine = new Line();
            Topology topology = new Topology();
           

            VertLine.X1 = actualWidth / 2;
            VertLine.X2 = actualWidth / 2;
            VertLine.Y1 = 0;
            VertLine.Y2 = actualHeight;
            VertLine.StrokeThickness = 3;
            VertLine.Stroke = Brushes.White;

            GorisLine.X1 = 0;
            GorisLine.X2 = actualWidth;
            GorisLine.Y1 = actualHeight / 2;
            GorisLine.Y2 = actualHeight / 2;
            GorisLine.StrokeThickness = 3;
            GorisLine.Stroke = Brushes.White;

            for(int i = 1; i <= (actualWidth / 2) / topology.Format; i++)
            {
                Line VertLinePlosRight = new Line();
                VertLinePlosRight.X1 = i * topology.Format + actualWidth / 2;
                VertLinePlosRight.X2 = i * topology.Format + actualWidth / 2;
                VertLinePlosRight.Y1 = 0;
                VertLinePlosRight.Y2 = actualHeight;
                VertLinePlosRight.Stroke = Brushes.White;
                VertLinePlosRight.StrokeDashArray = topology.StrokeDashArray;
                CordPlos.Children.Add(VertLinePlosRight);
            }

            for (int i = 1; i <= (actualWidth / 2) / topology.Format; i++)
            {
                Line VertLinePlosLeft = new Line();
                VertLinePlosLeft.X1 = -i * topology.Format + actualWidth / 2;
                VertLinePlosLeft.X2 = -i * topology.Format + actualWidth / 2;
                VertLinePlosLeft.Y1 = 0;
                VertLinePlosLeft.Y2 = actualHeight;
                VertLinePlosLeft.Stroke = Brushes.White;
                VertLinePlosLeft.StrokeDashArray = topology.StrokeDashArray;
                CordPlos.Children.Add(VertLinePlosLeft);
            }

            for (int i = 1; i <= (actualHeight / 2) / topology.Format; i++)
            {
                Line GorisLinePlosRight = new Line();
                GorisLinePlosRight.X1 = 0;
                GorisLinePlosRight.X2 = actualWidth;
                GorisLinePlosRight.Y1 = i * topology.Format + actualHeight / 2;
                GorisLinePlosRight.Y2 = i * topology.Format + actualHeight / 2;
                GorisLinePlosRight.Stroke = Brushes.White;
                GorisLinePlosRight.StrokeDashArray = topology.StrokeDashArray;
                CordPlos.Children.Add(GorisLinePlosRight);
            }

            for (int i = 1; i <= (actualHeight / 2) / topology.Format; i++)
            {
                Line GorisLinePlosLeft = new Line();
                GorisLinePlosLeft.X1 = 0;
                GorisLinePlosLeft.X2 = actualWidth;
                GorisLinePlosLeft.Y1 = -i * topology.Format + actualHeight / 2;
                GorisLinePlosLeft.Y2 = -i * topology.Format + actualHeight / 2;
                GorisLinePlosLeft.Stroke = Brushes.White;
                GorisLinePlosLeft.StrokeDashArray = topology.StrokeDashArray;
                CordPlos.Children.Add(GorisLinePlosLeft);
            }

            CordPlos.Children.Add(VertLine);
            CordPlos.Children.Add(GorisLine);
            //CordPlos.Children.Add(VertLinePlos);

            
            return CordPlos;
        }
       
        
    }
}
