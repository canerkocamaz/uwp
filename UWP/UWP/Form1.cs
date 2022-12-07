using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace UWP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        RegistryKey key;
        private void Form1_Load(object sender, EventArgs e)
        {
            key=Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\StorageDevicePolicies");
            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey("System\\CurrentControlSet\\Control\\StorageDevicePolicies");
            }
            if ((int)key.GetValue("WriteProtect") == 0)
            {
                MessageBox.Show("Dikkat!! Usb Yazma Koruması etkin değil....", "Usb Yazma Koruması", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else if ((int)key.GetValue("WriteProtect") == 1)
            {
                MessageBox.Show("Dikkat!! Usb Yazma Koruması zaten etkin....", "Usb Yazma Koruması", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                button1.Enabled = false;
                button2.Enabled = true;
            }
           
            
            key.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\StorageDevicePolicies",true);
            key.SetValue("WriteProtect", 1);
            MessageBox.Show("Dikkat!! Usb Yazma Koruması etkinleştirildi....", "Usb Yazma Koruması", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            button1.Enabled = false;
            button2.Enabled = true;
            key.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\StorageDevicePolicies",true);
            key.SetValue("WriteProtect", 0);
            MessageBox.Show("Dikkat!! Usb Yazma Koruması kaldırıldı....", "Usb Yazma Koruması", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            button1.Enabled = true;
            button2.Enabled = false;
            key.Close();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program sayisaldelil.net tarafından hazırlanmıştır.\nHerhangi bir zarardan dolayı sayisaldelil.net sorumlu tutulamaz.\n Detaylı bilgi için www.sayisaldelil.net ");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult sonuc=MessageBox.Show("çıkmak istediğinizden emin misiniz?\nEğer çıkış yaparsanız yazma koruması kaldırılacak","Çıkış",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.No)
            {
                e.Cancel = true;
            }
            key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\StorageDevicePolicies", true);
            key.SetValue("WriteProtect", 0);
            key.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }


       
    




























    }
}
