using FINALBANK.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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

namespace bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path = string.Empty;
        public MainWindow()
        {
            InitializeComponent();          
           

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void HideAll()
        {
            this.setpath.Visibility = Visibility.Hidden;
            this.userbase.Visibility = Visibility.Hidden;
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

        private void set_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            setpath.Visibility = Visibility.Visible;
        }

        private void apply_click(object sender, RoutedEventArgs e)
        {
            path = txtpath.Text;
            HideAll();
            return;
        }

        private void adduser_Click(object sender, RoutedEventArgs e)
        {
            new Registation(path).ShowDialog();
        }

        private void viewbase_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            var json = File.ReadAllText(path + "/User Base/USERBASE.json");
            var list = JsonSerializer.Deserialize<List<User>>(json);
            foreach(var item in list)
            {
                userlist.Items.Add(item);
            }
            this.userbase.Visibility = Visibility.Visible;


        }

        private void deleteuser_Click(object sender, RoutedEventArgs e)
        {
            new DeleteUser(path).ShowDialog();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            var json = File.ReadAllText(path + "/settings.json");
            var settings = JsonSerializer.Deserialize<Settings>(json);
            settings.IsClose = true;
            var tempjson = JsonSerializer.Serialize(settings);
            File.WriteAllText(path + "/settings.json", tempjson);
            MessageBox.Show("All done");
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            var json = File.ReadAllText(path + "/settings.json");
            var settings = JsonSerializer.Deserialize<Settings>(json);
            settings.IsClose = false;
            var tempjson = JsonSerializer.Serialize(settings);
            File.WriteAllText(path + "/settings.json", tempjson);
            MessageBox.Show("All done");
        }

        private void setmusic_Click(object sender, RoutedEventArgs e)
        {
            new SetMusic(path).ShowDialog();
        }
    }
}
