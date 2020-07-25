using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GUE_MEOS
{
    class Paint
    {
        public Canvas PaintGrafF(Topology topology, Canvas CordPlos, int NumI)
        {
            List<double> ResOtv = topology.textCheckF[NumI].Tex(topology.TextBoxF[NumI].Text, Convert.ToInt32(topology.TextBoxOtF[NumI].Text), Convert.ToInt32(topology.TextBoxDoF[NumI].Text), "F");

            topology.Graf[NumI].Points.Clear();

            topology.Graf[NumI].StrokeThickness = Convert.ToInt32(topology.TextBoxThicknessF[NumI].Text);
            topology.Graf[NumI].StrokeLineJoin = PenLineJoin.Round;

            for (int i = 0; i < ResOtv.Count; i++)
            {
                topology.Graf[NumI].Points.Add(new Point(-20 * topology.Format + i * topology.Format + CordPlos.ActualWidth / 2, CordPlos.ActualHeight / 2 - ResOtv[i] * topology.Format));
            }

            
            topology.Graf[NumI].Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + topology.TextBoxColorF[NumI].Text));

            if (topology.kio[NumI])
                CordPlos.Children.Add(topology.Graf[NumI]);

            topology.kio[NumI] = false;

            return CordPlos;
        }

        public Canvas PaintGrafP(Topology topology, Canvas CordPlos, int NumI)
        {
            List<double> ResOtv = topology.textCheckP[NumI].Tex(topology.TextBoxF[NumI].Text, Convert.ToInt32(topology.TextBoxOtF[NumI].Text), Convert.ToInt32(topology.TextBoxDoF[NumI].Text), "F");

            topology.Graf[NumI].Points.Clear();

            topology.Graf[NumI].StrokeThickness = Convert.ToInt32(topology.TextBoxThicknessF[NumI].Text);
            topology.Graf[NumI].StrokeLineJoin = PenLineJoin.Round;

            for (int i = 0; i < ResOtv.Count; i++)
            {
                topology.Graf[NumI].Points.Add(new Point(-20 * topology.Format + i * topology.Format + CordPlos.ActualWidth / 2, CordPlos.ActualHeight / 2 - ResOtv[i] * topology.Format));
            }


            topology.Graf[NumI].Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + topology.TextBoxColorF[NumI].Text));

            if (topology.kio[NumI])
                CordPlos.Children.Add(topology.Graf[NumI]);

            topology.kio[NumI] = false;

            return CordPlos;
        }
    }
}
