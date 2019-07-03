using facture;
using Menu.Les_interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Menu
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static Boolean echn=false;
        public static cmd_recu res = new cmd_recu();
        public static change_ip fen_chang_ip = new change_ip();
        public static reponse_recu reponse = new reponse_recu();
        public static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static string chaine;
        private const int PORT = 100;
        private SqlConnection conn = new SqlConnection(@"Data source=.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true;  MultipleActiveResultSets=True");
        private SqlCommand cmd_notif, cmd_new, cmd_med, cmd_notif2, cmd_new2;
        private SqlDataReader rd_notif, rd_new, rd_med, rd_notif2, rd_new2;
        private DateTime date_courant;
        private DateTime date_min;
        private TimeSpan duree = new TimeSpan(30, 0, 0, 0);
        public static string ip_adr_serv;

        public MainWindow()
        {
            InitializeComponent();
            /*this.user.Content = log_in.user;
            Frame2.Content = new contacter();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ip FROM echange where moi=1", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            ip_adr_serv = rd["ip"].ToString();
            ConnectToServer();
            Thread Thr=new Thread(RequestLoop);
            Thr.SetApartmentState(ApartmentState.STA);
            Thr.Start();
            conn.Close();
            dt_Tick(null, null);*/
        }
       


        private static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    ClientSocket.Connect(IPAddress.Parse(ip_adr_serv), PORT);
                    
                    SendString(Recuper_info());
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERREUR de connexion au serveur");
                    
                }
            }
        }
        public static String Recuper_info()
        {
            string nom_pharm = "";
            string adress = "";
            string fax = "";
            string N_telephone = "";
            string lat = "";
            string lon = "";
            SqlConnection cnn = new SqlConnection(@"Data source=.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true;");
        
            try
            {
                cnn.Open();
                SqlCommand cm = new SqlCommand("Select * FROM echange WHERE moi=1", cnn);
                SqlDataReader ddr = cm.ExecuteReader();
                if (ddr.Read())
                {
                    nom_pharm = ddr["nom_pharm"].ToString();
                    N_telephone = ddr["N_telephone"].ToString();
                    adress = ddr["adress"].ToString();
                    fax = ddr["FAX"].ToString();
                    lat = ddr["lat"].ToString();
                    lon = ddr["long"].ToString();
                }
                string request ="y"+"/"+ N_telephone + " /" + nom_pharm + " /" + adress + " /" + fax + " /" + lat + " /" + lon;
                ddr.Close();
                return request;
            }
            finally
            {
                cnn.Close();
            }

        }

        private static void RequestLoop()
        {
            while (true)
            {
                ReceiveResponse();
            }
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        private static void Exit()
        {
            SendString("exit"); // Tell the server we are exiting
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            try
            {
                ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
            catch
            {

            }
        }

        private static void ReceiveResponse()
        {
            try
            {
                var buffer = new byte[2048];
                int received = ClientSocket.Receive(buffer, SocketFlags.None);
                if (received == 0) return;
                var data = new byte[received];
                Array.Copy(buffer, data, received);
                string text = Encoding.ASCII.GetString(data);
                if (text.Split('/')[0].ToLower().Equals("oui"))
                {
                    if (echn == false)
                    {
                        echn = true;
                        reponse.initialiser(text);
                        reponse.Show();
                        reponse.effect_echange(text);
                    }
                        
                }
                else
                {
                    if (text.Split('/')[0].ToLower().Equals("y"))
                    {
                        String []tab_phar= text.Split(new string[] { "y/" },StringSplitOptions.None) ;
                        foreach (string str in tab_phar)
                        {
                            if(str!="")
                            {
                                String[] tab = str.Split('/');
                                SqlConnection conn = new SqlConnection(@"Data source=.\SQLEXPRESS; Initial Catalog=mydb; Integrated Security=true;  MultipleActiveResultSets=True");

                                try
                                {
                                    conn.Open();
                                    SqlCommand cm = new SqlCommand("Select * from echange where N_telephone ='" + tab[0] + "'", conn);
                                    SqlDataReader ddr = cm.ExecuteReader();
                                    int count = 0;
                                    while (ddr.Read())
                                    {
                                        count = count + 1;
                                    }
                                    ddr.Close();
                                    if (count <= 0)
                                    {
                                        cm = new SqlCommand("Insert into echange (N_telephone,nom_pharm,adress,FAX,degre,lat,long,moi,nb_recu) values('" + tab[0] + "','" + tab[1] + "','" + tab[2] + "','" + tab[3] + "'," + 0 + "," +Convert.ToDouble( tab[4]).ToString("G", CultureInfo.InvariantCulture) + "," + Convert.ToDouble(tab[5]).ToString("G", CultureInfo.InvariantCulture) + ",'false',0)", conn);
                                        cm.ExecuteNonQuery();
                                    }


                                }
                                catch (Exception ex)
                                {

                                }
                                finally
                                {

                                    conn.Close();
                                }
                            }
                            
                        }
                        
                    }
                    else
                    {
                        res.initialiser(text);
                        res.Show();
                    }
                      
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fermer_Click(object sender, RoutedEventArgs e)
        {
            Exit();
            this.Close();
            
        }
      
        private void expand_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void home_Click(object sender, RoutedEventArgs e)
        {

            Frame2.Content = new contacter();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ajouter(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    
                   // page = new Ajouter_med ();

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ajouter_med(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new Ajouter_med();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void rech_med(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new recherche();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void supp_med(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new supprimer_med();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ajouter_bien(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new Ajouter_b1_etre();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void rech_bien(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new recherche_bien_etre();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void supp_bien(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new Supprimer_BienEtre();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ajouter_fact(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new Saisir_facture();
                Window1.list_inf.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saisir_cmd_medic(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new Saisir_commande();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saisir_cmd_bien(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new Saisir_cmd_bien_etre();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void map(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new map();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void echange(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new echange();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cmd_pharm(object sender, RoutedEventArgs e)
        {
            Frame2.Content = new cmd_autre_pharm();
        }

        private void help_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("aide\\aide.html");
        }

        private void prod_catigorie(object sender, RoutedEventArgs e)
        {
            try
            {
                Frame2.Content = new liste_produit_categorie();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bilan(object sender, RoutedEventArgs e)
        {
            Frame2.Content = new BilanDeVente();
        }

        private void settings(object sender, RoutedEventArgs e)
        {
            Frame2.Content = new Parametre();
        }


        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromDays(1);
            dt.Tick += dt_Tick;
            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            date_courant = DateTime.Now;
            date_min = date_courant + duree;
            using (cmd_new2 = new SqlCommand("SELECT * FROM  Tab_NEW WHERE DateDePeremption < @date_min", conn))
            {
                cmd_new2.Parameters.Add(new SqlParameter("@date_min", SqlDbType.Date)).Value = date_min.Date;
            }
            if (conn.State == ConnectionState.Closed) conn.Open();
            rd_new2 = cmd_new2.ExecuteReader();
            while (rd_new2.Read())
            {
                cmd_notif2 = new SqlCommand("SELECT * FROM Tab_notification WHERE med_id = " + rd_new2["Tab_medID"].ToString() + " and (Type_notif=2 or Type_notif=-2)", conn);
                rd_notif2 = cmd_notif2.ExecuteReader();
                if (rd_notif2.HasRows)
                {

                    using (cmd_notif2 = new SqlCommand("UPDATE Tab_notification SET Date=@date_courant WHERE med_id=@ID and (Type_notif=2 or Type_notif=-2)", conn))
                    {
                        cmd_notif2.Parameters.Add(new SqlParameter("@date_courant", SqlDbType.DateTime)).Value = date_courant;
                        cmd_notif2.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = rd_new2["Tab_medID"];
                    }
                    rd_notif2 = cmd_notif2.ExecuteReader();
                }
                else
                {
                    using (cmd_notif2 = new SqlCommand("INSERT INTO Tab_notification([med_id],[Date],[Type_notif]) values ( @ID , @date_courant , 2)", conn))
                    {
                        cmd_notif2.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = rd_new2["Tab_medID"];
                        cmd_notif2.Parameters.Add(new SqlParameter("@date_courant", SqlDbType.DateTime)).Value = date_courant;
                    }
                    rd_notif2 = cmd_notif2.ExecuteReader();
                }
                rd_notif2.Close();
            }
            rd_new2.Close();
            using (cmd_new2 = new SqlCommand("SELECT * FROM TabRestitue WHERE DateDePeremption < @date_min", conn))
            {
                cmd_new2.Parameters.Add(new SqlParameter("@date_min", SqlDbType.Date)).Value = date_min.Date;
            }
            rd_new2 = cmd_new2.ExecuteReader();
            while (rd_new2.Read())
            {
                cmd_notif2 = new SqlCommand("SELECT * FROM Tab_notification WHERE med_id = " + rd_new2["Tab_medID"].ToString() + " and (Type_notif=4 or Type_notif=-4)", conn);
                rd_notif2 = cmd_notif2.ExecuteReader();
                if (rd_notif2.HasRows)
                {

                    using (cmd_notif2 = new SqlCommand("UPDATE Tab_notification SET Date=@date_courant WHERE med_id=@ID and (Type_notif=4 or Type_notif=-4)", conn))
                    {
                        cmd_notif2.Parameters.Add(new SqlParameter("@date_courant", SqlDbType.DateTime)).Value = date_courant;
                        cmd_notif2.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = rd_new2["Tab_medID"];
                    }
                    rd_notif2 = cmd_notif2.ExecuteReader();
                }
                else
                {
                    using (cmd_notif2 = new SqlCommand("INSERT INTO Tab_notification([med_id],[Date],[Type_notif]) values ( @ID , @date_courant , 4)", conn))
                    {
                        cmd_notif2.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = rd_new2["Tab_medID"];
                        cmd_notif2.Parameters.Add(new SqlParameter("@date_courant", SqlDbType.DateTime)).Value = date_courant;
                    }
                    rd_notif2 = cmd_notif2.ExecuteReader();
                }
                rd_notif2.Close();
            }
            rd_new2.Close();
            using (cmd_new2 = new SqlCommand("SELECT * FROM Bien_etre WHERE DateDePeremption < @date_min", conn))
            {
                cmd_new2.Parameters.Add(new SqlParameter("@date_min", SqlDbType.Date)).Value = date_min.Date;
            }
            rd_new2 = cmd_new2.ExecuteReader();
            while (rd_new2.Read())
            {
                cmd_notif2 = new SqlCommand("SELECT * FROM Tab_notification WHERE [Marque] = '" + rd_new2["Marque"].ToString() + "' and [Type] = '" + rd_new2["Type"].ToString() + "' and (Type_notif=6 or Type_notif=-6)", conn);
                rd_notif2 = cmd_notif2.ExecuteReader();
                if (rd_notif2.HasRows)
                {

                    using (cmd_notif2 = new SqlCommand("UPDATE Tab_notification SET Date=@date_courant WHERE [Marque] = @marque and [Type] = @type and (Type_notif=6 or Type_notif=-6)", conn))
                    {
                        cmd_notif2.Parameters.Add(new SqlParameter("@date_courant", SqlDbType.DateTime)).Value = date_courant;
                        cmd_notif2.Parameters.Add(new SqlParameter("@marque", SqlDbType.VarChar)).Value = rd_new2["Marque"];
                        cmd_notif2.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar)).Value = rd_new2["Type"];
                    }
                    rd_notif2 = cmd_notif2.ExecuteReader();
                }
                else
                {
                    using (cmd_notif2 = new SqlCommand("INSERT INTO Tab_notification([Date],[Type_notif],[Marque],[Type]) values (@date_courant , 6 , @marque , @type)", conn))
                    {
                        cmd_notif2.Parameters.Add(new SqlParameter("@date_courant", SqlDbType.DateTime)).Value = date_courant;
                        cmd_notif2.Parameters.Add(new SqlParameter("@marque", SqlDbType.VarChar)).Value = rd_new2["Marque"];
                        cmd_notif2.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar)).Value = rd_new2["Type"];
                    }
                    rd_notif2 = cmd_notif2.ExecuteReader();
                }
                rd_notif2.Close();
            }
            rd_new2.Close();
            if (conn.State == ConnectionState.Open) conn.Close();
        }
        public void open_Click(object sender, RoutedEventArgs e)
        {
            Notification notif;
            BrushConverter bc = new BrushConverter();
            String text = "Aucune nouvelle notification";
            int jours_reste, i = 0;
            stackpanel_notif.Children.Clear();
            cmd_notif = new SqlCommand("SELECT * FROM [dbo].[Tab_notification] ORDER BY Date desc", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            rd_notif = cmd_notif.ExecuteReader();
            while (rd_notif.Read())
            {
                if (rd_notif["Type_notif"].ToString() == "1" || rd_notif["Type_notif"].ToString() == "2" || rd_notif["Type_notif"].ToString() == "4")
                {
                    cmd_med = new SqlCommand("SELECT * FROM [dbo].[Tab_med] WHERE ID = " + rd_notif["med_id"].ToString(), conn);
                    rd_med = cmd_med.ExecuteReader();
                    rd_med.Read();
                    switch (rd_notif["Type_notif"].ToString())
                    {
                        case "1":
                            cmd_new = new SqlCommand("SELECT SUM(Quantite) as somm FROM [dbo].[Tab_NEW] WHERE Tab_medID = " + rd_notif["med_id"].ToString(), conn);
                            rd_new = cmd_new.ExecuteReader();
                            rd_new.Read();
                            if ((Int32)rd_new["somm"] > 0)
                                text = "Il reste seulement " + rd_new["somm"].ToString() + " boites de médicament";
                            else
                                text = "Il reste aucune boite de médicament";
                            break;

                        case "2":
                            cmd_new = new SqlCommand("SELECT * FROM [dbo].[Tab_NEW] WHERE Tab_medID = " + rd_notif["med_id"].ToString() + " ORDER BY DateDePeremption", conn);
                            rd_new = cmd_new.ExecuteReader();
                            rd_new.Read();
                            jours_reste = (Convert.ToDateTime(rd_new["DateDePeremption"]) - DateTime.Now).Days;
                            if (jours_reste >= 1)
                                text = "Il reste moins que " + (jours_reste + 1) + " jours pour la date \nde peremption de médicament";
                            else
                                text = "Ce médicament devient périmé";
                            break;

                        case "4":
                            cmd_new = new SqlCommand("SELECT * FROM [dbo].[TabRestitue] WHERE Tab_medID = " + rd_notif["med_id"].ToString() + " ORDER BY DateDePeremption", conn);
                            rd_new = cmd_new.ExecuteReader();
                            rd_new.Read();
                            jours_reste = (Convert.ToDateTime(rd_new["DateDePeremption"]) - DateTime.Now).Days;
                            if (jours_reste >= 1)
                                text = "Il reste moins que " + (jours_reste + 1) + " jours pour la date \nde peremption de médicament (Restitue)";
                            else
                                text = "Ce médicament (Restitue) devient périmé";
                            break;
                    }
                    notif = new Notification();
                    notif.id_med = rd_notif["med_id"].ToString();
                    notif.titre.Content = text;
                    notif.dci.Content = rd_med["DCI"].ToString();
                    notif.marque.Content = rd_med["Marque"].ToString();
                    rd_med.Close();
                    if (rd_notif["Type_notif"].ToString() == "1")
                    {
                        notif.type_notif = "1";
                        notif.med_qnt.Visibility = Visibility.Visible;
                    }
                    if (rd_notif["Type_notif"].ToString() == "2")
                    {
                        notif.type_notif = "2";
                        notif.med_date.Visibility = Visibility.Visible;
                    }
                    if (rd_notif["Type_notif"].ToString() == "4")
                    {
                        notif.type_notif = "4";
                        notif.med_date.Visibility = Visibility.Visible;
                    }
                    stackpanel_notif.Children.Add(notif);
                    i++;
                }
                if (rd_notif["Type_notif"].ToString() == "5" || rd_notif["Type_notif"].ToString() == "6")
                {
                    cmd_med = new SqlCommand("SELECT * FROM [dbo].[Bien_etre] WHERE [Marque] = '" + rd_notif["Marque"].ToString() + "' and [Type] = '" + rd_notif["Type"].ToString() + "'", conn);
                    rd_med = cmd_med.ExecuteReader();
                    rd_med.Read();
                    switch (rd_notif["Type_notif"].ToString())
                    {
                        case "5":
                            cmd_new = new SqlCommand("SELECT SUM(Quantite) as somm FROM [dbo].[Bien_etre] WHERE [Marque] = '" + rd_notif["Marque"].ToString() + "' and [Type] = '" + rd_notif["Type"].ToString() + "'", conn);
                            rd_new = cmd_new.ExecuteReader();
                            rd_new.Read();
                            if ((Int32)rd_new["somm"] > 0)
                                text = "Il reste seulement " + rd_new["somm"].ToString() + " boites de produit bien etre";
                            else
                                text = "Il reste aucune boite de produit bien etre";
                            break;

                        case "6":
                            cmd_new = new SqlCommand("SELECT * FROM [dbo].[Bien_etre] WHERE [Marque] = '" + rd_notif["Marque"].ToString() + "' and [Type] = '" + rd_notif["Type"].ToString() + "' ORDER BY DateDePeremption", conn);
                            rd_new = cmd_new.ExecuteReader();
                            rd_new.Read();
                            jours_reste = (Convert.ToDateTime(rd_new["DateDePeremption"]) - DateTime.Now).Days;
                            if (jours_reste >= 1)
                                text = "Il reste moins que " + (jours_reste + 1) + " jours pour la date \nde peremption de produit bien etre";
                            else
                                text = "Ce produit bien etre devient périmé";
                            break;
                    }
                    notif = new Notification();
                    notif.titre.Content = text;
                    notif.marque.Content = rd_med["Marque"].ToString();
                    notif.label.Content = "   Type :";
                    notif.dci.Content = rd_med["Type"].ToString();
                    rd_med.Close();
                    if (rd_notif["Type_notif"].ToString() == "5")
                    {
                        notif.type_notif = "5";
                        notif.b1_qnt.Visibility = Visibility.Visible;
                    }
                    if (rd_notif["Type_notif"].ToString() == "6")
                    {
                        notif.type_notif = "6";
                        notif.b1_date.Visibility = Visibility.Visible;
                    }
                    stackpanel_notif.Children.Add(notif);
                    i++;
                }
            }
            rd_notif.Close();
            if (conn.State == ConnectionState.Open) conn.Close();
            if (i == 0)
            {
                Label lab = new Label();
                lab = new Label();
                lab.HorizontalAlignment = HorizontalAlignment.Center;
                lab.MinHeight = 100;
                lab.FontSize = 35;
                lab.BorderThickness = new Thickness(0, 210, 0, 0);
                lab.Foreground = (Brush)bc.ConvertFrom("#EEEEF2");
                lab.Content = text;
                stackpanel_notif.Children.Add(lab);
            }
            popup1.IsOpen = true;
        }


        private void deconnecter(object sender, RoutedEventArgs e)
        {
            log_in a = new log_in();
            a.Show();
            this.Hide();
        }

    }
}
