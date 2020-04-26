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
using System.Windows.Shapes;

namespace NetworkService
{
    /// <summary>
    /// Interaction logic for add_remove.xaml
    /// </summary>
    public partial class add_remove : Window
    {
        int Ar = -1;
        public add_remove(int ar)
        {
            InitializeComponent();
            List<string> l = new List<string>();
            l.Add("Tip1");
            l.Add("Tip2");
            l.Add("Tip3");
            TIP.ItemsSource = l;
            Ar = ar;

            if (ar == 1)
            {
                textBlock.Text = "ADD";
                addremove.Content = "_ADD";
                name.Visibility = Visibility.Visible;
                NAME.Visibility = Visibility.Visible;
                tip.Visibility = Visibility.Visible;
                TIP.Visibility = Visibility.Visible;
            }
            else if (ar == 0)
            {
                textBlock.Text = "REMOVE";
                addremove.Content = "_REMOVE";
                name.Visibility = Visibility.Hidden;
                NAME.Visibility = Visibility.Hidden;
                tip.Visibility = Visibility.Hidden;
                TIP.Visibility = Visibility.Hidden;
            }
        }

        private void addremove_Click(object sender, RoutedEventArgs e)
        {
            
       
            int flag = -1;
            if (Ar == 1)
            {
                if (ID.Text != "" && NAME.Text != "" && TIP.SelectedItem != null)
                {
                    try
                    {
                        int p = int.Parse(ID.Text);
                        foreach (Ventil v in MainWindow.ventili.Values)
                        {


                            if (p == v.Id)
                            {
                                MessageBox.Show("ID alredy exists.");
                                flag = 0;
                                break;
                            }


                        }
                    }
                    catch
                    {
                        MessageBox.Show("ID must be number.");
                        flag = 0;
                    }
                    if (flag == -1)
                    {
                        MainWindow.Lista.Add(new Ventil(int.Parse(ID.Text), NAME.Text, TIP.SelectedItem.ToString()));
                        MainWindow.ventili.Add(MainWindow.cnt, MainWindow.Lista[MainWindow.Lista.Count - 1]);
                      //  Console.WriteLine(MainWindow.cnt - 1 + "  " + MainWindow.ventili[MainWindow.cnt - 1].Naziv);
                        // MainWindow.cnt++;
                        Console.WriteLine(MainWindow.cnt);
                        MainWindow.count = MainWindow.cnt;
                        MainWindow.cnt++;
                        NAME.Text = "";
                        ID.Text = "";
                        TIP.SelectedItem = null;
                    }
                }
                else
                {
                    
                    MessageBox.Show("You need to fill all fields.");
                }
            }
            else
            {


                int p = -1;
                foreach(KeyValuePair<int,Ventil> v in MainWindow.ventili)
                {
                    if(v.Value.Id == int.Parse(ID.Text))
                    {
                        if (MainWindow.Lista.Contains(v.Value))
                        {
                            MainWindow.ventili.Remove(v.Key);
                            MainWindow.Lista.Remove(v.Value);
                            ID.Text = "";
                            p = 1;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("You need first to move the object from world to your factory.");
                        }
                    }
                }
                if (p == 1)
                {
                    MainWindow.ventili.Clear();
                    int br = 0;
                    foreach (Ventil v in MainWindow.Lista)
                    {
                        MainWindow.ventili.Add(br++, v);
                    }

                    MainWindow.cnt--;
                    MainWindow.count = MainWindow.cnt;
                    Console.WriteLine(MainWindow.cnt);
                }
                else
                {
                    MessageBox.Show("ID does not exists.");
                }
                
            }
            MainWindow.FilterLista.Clear();
            foreach (Ventil v in MainWindow.ventili.Values)
            {
                MainWindow.FilterLista.Add(v);
            }
        }

        private void addremove_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
