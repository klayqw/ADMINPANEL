using FINALBANK.Classes;
using FINALBANK.Models;
using FINALBANK.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        
        string path = string.Empty;

        public DeleteUser(string path)
        {
            InitializeComponent();
            this.path = path;
        }  

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearAll()
        {
            txtUser.Clear();
            
        }

        

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var jsontemp = File.ReadAllText(path + "/User Base/USERBASE.json");
                var list = JsonSerializer.Deserialize<List<User>>(jsontemp);


                if (list.Any(x => x.Nickname == txtUser.Text) == false)
                {
                    MessageBox.Show("no such user", "delete", MessageBoxButton.OK, MessageBoxImage.Error);
                    ClearAll();
                    return;
                }
                list.RemoveAt(list.FindIndex(x => x.Nickname == txtUser.Text));
                var json = JsonSerializer.Serialize<List<User>>(list);
                File.WriteAllText(path + "/User Base/USERBASE.json", json);
                MessageBox.Show("all done", "delete", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
