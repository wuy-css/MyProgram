using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;

namespace FrmKeyboardHookDemo
{
    public partial class Form1 : Form
    {
        //勾子管理类 
        private KeyboardHookLib _keyboardHook = null;

        public Form1()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            //安装勾子 
            _keyboardHook = new KeyboardHookLib();
            _keyboardHook.InstallHook(this.OnKeyPress);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //取消勾子 
            if (_keyboardHook != null) _keyboardHook.UninstallHook();
        }

        /// <summary> 
        /// 客户端键盘捕捉事件. 
        /// </summary> 
        /// <param name="hookStruct">由Hook程序发送的按键信息</param> 
        /// <param name="handle">是否拦截</param> 
        public void OnKeyPress(KeyboardHookLib.HookStruct hookStruct, out bool handle)
        {
            handle = false; //预设不拦截任何键 

            if (hookStruct.vkCode == 91) // 截获左win(开始菜单键)
            {
                handle = true;
            }

            if (hookStruct.vkCode == 92)// 截获右win
            {
                handle = true;
            }

            //截获Ctrl+Esc 
            if (hookStruct.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control)
            {
                handle = true;
            }

            //截获alt+f4 
            if (hookStruct.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt)
            {
                handle = true;
            }

            //截获alt+tab 
            if (hookStruct.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt)
            {
                handle = true;
            }

            //截获F1 
            if (hookStruct.vkCode == (int)Keys.F1)
            {
                handle = true;
            }

            //截获Ctrl+Alt+Delete 
            if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt + (int)Keys.Delete)
            {
                handle = true;
            }

            //如果键A~Z 
            if (hookStruct.vkCode >= (int)Keys.A && hookStruct.vkCode <= (int)Keys.Z)
            {
                //挡掉B键 
                if (hookStruct.vkCode == (int)Keys.B)
                    hookStruct.vkCode = (int)Keys.None; //设键为0 

                handle = true;
            }

            Keys key = (Keys)hookStruct.vkCode;
            label1.Text = "你按下:" + (key == Keys.None ? "" : key.ToString());

        }
    }
}
