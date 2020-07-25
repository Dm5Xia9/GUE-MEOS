using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUE_MEOS
{
    class CreateMenu
    {
        MainWindow mainWindow;
        public CreateMenu(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
        }
        public Menu FMenu(Topology topology)
        {
            Menu MenuSettindCordPlos = new Menu();

            Label LabelF = new Label();
            Label LabelOt = new Label();
            Label LabelDo = new Label();
            Label LabelColor = new Label();
            Label LabelThickness = new Label();

            topology.TextBoxF[topology.NumF - 1] = new TextBox();
            topology.TextBoxOtF[topology.NumF - 1] = new TextBox();
            topology.TextBoxDoF[topology.NumF - 1] = new TextBox();
            topology.TextBoxColorF[topology.NumF - 1] = new TextBox();
            topology.TextBoxThicknessF[topology.NumF - 1] = new TextBox();

            MenuSettindCordPlos.Style = topology.TopPanelSetting;
            MenuSettindCordPlos.Height = 30;

            LabelF.Content = "f(x) = ";
            LabelF.Style = topology.ButtonTopPanel;

            topology.TextBoxF[topology.NumF - 1].Text = "";
            topology.TextBoxF[topology.NumF - 1].Style = topology.TextBoxStyle;
            topology.TextBoxF[topology.NumF - 1].Width = 200;
            topology.TextBoxF[topology.NumF - 1].TextChanged += TextBoxF_TextChanged;

            LabelOt.Content = "От:";
            LabelOt.Style = topology.ButtonTopPanel;

            topology.TextBoxOtF[topology.NumF - 1].Text = "-20";
            topology.TextBoxOtF[topology.NumF - 1].Style = topology.TextBoxStyle;
            topology.TextBoxOtF[topology.NumF - 1].Width = 25;

            LabelDo.Content = "До:";
            LabelDo.Style = topology.ButtonTopPanel;

            topology.TextBoxDoF[topology.NumF - 1].Text = "20";
            topology.TextBoxDoF[topology.NumF - 1].Style = topology.TextBoxStyle;
            topology.TextBoxDoF[topology.NumF - 1].Width = 25;

            LabelColor.Content = "Цвет:";
            LabelColor.Style = topology.ButtonTopPanel;

            topology.TextBoxColorF[topology.NumF - 1].Text = "ff0000";
            topology.TextBoxColorF[topology.NumF - 1].Style = topology.TextBoxStyle;
            topology.TextBoxColorF[topology.NumF - 1].Width = 80;

            LabelThickness.Content = "Толщина:";
            LabelThickness.Style = topology.ButtonTopPanel;

            topology.TextBoxThicknessF[topology.NumF - 1].Text = "3";
            topology.TextBoxThicknessF[topology.NumF - 1].Style = topology.TextBoxStyle;
            topology.TextBoxThicknessF[topology.NumF - 1].Width = 20;

            MenuSettindCordPlos.Items.Add(LabelF);
            MenuSettindCordPlos.Items.Add(topology.TextBoxF[topology.NumF - 1]);
            MenuSettindCordPlos.Items.Add(LabelOt);
            MenuSettindCordPlos.Items.Add(topology.TextBoxOtF[topology.NumF - 1]);
            MenuSettindCordPlos.Items.Add(LabelDo);
            MenuSettindCordPlos.Items.Add(topology.TextBoxDoF[topology.NumF - 1]);
            MenuSettindCordPlos.Items.Add(LabelColor);
            MenuSettindCordPlos.Items.Add(topology.TextBoxColorF[topology.NumF - 1]);
            MenuSettindCordPlos.Items.Add(LabelThickness);
            MenuSettindCordPlos.Items.Add(topology.TextBoxThicknessF[topology.NumF - 1]);
            MenuSettindCordPlos.SetValue(Canvas.TopProperty, 30.0 * (topology.Num - 1));
            MenuSettindCordPlos.SetValue(Canvas.RightProperty, 0.0);
            return MenuSettindCordPlos;
        }

        private void TextBoxF_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainWindow.TextBoxF_TextChanged(sender, e);
        }
        public Menu PMenu(Topology topology, string important)
        {
            Menu MenuSettindCordPlos = new Menu();
            if (important == "x")
            {
                Label LabelFX = new Label();
                Label LabelOt = new Label();
                Label LabelDo = new Label();
                Label LabelColor = new Label();
                Label LabelThickness = new Label();

                topology.TextBoxPX[topology.NumP - 1] = new TextBox();
                topology.TextBoxOtP[topology.NumP - 1] = new TextBox();
                topology.TextBoxDoP[topology.NumP - 1] = new TextBox();
                topology.TextBoxColorP[topology.NumP - 1] = new TextBox();
                topology.TextBoxThicknessP[topology.NumP - 1] = new TextBox();


                MenuSettindCordPlos.Style = topology.TopPanelSetting;
                MenuSettindCordPlos.Height = 30;

                LabelFX.Content = "x(t) = ";
                LabelFX.Style = topology.ButtonTopPanel;

                topology.TextBoxPX[topology.NumP - 1].Text = "";
                topology.TextBoxPX[topology.NumP - 1].Style = topology.TextBoxStyle;
                topology.TextBoxPX[topology.NumP - 1].Width = 200;
                topology.TextBoxPX[topology.NumP - 1].TextChanged += TextBoxPX_TextChanged;

                LabelOt.Content = "t От:";
                LabelOt.Style = topology.ButtonTopPanel;

                topology.TextBoxOtP[topology.NumP - 1].Text = "-10";
                topology.TextBoxOtP[topology.NumP - 1].Style = topology.TextBoxStyle;
                topology.TextBoxOtP[topology.NumP - 1].Width = 25;

                LabelDo.Content = "До:";
                LabelDo.Style = topology.ButtonTopPanel;

                topology.TextBoxDoP[topology.NumP - 1].Text = "10";
                topology.TextBoxDoP[topology.NumP - 1].Style = topology.TextBoxStyle;
                topology.TextBoxDoP[topology.NumP - 1].Width = 25;

                LabelColor.Content = "Цвет:";
                LabelColor.Style = topology.ButtonTopPanel;

                topology.TextBoxColorP[topology.NumP - 1].Text = "ff0000";
                topology.TextBoxColorP[topology.NumP - 1].Style = topology.TextBoxStyle;
                topology.TextBoxColorP[topology.NumP - 1].Width = 80;

                LabelThickness.Content = "Толщина:";
                LabelThickness.Style = topology.ButtonTopPanel;

                topology.TextBoxThicknessP[topology.NumP - 1].Text = "3";
                topology.TextBoxThicknessP[topology.NumP - 1].Style = topology.TextBoxStyle;
                topology.TextBoxThicknessP[topology.NumP - 1].Width = 20;


                MenuSettindCordPlos.Items.Add(LabelFX);
                MenuSettindCordPlos.Items.Add(topology.TextBoxPX[topology.NumP - 1]);
                MenuSettindCordPlos.Items.Add(LabelOt);
                MenuSettindCordPlos.Items.Add(topology.TextBoxOtP[topology.NumP - 1]);
                MenuSettindCordPlos.Items.Add(LabelDo);
                MenuSettindCordPlos.Items.Add(topology.TextBoxDoP[topology.NumP - 1]);
                MenuSettindCordPlos.Items.Add(LabelColor);
                MenuSettindCordPlos.Items.Add(topology.TextBoxColorP[topology.NumP - 1]);
                MenuSettindCordPlos.Items.Add(LabelThickness);
                MenuSettindCordPlos.Items.Add(topology.TextBoxThicknessP[topology.NumP - 1]);

                MenuSettindCordPlos.SetValue(Canvas.TopProperty, 30.0 * (topology.Num - 1));
                MenuSettindCordPlos.SetValue(Canvas.RightProperty, 0.0);
            }
            else if(important == "y")
            {
                Label LabelFY = new Label();

                topology.TextBoxPY[topology.NumP - 1] = new TextBox();

                MenuSettindCordPlos.Style = topology.TopPanelSetting;
                MenuSettindCordPlos.Height = 30;

                LabelFY.Content = "y(t) = ";
                LabelFY.Style = topology.ButtonTopPanel;

                topology.TextBoxPY[topology.NumP - 1].Text = "";
                topology.TextBoxPY[topology.NumP - 1].Style = topology.TextBoxStyle;
                topology.TextBoxPY[topology.NumP - 1].Width = 200;
                topology.TextBoxPY[topology.NumP - 1].TextChanged += TextBoxPY_TextChanged;

                MenuSettindCordPlos.Items.Add(LabelFY);
                MenuSettindCordPlos.Items.Add(topology.TextBoxPY[topology.NumP - 1]);

                MenuSettindCordPlos.SetValue(Canvas.TopProperty, 30.0 * (topology.Num - 1));
                MenuSettindCordPlos.SetValue(Canvas.RightProperty, 0.0);
            }
            return MenuSettindCordPlos;

        }

        private void TextBoxPY_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainWindow.TextBoxPX_TextChanged(sender, e);
        }

        private void TextBoxPX_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainWindow.TextBoxPY_TextChanged(sender, e);
        }
    }
}
