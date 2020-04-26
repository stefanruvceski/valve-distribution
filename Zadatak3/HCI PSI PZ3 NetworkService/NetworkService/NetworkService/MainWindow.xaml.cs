using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace NetworkService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int count = 15; // Inicijalna vrednost broja objekata u sistemu
                                // ######### ZAMENITI stvarnim brojem elemenata
        public static int cnt = 0;
        public static ObservableCollection<Ventil> Lista { get; set; }
        public static ObservableCollection<Ventil> FilterLista { get; set; }
        public static ObservableCollection<String> tekst { get; set; }
        public static Dictionary<int, Ventil> ventili = new Dictionary<int, Ventil>();
        FileStream fileStream = new FileStream("textt.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
        private Slika draggedItem = null;
        private bool dragging = false;
        Ventil v = new Ventil();
        string b { get; set; }
        Canvas[] canvas;
        int[] places;
        List<string> filters1 = new List<string>();
        List<string> filters2 = new List<string>();
        Ventil o;
        int now = 0;

        public MainWindow()
        {
            if (Lista == null)
            {
                Lista = new ObservableCollection<Ventil>();
                FilterLista = new ObservableCollection<Ventil>();
                Lista.Add(new Ventil(cnt, "Ime1", "Tip1"));
                ventili.Add(cnt, Lista[Lista.Count - 1]);
                cnt++;
            }
            tekst = new ObservableCollection<string>();
            tekst.Add(new string('a', 5));
            tekst[0] = "";
            DataContext = this;
            fileStream.Close();
            
            InitializeComponent();

            canvas = new Canvas[] { canvas11, canvas12, canvas13, canvas14, canvas21, canvas22, canvas23, canvas24, canvas31, canvas32, canvas33, canvas34, canvas41, canvas42, canvas43, canvas44 };
             places = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};

            

            filters1.Add("ID");
            filters1.Add("Name");
            filters1.Add("Type");


            filter1.ItemsSource = filters1;

            MainWindow.FilterLista.Clear();
            foreach (Ventil v in MainWindow.ventili.Values)
            {
                MainWindow.FilterLista.Add(v);
            }

            filters2.Add("less than");
            filters2.Add("grater than");
            filters2.Add("equal to");
            filter2.ItemsSource = filters2;
            Start();
            createListener(); //Povezivanje sa serverskom aplikacijom

        }

        void Start()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    count = cnt;
                    if (now > 16 || now < 5)
                    {
                        err(v.Id);

                    }
                    else { ok(v.Id); }
                    System.Threading.Thread.Sleep(500);
                }
            }).Start();

        }



        private void createListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25565);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        //Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        //Primljena poruka je sacuvana u incomming stringu
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        
                        //Ukoliko je primljena poruka pitanje koliko objekata ima u sistemu -> odgovor
                        if (incomming.Equals("Need object count"))
                        {
                            //Response
                            /* Umesto sto se ovde salje count.ToString(), potrebno je poslati 
                             * duzinu liste koja sadrzi sve objekte pod monitoringom, odnosno
                             * njihov ukupan broj (NE BROJATI OD NULE, VEC POSLATI UKUPAN BROJ)
                             * */
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(count.ToString());
                            stream.Write(data, 0, data.Length);
                        }
                        else
                        {
                            //U suprotnom, server je poslao promenu stanja nekog objekta u sistemu
                            Console.WriteLine(incomming); //Na primer: "Objekat_1:272"
                            string[] delovi = incomming.Split('_', ':');
                            



                            v.Id = int.Parse(delovi[1]);
                            v.Stanja.Add(int.Parse(delovi[2]));
                            now = int.Parse(delovi[2]);

                            

                            tekst[0] = "";
                            foreach (Ventil vv in ventili.Values)
                            {
                                tekst[0] += "ID: " + vv.Id + "\nName: " + vv.Naziv + "\tType: " + vv.Tip + "\tStates:" + vv.ProcitajStanja() + "\n\n";
                                if (ventili[v.Id].Id == vv.Id)
                                {
                                    vv.Stanja.Add(int.Parse(delovi[2]));
                                    vv.St = int.Parse(delovi[2]);
                                }
                            }
                           
                            Console.WriteLine(tekst[0]);
                            
                            




                            using (StreamWriter sw = File.AppendText("textt.txt"))
                            {

                                sw.WriteLine("Objekat:" + v.Id + "\t|Stanje:" + v.Stanja[v.Stanja.Count - 1]);
                            }
                            //################ IMPLEMENTACIJA ####################
                            // Obraditi poruku kako bi se dobile informacije o izmeni
                            // Azuriranje potrebnih stvari u aplikaciji

                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

        private void ok(int key)
        {

            this.Dispatcher.Invoke((Action)(() =>
            {
                for (int i = 0; i < 16; i++)
                {
                    if (key == places[i])
                    {
                        BitmapImage logo = new BitmapImage();
                        logo.BeginInit();
                        logo.UriSource = new Uri(ventili[key].Image.ToString());
                        logo.EndInit();
                        ((Canvas)canvas[i]).Background = new ImageBrush(logo);
                    }
                }
            }));


        }


        private void err(int key)
        {


            this.Dispatcher.Invoke((Action)(() =>
            {
                for(int i = 0;i<16;i++)
                {
                    if (key == places[i])
                    {
                        try
                        {
                            //((TextBlock)(canvas[i]).Children[2]).Text = "FAccK YOU";
                            BitmapImage logo = new BitmapImage();
                            logo.BeginInit();

                            

                            logo.UriSource = new Uri(@"C:\Users\STEFAN\Documents\Zadatak3\Zadatak3\Images\1.jpg");
                            logo.EndInit();
                            ((Canvas)canvas[i]).Background = new ImageBrush(logo);
                        }
                        catch { }
                    }
                }
                
            }));

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            add_remove ar = new add_remove(1);
            ar.ShowDialog();
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            add_remove ar = new add_remove(0);
            ar.ShowDialog();

            
            
        }

        private void listView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            draggedItem = null;
            listView.SelectedItem = null;
            dragging = false;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!dragging)
            {
                dragging = true;
                 o = (Ventil)listView.SelectedItem;
                draggedItem = new Slika((o.Image).ToString());
                DragDrop.DoDragDrop(this, draggedItem, DragDropEffects.Copy | DragDropEffects.Move);
                
            }
        }

        private void dragOver(object sender, DragEventArgs e)
        {
            base.OnDragOver(e);
            if (((Canvas)sender).Resources["taken"] != null)
            {
                e.Effects = DragDropEffects.None;
            }
            else
            {
                e.Effects = DragDropEffects.Copy;
                Lista.Remove(o);
            }
            e.Handled = true;
        }

        private void drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);
            if (draggedItem != null)
            {
                if (((Canvas)sender).Resources["taken"] == null)
                {
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(draggedItem.imageUri);
                    logo.EndInit();
                    ((Canvas)sender).Background = new ImageBrush(logo);
                    ((TextBlock)((Canvas)sender).Children[0]).Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                    ((TextBlock)((Canvas)sender).Children[0]).Text = o.Id.ToString();
                    ((TextBlock)((Canvas)sender).Children[2]).Text = o.Naziv;
                    ((Canvas)sender).Resources.Add("taken", true);

                    for(int i = 0;i<16;i++)
                    {
                        if(((Canvas)sender) == canvas[i])
                        {
                            foreach(KeyValuePair<int,Ventil > v in ventili)
                            {
                                if(v.Value.Id == o.Id)
                                {
                                    places[i] = v.Key;

                                    break;
                                }
                            }
                        }
                    }

                }
                listView.SelectedItem = null;
                dragging = false;
            }
            e.Handled = true;
        }

        private void oslobodi(object sender, RoutedEventArgs e)
        {

            int pom = int.Parse(((Button)sender).Name.Substring(6));
            // button11.Content = pom;

            //Console.WriteLine(s);
            if (pom == 11)
            {
                int x = int.Parse(((TextBlock)canvas11.Children[0]).Text);
                if (canvas11.Resources["taken"] != null)
                {
                    places[0] = -1;
                    canvas11.Background = Brushes.SlateGray;
                    ((TextBlock)canvas11.Children[0]).Text = "Free";
                    ((TextBlock)canvas11.Children[2]).Text = "";
                    ((TextBlock)canvas11.Children[0]).Foreground = Brushes.Black;
                    canvas11.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 12)
            {
                int x = int.Parse(((TextBlock)canvas12.Children[0]).Text);
                if (canvas12.Resources["taken"] != null)
                {
                    places[1] = -1;
                    canvas12.Background = Brushes.SlateGray;
                    ((TextBlock)canvas12.Children[0]).Text = "Free";
                    ((TextBlock)canvas12.Children[2]).Text = "";
                    ((TextBlock)canvas12.Children[0]).Foreground = Brushes.Black;
                    canvas12.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 13)
            {
                int x = int.Parse(((TextBlock)canvas13.Children[0]).Text);
                if (canvas13.Resources["taken"] != null)
                {
                    places[2] = -1;
                    
                    canvas13.Background = Brushes.SlateGray;
                    ((TextBlock)canvas13.Children[0]).Text = "Free";
                    ((TextBlock)canvas13.Children[2]).Text = "";
                    ((TextBlock)canvas13.Children[0]).Foreground = Brushes.Black;
                    canvas13.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 14)
            {
                int x = int.Parse(((TextBlock)canvas14.Children[0]).Text);
                if (canvas14.Resources["taken"] != null)
                {
                    places[3] = -1;
                    canvas14.Background = Brushes.SlateGray;
                    ((TextBlock)canvas14.Children[0]).Text = "Free";
                    ((TextBlock)canvas14.Children[2]).Text = "";
                    ((TextBlock)canvas14.Children[0]).Foreground = Brushes.Black;
                    canvas14.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 21)
            {
                int x = int.Parse(((TextBlock)canvas21.Children[0]).Text);
                if (canvas21.Resources["taken"] != null)
                {
                    places[4] = -1;
                    canvas21.Background = Brushes.SlateGray;
                    ((TextBlock)canvas21.Children[0]).Text = "Free";
                    ((TextBlock)canvas21.Children[2]).Text = "";
                    ((TextBlock)canvas21.Children[0]).Foreground = Brushes.Black;
                    canvas21.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 22)
            {
                int x = int.Parse(((TextBlock)canvas22.Children[0]).Text);
                if (canvas22.Resources["taken"] != null)
                {
                    places[5] = -1;
                    canvas22.Background = Brushes.SlateGray;
                    ((TextBlock)canvas22.Children[0]).Text = "Free";
                    ((TextBlock)canvas22.Children[2]).Text = "";
                    ((TextBlock)canvas22.Children[0]).Foreground = Brushes.Black;
                    canvas22.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 23)
            {
                int x = int.Parse(((TextBlock)canvas23.Children[0]).Text);
                if (canvas23.Resources["taken"] != null)
                {
                    places[6] = -1;
                    canvas23.Background = Brushes.SlateGray;
                    ((TextBlock)canvas23.Children[0]).Text = "Free";
                    ((TextBlock)canvas23.Children[2]).Text = "";
                    ((TextBlock)canvas23.Children[0]).Foreground = Brushes.Black;
                    canvas23.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 24)
            {
                int x = int.Parse(((TextBlock)canvas24.Children[0]).Text);
                if (canvas24.Resources["taken"] != null)
                {
                    places[7] = -1;
                    canvas24.Background = Brushes.SlateGray;
                    ((TextBlock)canvas24.Children[0]).Text = "Free";
                    ((TextBlock)canvas24.Children[2]).Text = "";
                    ((TextBlock)canvas24.Children[0]).Foreground = Brushes.Black;
                    canvas24.Resources.Remove("taken");

                    
                    foreach (Ventil v in ventili.Values)
                    {
                        if(v.Id == x)
                        {
                            Lista.Add(v);
                            break;
                        }
                    }
                }
            }
            else if (pom == 31)
            {
                int x = int.Parse(((TextBlock)canvas31.Children[0]).Text);
                if (canvas31.Resources["taken"] != null)
                {
                    places[8] = -1;
                    canvas31.Background = Brushes.SlateGray;
                    ((TextBlock)canvas31.Children[0]).Text = "Free";
                    ((TextBlock)canvas31.Children[2]).Text = "";
                    ((TextBlock)canvas31.Children[0]).Foreground = Brushes.Black;
                    canvas31.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 32)
            {
                int x = int.Parse(((TextBlock)canvas32.Children[0]).Text);
                if (canvas32.Resources["taken"] != null)
                {
                    places[9] = -1;
                    canvas32.Background = Brushes.SlateGray;
                    ((TextBlock)canvas32.Children[0]).Text = "Free";
                    ((TextBlock)canvas32.Children[2]).Text = "";
                    ((TextBlock)canvas32.Children[0]).Foreground = Brushes.Black;
                    canvas32.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 33)
            {
                int x = int.Parse(((TextBlock)canvas33.Children[0]).Text);
                if (canvas33.Resources["taken"] != null)
                {
                    places[10] = -1;
                    canvas33.Background = Brushes.SlateGray;
                    ((TextBlock)canvas33.Children[0]).Text = "Free";
                    ((TextBlock)canvas33.Children[2]).Text = "";
                    ((TextBlock)canvas33.Children[0]).Foreground = Brushes.Black;
                    canvas33.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 34)
            {
                int x = int.Parse(((TextBlock)canvas34.Children[0]).Text);
                if (canvas34.Resources["taken"] != null)
                {
                    places[11] = -1;
                    canvas34.Background = Brushes.SlateGray;
                    ((TextBlock)canvas34.Children[0]).Text = "Free";
                    ((TextBlock)canvas34.Children[2]).Text = "";
                    ((TextBlock)canvas34.Children[0]).Foreground = Brushes.Black;
                    canvas34.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 41)
            {
                int x = int.Parse(((TextBlock)canvas41.Children[0]).Text);
                if (canvas41.Resources["taken"] != null)
                {
                    places[12] = -1;
                    canvas41.Background = Brushes.SlateGray;
                    ((TextBlock)canvas41.Children[0]).Text = "Free";
                    ((TextBlock)canvas41.Children[2]).Text = "";
                    ((TextBlock)canvas41.Children[0]).Foreground = Brushes.Black;
                    canvas41.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 42)
            {
                int x = int.Parse(((TextBlock)canvas42.Children[0]).Text);
                if (canvas42.Resources["taken"] != null)
                {
                    places[13] = -1;
                    canvas42.Background = Brushes.SlateGray;
                    ((TextBlock)canvas42.Children[0]).Text = "Free";
                    ((TextBlock)canvas42.Children[2]).Text = "";
                    ((TextBlock)canvas42.Children[0]).Foreground = Brushes.Black;
                    canvas42.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }

            }
            else if (pom == 43)
            {
                int x = int.Parse(((TextBlock)canvas43.Children[0]).Text);
                if (canvas43.Resources["taken"] != null)
                {
                    places[14] = -1;
                    canvas43.Background = Brushes.SlateGray;
                    ((TextBlock)canvas43.Children[0]).Text = "Free";
                    ((TextBlock)canvas43.Children[2]).Text = "";
                    ((TextBlock)canvas43.Children[0]).Foreground = Brushes.Black;
                    canvas43.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
            else if (pom == 44)
            {
                int x = int.Parse(((TextBlock)canvas44.Children[0]).Text);
                if (canvas44.Resources["taken"] != null)
                {
                    places[15] = -1;
                    canvas44.Background = Brushes.SlateGray;
                    ((TextBlock)canvas44.Children[0]).Text = "Free";
                    ((TextBlock)canvas44.Children[2]).Text = "";
                    ((TextBlock)canvas44.Children[0]).Foreground = Brushes.Black;
                    canvas44.Resources.Remove("taken");
                }

                
                foreach (Ventil v in ventili.Values)
                {
                    if (v.Id == x)
                    {
                        Lista.Add(v);
                        break;
                    }
                }
            }
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            FilterLista.Clear();
            if (filter1.SelectedItem.ToString() == filters1[0])                                  //ID
            {
                if (filter2.SelectedItem.ToString() == filters2[0])     //LESS
                {
                    foreach(Ventil v in ventili.Values)
                    {
                        if(v.Id < int.Parse(value.Text))
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
                else if(filter2.SelectedItem.ToString() == filters2[1]) //GRATER
                {
                    foreach (Ventil v in ventili.Values)
                    {
                        if (v.Id > int.Parse(value.Text))
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
                else                                                    //EQUAL
                {
                    foreach (Ventil v in ventili.Values)
                    {
                        if (v.Id == int.Parse(value.Text))
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
            }
            else if (filter1.SelectedItem.ToString() == filters1[1])                           // NAZIV
            {
                if (filter2.SelectedItem.ToString() == filters2[0])     //LESS
                {
                    foreach (Ventil v in ventili.Values)
                    {
                        if (v.Naziv.Count() < value.Text.Count())
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
                else if (filter2.SelectedItem.ToString() == filters2[1]) //GRATER
                {
                    foreach (Ventil v in ventili.Values)
                    {
                        if (v.Naziv.Count() > value.Text.Count())
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
                else                                                    //EQUAL
                {
                    foreach (Ventil v in ventili.Values)
                    {
                        if (v.Naziv == value.Text)
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
            }
            else                                                                               // TIP
            {
                int pom = int.Parse(value.Text.Substring(3, 1)) ;
                //Console.WriteLine(pom);
                if (filter2.SelectedItem.ToString() == filters2[0])     //LESS
                {
                    foreach (Ventil v in ventili.Values)
                    {
                        Console.WriteLine(int.Parse(v.Tip.Substring(3, 1)) + "||||1");
                        if (int.Parse(v.Tip.Substring(3,1)) < pom)
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
                else if (filter2.SelectedItem.ToString() == filters2[1]) //GRATER
                {
                    foreach (Ventil v in ventili.Values)
                    {
                        if (int.Parse(v.Tip.Substring(3, 1)) > pom)
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
                else                                                    //EQUAL
                {
                    foreach (Ventil v in ventili.Values)
                    {
                        if (int.Parse(v.Tip.Substring(3, 1)) == pom)
                        {
                            FilterLista.Add(v);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= ventili.Count(); i++)
            {
                try
                {
                    ventili[i].Stanja.Clear();
                }
                catch { }
            }
            // textBox.Text = "";
            int[] Y = new int[100];


            using (StreamReader sr = File.OpenText("textt.txt"))
            {
                graph1.Children.Clear();
                polyline.Points.Add(new Point(0, 0));

                while (sr.Peek() > 0)
                {
                    string s = sr.ReadLine();
                    Line l = new Line();
                    string[] deo = s.Split('|', ':');


                    ventili[int.Parse(deo[1])].Stanja.Add(int.Parse(deo[3]));

                    Console.WriteLine(ventili[int.Parse(deo[1])].Id + "||" + deo[3]);
                }
                
                int j = int.Parse(textBox11.Text);
                int cnt = 1;
                
                if (ventili.ElementAt(j).Value.Stanja.Count() > int.Parse(textBox_Copy1.Text)) 
                    
                {

                    Line l2 = new Line();
                    l2.X1 = 15;
                    l2.Stroke = Brushes.Blue;
                    l2.X2 = 15;
                    l2.Y1 = 0;
                    l2.Y2 = ((int)graph1.Height - 6);
                    l2.StrokeThickness = 1;
                    graph1.Children.Add(l2);

                    Line l3 = new Line();
                    l3.X1 = 15;
                    l3.Stroke = Brushes.Blue;
                    l3.X2 = 20;
                    l3.Y1 = ((int)graph1.Height - 6);
                    l3.Y2 = ((int)graph1.Height - 6);
                    l2.StrokeThickness = 1;
                    graph1.Children.Add(l3);

                    int time = int.Parse(textBox_Copy1.Text);
                    for (int i = ventili.ElementAt(j).Value.Stanja.Count() - int.Parse(textBox_Copy1.Text) - 1; i < ventili.ElementAt(j).Value.Stanja.Count() - 1; i++)
                    {


                        Line l = new Line();
                        l.X1 = cnt * 20;
                        cnt++;
                        l.X2 = cnt * 20;
                        l.Y1 = ((int)graph1.Height -10  - ventili.ElementAt(j).Value.Stanja[i] * 16);
                        l.Y2 = ((int)graph1.Height -10 - ventili.ElementAt(j).Value.Stanja[i + 1] * 16);
                        l.Stroke = Brushes.Blue;
                        graph1.Children.Add(l);

                        Line l1 = new Line();
                        l1.X1 = (cnt - 1) * 20;
                        l1.Stroke = Brushes.Blue;
                        l1.X2 = cnt * 20;
                        l1.Y1 = ((int)graph1.Height - 6 );
                        l1.Y2 = ((int)graph1.Height - 6);
                        l1.StrokeThickness = 1;
                        graph1.Children.Add(l1);

                        Line l4 = new Line();
                        l4.X1 = 14;
                        l4.Stroke = Brushes.Blue;
                        l4.X2 = 19;
                        l4.Y1 = ((int)graph1.Height - 10 - ventili.ElementAt(j).Value.Stanja[i] * 16);
                        l4.Y2 = ((int)graph1.Height - 10 - ventili.ElementAt(j).Value.Stanja[i] * 16);
                        l4.StrokeThickness = 1;
                        graph1.Children.Add(l4);

                        Line lne = new Line();
                        lne.X1 = (cnt-1)*20;
                        lne.X2 = (cnt-1)*20;
                        lne.Y1 = ((int)graph1.Height );
                        lne.Y2 = ((int)graph1.Height -10);
                        lne.Stroke = Brushes.Blue;
                        lne.StrokeThickness = 1;
                        graph1.Children.Add(lne);

                        TextBlock textBlock = new TextBlock();

                        textBlock.Text = (time).ToString();
                        time--;
                        textBlock.Foreground = Brushes.Blue;

                        Canvas.SetLeft(textBlock, (cnt - 1) * (20 )-4);

                        Canvas.SetTop(textBlock, (int)graph1.Height - 4);

                        graph1.Children.Add(textBlock);


                        TextBlock textBlock2 = new TextBlock();

                        textBlock2.Text = ventili.ElementAt(j).Value.Stanja[i].ToString();
                        
                        textBlock2.Foreground = Brushes.Blue;

                        Canvas.SetLeft(textBlock2, 0);

                        Canvas.SetTop(textBlock2, (int)graph1.Height  -18 - ventili.ElementAt(j).Value.Stanja[i] *16);

                        graph1.Children.Add(textBlock2);
                    }

                    Line l11 = new Line();
                    l11.X1 = (cnt ) * 20;
                    l11.Stroke = Brushes.Blue;
                    l11.X2 = cnt * 20;
                    l11.Y1 = ((int)graph1.Height - 6);
                    l11.Y2 = ((int)graph1.Height - 6);
                    l11.StrokeThickness = 0.5;
                    graph1.Children.Add(l11);

                    Line lne1 = new Line();
                    lne1.X1 = (cnt ) * 20;
                    lne1.X2 = (cnt ) * 20;
                    lne1.Y1 = ((int)graph1.Height);
                    lne1.Y2 = ((int)graph1.Height - 10);
                    lne1.Stroke = Brushes.Blue;
                    lne1.StrokeThickness = 1;
                    graph1.Children.Add(lne1);

                    Line l5 = new Line();
                    l5.X1 = 14;
                    l5.Stroke = Brushes.Blue;
                    l5.X2 = 19;
                    l5.Y1 = ((int)graph1.Height - 10 - ventili.ElementAt(j).Value.Stanja[ventili.ElementAt(j).Value.Stanja.Count() - 1] * 16);
                    l5.Y2 = ((int)graph1.Height - 10 - ventili.ElementAt(j).Value.Stanja[ventili.ElementAt(j).Value.Stanja.Count() - 1] * 16);
                    l5.StrokeThickness = 1;
                    graph1.Children.Add(l5);

                    TextBlock textBlock1 = new TextBlock();

                    textBlock1.Text = time.ToString();

                    textBlock1.Foreground = Brushes.Blue;

                    Canvas.SetLeft(textBlock1, (cnt ) * (20) - 4);

                    Canvas.SetTop(textBlock1, (int)graph1.Height - 4);

                    graph1.Children.Add(textBlock1);

                    TextBlock textBlock3 = new TextBlock();

                    textBlock3.Text = ventili.ElementAt(j).Value.Stanja[ventili.ElementAt(j).Value.Stanja.Count() - 1].ToString();

                    textBlock3.Foreground = Brushes.Blue;

                    Canvas.SetLeft(textBlock3, 0);

                    Canvas.SetTop(textBlock3, (int)graph1.Height - 18 - ventili.ElementAt(j).Value.Stanja[ventili.ElementAt(j).Value.Stanja.Count() - 1] * 16);

                    graph1.Children.Add(textBlock3);
                }


                textBox11.Text = "";
                textBox_Copy1.Text = "";

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= ventili.Count(); i++)
            {
                try
                {
                    ventili[i].Stanja.Clear();
                }
                catch { }
            }
            int[] Y = new int[100];


            using (StreamReader sr = File.OpenText("textt.txt"))
            {
                graph2.Children.Clear();
                polyline.Points.Add(new Point(0, 0));

                while (sr.Peek() > 0)
            {
                string s = sr.ReadLine();
                Line l = new Line();
                string[] deo = s.Split('|', ':');


                ventili[int.Parse(deo[1])].Stanja.Add(int.Parse(deo[3]));

                Console.WriteLine(ventili[int.Parse(deo[1])].Id + "||" + deo[3]);
            }
            
            int j = int.Parse(textBox2.Text);
            int cnt = 1;

            if (ventili.ElementAt(j).Value.Stanja.Count() > int.Parse(textBox_Copy2.Text))

            {

                Line l2 = new Line();
                l2.X1 = 15;
                    l2.Stroke = Brushes.Green;
                    l2.X2 = 15;
                l2.Y1 = 0;
                l2.Y2 = ((int)graph2.Height - 6);
                l2.StrokeThickness = 1;
                graph2.Children.Add(l2);

                Line l3 = new Line();
                l3.X1 = 15;
                l3.Stroke = Brushes.Green;
                    l3.X2 = 20;
                l3.Y1 = ((int)graph2.Height - 6);
                l3.Y2 = ((int)graph2.Height - 6);
                l2.StrokeThickness = 1;
                graph2.Children.Add(l3);

                int time = int.Parse(textBox_Copy2.Text);
                for (int i = ventili.ElementAt(j).Value.Stanja.Count() - int.Parse(textBox_Copy2.Text) - 1; i < ventili.ElementAt(j).Value.Stanja.Count() - 1; i++)
                {


                    Line l = new Line();
                    l.X1 = cnt * 20;
                    cnt++;
                    l.X2 = cnt * 20;
                    l.Y1 = ((int)graph2.Height - 10 - ventili.ElementAt(j).Value.Stanja[i] * 16);
                    l.Y2 = ((int)graph2.Height - 10 - ventili.ElementAt(j).Value.Stanja[i + 1] * 16);
                    l.Stroke = Brushes.Green;
                        graph2.Children.Add(l);

                    Line l1 = new Line();
                    l1.X1 = (cnt - 1) * 20;
                    l1.Stroke = Brushes.Green;
                        l1.X2 = cnt * 20;
                    l1.Y1 = ((int)graph2.Height - 6);
                    l1.Y2 = ((int)graph2.Height - 6);
                    l1.StrokeThickness = 1;
                    graph2.Children.Add(l1);

                    Line l4 = new Line();
                    l4.X1 = 14;
                    l4.Stroke = Brushes.Green;
                        l4.X2 = 19;
                    l4.Y1 = ((int)graph2.Height - 10 - ventili.ElementAt(j).Value.Stanja[i] * 16);
                    l4.Y2 = ((int)graph2.Height - 10 - ventili.ElementAt(j).Value.Stanja[i] * 16);
                    l4.StrokeThickness = 1;
                    graph2.Children.Add(l4);

                    Line lne = new Line();
                    lne.X1 = (cnt - 1) * 20;
                    lne.X2 = (cnt - 1) * 20;
                    lne.Y1 = ((int)graph2.Height);
                    lne.Y2 = ((int)graph2.Height - 10);
                    lne.Stroke = Brushes.Green;
                    lne.StrokeThickness = 1;
                    graph2.Children.Add(lne);

                    TextBlock textBlock = new TextBlock();

                    textBlock.Text = (time).ToString();
                    time--;
                    textBlock.Foreground = Brushes.Green;

                    Canvas.SetLeft(textBlock, (cnt - 1) * (20) - 4);

                    Canvas.SetTop(textBlock, (int)graph2.Height - 4);

                    graph2.Children.Add(textBlock);


                    TextBlock textBlock2 = new TextBlock();

                    textBlock2.Text = ventili.ElementAt(j).Value.Stanja[i].ToString();

                    textBlock2.Foreground = Brushes.Green;

                    Canvas.SetLeft(textBlock2, 0);

                    Canvas.SetTop(textBlock2, (int)graph2.Height - 18 - ventili.ElementAt(j).Value.Stanja[i] * 16);

                    graph2.Children.Add(textBlock2);
                }

                Line l11 = new Line();
                l11.X1 = (cnt) * 20;
                l11.Stroke = Brushes.Green;
                    l11.X2 = cnt * 20;
                l11.Y1 = ((int)graph2.Height - 6);
                l11.Y2 = ((int)graph2.Height - 6);
                l11.StrokeThickness = 0.5;
                graph2.Children.Add(l11);

                Line lne1 = new Line();
                lne1.X1 = (cnt) * 20;
                lne1.X2 = (cnt) * 20;
                lne1.Y1 = ((int)graph2.Height);
                lne1.Y2 = ((int)graph2.Height - 10);
                lne1.Stroke = Brushes.Green;
                lne1.StrokeThickness = 1;
                graph2.Children.Add(lne1);

                TextBlock textBlock1 = new TextBlock();

                textBlock1.Text = time.ToString();

                textBlock1.Foreground = Brushes.Green;

                Canvas.SetLeft(textBlock1, (cnt) * (20) - 4);

                Canvas.SetTop(textBlock1, (int)graph2.Height - 4);

                graph2.Children.Add(textBlock1);
            }

            textBox2.Text = "";
            textBox_Copy2.Text = "";

        }
    }

        private void _filter_Copy_Click(object sender, RoutedEventArgs e)
        {
            FilterLista.Clear();
            foreach (Ventil v in ventili.Values)
            {
                FilterLista.Add(v);
                
            }
            filter1.SelectedItem = null;
            filter2.SelectedItem = null;
            value.Text = "";
        }
    }
}
