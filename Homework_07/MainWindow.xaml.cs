using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
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

namespace Homework_07
{
    
    public partial class MainWindow : Window
    {
        ObservableCollection<List_struct> Daily_base = new ObservableCollection<List_struct>();
        String date = DateTime.Now.ToString("d");
        public MainWindow()
        {
            InitializeComponent();
            Daily_base = myFile.load();
            List_daily.ItemsSource = Daily_base;

        }

   
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            date = Calendar_main.SelectedDate.Value.Date.ToString("d");
            var yourCostumeFilter = new Predicate<object>(item => ((List_struct)item).date.Contains(date));
            List_daily.Items.Filter = yourCostumeFilter;
        }

        
        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            if (Daily_base.Count != 0)
            {
                Daily_base.Add(new List_struct((Daily_base[Daily_base.Count - 1].id + 1), date, text.Text, 1, tag.Text));
            }
            else
            {
                Daily_base.Add(new List_struct(1, date, text.Text, 1, tag.Text));
            }
        }

       
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myFile.save(Daily_base);
        }

        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            if (List_daily.SelectedItem != null)
            {
                var result = MessageBox.Show("Удаляем заметку №" + ((Homework_07.List_struct)List_daily.SelectedItem).id.ToString(), "Внимание!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    
                    Daily_base.Remove(new List_struct(((List_struct)List_daily.SelectedItem).id, ((List_struct)List_daily.SelectedItem).date, ((List_struct)List_daily.SelectedItem).content, ((List_struct)List_daily.SelectedItem).importance, ((List_struct)List_daily.SelectedItem).tag));
                }
            }
            else
            {
                MessageBox.Show("Выберите заметку");
            }
        }
        

    }
}
