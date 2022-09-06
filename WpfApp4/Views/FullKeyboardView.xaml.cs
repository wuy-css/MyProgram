﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp4.Views
{
    /// <summary>
    /// FullKeyBoard.xaml 的交互逻辑
    /// </summary>
    public partial class FullKeyboardView : Window
    {
        private String valueString;

        internal String ValueString
        {
            get { return valueString; }
        }

        public void FullKeyboard(String inputTitle, String inputvalue)
        {
            InitializeComponent();
            FullKeyboardTitle.Text = inputTitle;
            tbValue.Text = inputvalue;
            valueString = inputvalue;
        }

        //通过判断按钮的content属性来做对应处理，以简化大量按钮的编程
        private void ButtonGrid_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)e.OriginalSource;    //获取click事件触发源，即按了的按钮
            if ((String)clickedButton.Content=="DEL")
            {
                if (tbValue.Text.Length>0)
                {
                    tbValue.Text = tbValue.Text.Substring(0, tbValue.Text.Length - 1);
                }
            }
            else if ((String)clickedButton.Content == "AC")
            {
                tbValue.Text = "";
            }
            else if ((String)clickedButton.Content == "确认")
            {
                valueString = tbValue.Text;
                this.Close();
            }
            else if ((String)clickedButton.Content == "A/a")
            {
                int count = ButtonGrid.Children.Count;
                for (int i = 10; i < count-4; i++)
                {
                    Button buttonTemp = ButtonGrid.Children[i] as Button;
                    String contentTemp = buttonTemp.Content as String;
                    buttonTemp.Content = contentTemp[0] > 90 ? contentTemp.ToUpper() : contentTemp.ToLower();
                }
            }
            else
            {
                tbValue.Text += (String)clickedButton.Content;
            }
        }

    }
}
