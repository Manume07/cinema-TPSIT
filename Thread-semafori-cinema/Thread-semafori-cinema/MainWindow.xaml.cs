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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Thread_semafori_cinema
{
    public partial class MainWindow : Window
    {
        bool prenotato = false;
        public int[] PostiOccupatiPrimoU = new int[16];
        public int[] PostiOccupatiSecondoU = new int[16];
        bool secondoUtente = false;
        int[] PostiGiaPrenotatiDalSecondo = new int[16];
        FinestraSecondoUtente secondaFinestra;
        public object SemaforoThread = new object();
        Random rndGenerale = new Random(); // Unico Random per la gara
        public MainWindow()
        {

            InitializeComponent();
            secondaFinestra = new FinestraSecondoUtente(this);
            secondaFinestra.Left = 900;
            secondaFinestra.Top = 100;
            secondaFinestra.Show();

        }
        // aggiorno i bottoni dei posti in un nuovo oclore rosso se occupato, verde se libero e li salvo nell'array
        #region Click sui posti
        private void BtnPosto1_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde1.Visibility == Visibility.Visible)
            {
                img_PostoVerde1.Visibility = Visibility.Hidden;
                img_PostoRosso1.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[0] = 1;
                PostiOccupatiSecondoU[0] = 1;
            }
            else
            {
                img_PostoVerde1.Visibility = Visibility.Visible;
                img_PostoRosso1.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[0] = 0;
                PostiOccupatiSecondoU[0] = 0;
            }
        }


        private void BtnPosto2_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde2.Visibility == Visibility.Visible)
            {
                img_PostoVerde2.Visibility = Visibility.Hidden;
                img_PostoRosso2.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[1] = 2;
                PostiOccupatiSecondoU[1] = 2;
            }
            else
            {
                img_PostoVerde2.Visibility = Visibility.Visible;
                img_PostoRosso2.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[1] = 0;
                PostiOccupatiSecondoU[1] = 0;
            }
        }

        private void BtnPosto3_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde3.Visibility == Visibility.Visible)
            {
                img_PostoVerde3.Visibility = Visibility.Hidden;
                img_PostoRosso3.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[2] = 3;
                PostiOccupatiSecondoU[2] = 3;
            }
            else
            {
                img_PostoVerde3.Visibility = Visibility.Visible;
                img_PostoRosso3.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[2] = 0;
                PostiOccupatiSecondoU[2] = 0;
            }
        }

        private void BtnPosto4_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde4.Visibility == Visibility.Visible)
            {
                img_PostoVerde4.Visibility = Visibility.Hidden;
                img_PostoRosso4.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[3] = 4;
                PostiOccupatiSecondoU[3] = 4;
            }
            else
            {
                img_PostoVerde4.Visibility = Visibility.Visible;
                img_PostoRosso4.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[3] = 0;
                PostiOccupatiSecondoU[3] = 0;
            }
        }

        private void BtnPosto5_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde5.Visibility == Visibility.Visible)
            {
                img_PostoVerde5.Visibility = Visibility.Hidden;
                img_PostoRosso5.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[4] = 5;
                PostiOccupatiSecondoU[4] = 5;
            }
            else
            {
                img_PostoVerde5.Visibility = Visibility.Visible;
                img_PostoRosso5.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[4] = 0;
                PostiOccupatiSecondoU[4] = 0;
            }
        }

        private void BtnPosto6_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde6.Visibility == Visibility.Visible)
            {
                img_PostoVerde6.Visibility = Visibility.Hidden;
                img_PostoRosso6.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[5] = 6;
                PostiOccupatiSecondoU[5] = 6;
            }
            else
            {
                img_PostoVerde6.Visibility = Visibility.Visible;
                img_PostoRosso6.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[5] = 0;
                PostiOccupatiSecondoU[5] = 0;
            }
        }

        private void BtnPosto7_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde7.Visibility == Visibility.Visible)
            {
                img_PostoVerde7.Visibility = Visibility.Hidden;
                img_PostoRosso7.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[6] = 7;
                PostiOccupatiSecondoU[6] = 7;
            }
            else
            {
                img_PostoVerde7.Visibility = Visibility.Visible;
                img_PostoRosso7.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[6] = 0;
                PostiOccupatiSecondoU[6] = 0;
            }
        }

        private void BtnPosto8_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde8.Visibility == Visibility.Visible)
            {
                img_PostoVerde8.Visibility = Visibility.Hidden;
                img_PostoRosso8.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[7] = 8;
                PostiOccupatiSecondoU[7] = 8;
            }
            else
            {
                img_PostoVerde8.Visibility = Visibility.Visible;
                img_PostoRosso8.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[7] = 0;
                PostiOccupatiSecondoU[7] = 0;
            }
        }

        private void BtnPosto9_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde9.Visibility == Visibility.Visible)
            {
                img_PostoVerde9.Visibility = Visibility.Hidden;
                img_PostoRosso9.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[8] = 9;
                PostiOccupatiSecondoU[8] = 9;
            }
            else
            {
                img_PostoVerde9.Visibility = Visibility.Visible;
                img_PostoRosso9.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[8] = 0;
                PostiOccupatiSecondoU[8] = 0;
            }
        }

        private void BtnPosto10_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde10.Visibility == Visibility.Visible)
            {
                img_PostoVerde10.Visibility = Visibility.Hidden;
                img_PostoRosso10.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[9] = 10;
                PostiOccupatiSecondoU[9] = 10;
            }
            else
            {
                img_PostoVerde10.Visibility = Visibility.Visible;
                img_PostoRosso10.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[9] = 0;
                PostiOccupatiSecondoU[9] = 0;
            }
        }

        private void BtnPosto11_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde11.Visibility == Visibility.Visible)
            {
                img_PostoVerde11.Visibility = Visibility.Hidden;
                img_PostoRosso11.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[10] = 11;
                PostiOccupatiSecondoU[10] = 11;
            }
            else
            {
                img_PostoVerde11.Visibility = Visibility.Visible;
                img_PostoRosso11.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[10] = 0;
                PostiOccupatiSecondoU[10] = 0;
            }
        }

        private void BtnPosto12_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde12.Visibility == Visibility.Visible)
            {
                img_PostoVerde12.Visibility = Visibility.Hidden;
                img_PostoRosso12.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[11] = 12;
                PostiOccupatiSecondoU[11] = 12;
            }
            else
            {
                img_PostoVerde12.Visibility = Visibility.Visible;
                img_PostoRosso12.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[11] = 0;
                PostiOccupatiSecondoU[11] = 0;
            }
        }

        private void BtnPosto13_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde13.Visibility == Visibility.Visible)
            {
                img_PostoVerde13.Visibility = Visibility.Hidden;
                img_PostoRosso13.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[12] = 13;
                PostiOccupatiSecondoU[12] = 13;
            }
            else
            {
                img_PostoVerde13.Visibility = Visibility.Visible;
                img_PostoRosso13.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[12] = 0;
                PostiOccupatiSecondoU[12] = 0;
            }
        }

        private void BtnPosto14_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde14.Visibility == Visibility.Visible)
            {
                img_PostoVerde14.Visibility = Visibility.Hidden;
                img_PostoRosso14.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[13] = 14;
                PostiOccupatiSecondoU[13] = 14;
            }
            else
            {
                img_PostoVerde14.Visibility = Visibility.Visible;
                img_PostoRosso14.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[13] = 0;
                PostiOccupatiSecondoU[13] = 0;
            }
        }

        private void BtnPosto15_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde15.Visibility == Visibility.Visible)
            {
                img_PostoVerde15.Visibility = Visibility.Hidden;
                img_PostoRosso15.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[14] = 15;
                PostiOccupatiSecondoU[14] = 15;
            }
            else
            {
                img_PostoVerde15.Visibility = Visibility.Visible;
                img_PostoRosso15.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[14] = 0;
                PostiOccupatiSecondoU[14] = 0;
            }
        }

        private void BtnPosto16_Click(object sender, RoutedEventArgs e)
        {
            if (img_PostoVerde16.Visibility == Visibility.Visible)
            {
                img_PostoVerde16.Visibility = Visibility.Hidden;
                img_PostoRosso16.Visibility = Visibility.Visible;
                PostiOccupatiPrimoU[15] = 16;
                PostiOccupatiSecondoU[15] = 16;
            }
            else
            {
                img_PostoVerde16.Visibility = Visibility.Visible;
                img_PostoRosso16.Visibility = Visibility.Hidden;
                PostiOccupatiPrimoU[15] = 0;
                PostiOccupatiSecondoU[15] = 0;
            }
        }
        #endregion

        public void ResetPosti_Click(object sender, RoutedEventArgs e)
        {
            EseguiResetLocale(); 

            if (secondaFinestra != null)
            {
                secondaFinestra.EseguiResetLocale(); 
            }
        }
        public void EseguiResetLocale()
        {
            img_PostoRosso1.Visibility = Visibility.Hidden; img_PostoVerde1.Visibility = Visibility.Visible; BtnPosto1.IsHitTestVisible = true;
            img_PostoRosso2.Visibility = Visibility.Hidden; img_PostoVerde2.Visibility = Visibility.Visible; BtnPosto2.IsHitTestVisible = true;
            img_PostoRosso3.Visibility = Visibility.Hidden; img_PostoVerde3.Visibility = Visibility.Visible; BtnPosto3.IsHitTestVisible = true;
            img_PostoRosso4.Visibility = Visibility.Hidden; img_PostoVerde4.Visibility = Visibility.Visible; BtnPosto4.IsHitTestVisible = true;
            img_PostoRosso5.Visibility = Visibility.Hidden; img_PostoVerde5.Visibility = Visibility.Visible; BtnPosto5.IsHitTestVisible = true;
            img_PostoRosso6.Visibility = Visibility.Hidden; img_PostoVerde6.Visibility = Visibility.Visible; BtnPosto6.IsHitTestVisible = true;
            img_PostoRosso7.Visibility = Visibility.Hidden; img_PostoVerde7.Visibility = Visibility.Visible; BtnPosto7.IsHitTestVisible = true;
            img_PostoRosso8.Visibility = Visibility.Hidden; img_PostoVerde8.Visibility = Visibility.Visible; BtnPosto8.IsHitTestVisible = true;
            img_PostoRosso9.Visibility = Visibility.Hidden; img_PostoVerde9.Visibility = Visibility.Visible; BtnPosto9.IsHitTestVisible = true;
            img_PostoRosso10.Visibility = Visibility.Hidden; img_PostoVerde10.Visibility = Visibility.Visible; BtnPosto10.IsHitTestVisible = true;
            img_PostoRosso11.Visibility = Visibility.Hidden; img_PostoVerde11.Visibility = Visibility.Visible; BtnPosto11.IsHitTestVisible = true;
            img_PostoRosso12.Visibility = Visibility.Hidden; img_PostoVerde12.Visibility = Visibility.Visible; BtnPosto12.IsHitTestVisible = true;
            img_PostoRosso13.Visibility = Visibility.Hidden; img_PostoVerde13.Visibility = Visibility.Visible; BtnPosto13.IsHitTestVisible = true;
            img_PostoRosso14.Visibility = Visibility.Hidden; img_PostoVerde14.Visibility = Visibility.Visible; BtnPosto14.IsHitTestVisible = true;
            img_PostoRosso15.Visibility = Visibility.Hidden; img_PostoVerde15.Visibility = Visibility.Visible; BtnPosto15.IsHitTestVisible = true;
            img_PostoRosso16.Visibility = Visibility.Hidden; img_PostoVerde16.Visibility = Visibility.Visible; BtnPosto16.IsHitTestVisible = true;

            // Reset array
            for (int i = 0; i < 16; i++)
            {
                PostiOccupatiPrimoU[i] = 0;
                PostiGiaPrenotatiDalSecondo[i] = 0;
            }
        }

        private void btnPrenota_Click(object sender, RoutedEventArgs e)
        {
            string PostiOccupati = "";
            bool trovato = false;
            bool miHannoRubatoUnPosto = false;
            for (int i = 0; i < 16; i++)
            {
                if (PostiOccupatiPrimoU[i] != 0)
                {
                    if (PostiGiaPrenotatiDalSecondo[i] != 0)
                    {
                        PostiOccupatiPrimoU[i] = 0;
                        miHannoRubatoUnPosto = true;
                        // posto già prenotato dal primo utente
                        switch (i)
                        {
                            case 0: img_PostoRosso1.Visibility = Visibility.Visible; img_PostoVerde1.Visibility = Visibility.Hidden; BtnPosto1.IsHitTestVisible = false; break;
                            case 1: img_PostoRosso2.Visibility = Visibility.Visible; img_PostoVerde2.Visibility = Visibility.Hidden; BtnPosto2.IsHitTestVisible = false; break;
                            case 2: img_PostoRosso3.Visibility = Visibility.Visible; img_PostoVerde3.Visibility = Visibility.Hidden; BtnPosto3.IsHitTestVisible = false; break;
                            case 3: img_PostoRosso4.Visibility = Visibility.Visible; img_PostoVerde4.Visibility = Visibility.Hidden; BtnPosto4.IsHitTestVisible = false; break;
                            case 4: img_PostoRosso5.Visibility = Visibility.Visible; img_PostoVerde5.Visibility = Visibility.Hidden; BtnPosto5.IsHitTestVisible = false; break;
                            case 5: img_PostoRosso6.Visibility = Visibility.Visible; img_PostoVerde6.Visibility = Visibility.Hidden; BtnPosto6.IsHitTestVisible = false; break;
                            case 6: img_PostoRosso7.Visibility = Visibility.Visible; img_PostoVerde7.Visibility = Visibility.Hidden; BtnPosto7.IsHitTestVisible = false; break;
                            case 7: img_PostoRosso8.Visibility = Visibility.Visible; img_PostoVerde8.Visibility = Visibility.Hidden; BtnPosto8.IsHitTestVisible = false; break;
                            case 8: img_PostoRosso9.Visibility = Visibility.Visible; img_PostoVerde9.Visibility = Visibility.Hidden; BtnPosto9.IsHitTestVisible = false; break;
                            case 9: img_PostoRosso10.Visibility = Visibility.Visible; img_PostoVerde10.Visibility = Visibility.Hidden; BtnPosto10.IsHitTestVisible = false; break;
                            case 10: img_PostoRosso11.Visibility = Visibility.Visible; img_PostoVerde11.Visibility = Visibility.Hidden; BtnPosto11.IsHitTestVisible = false; break;
                            case 11: img_PostoRosso12.Visibility = Visibility.Visible; img_PostoVerde12.Visibility = Visibility.Hidden; BtnPosto12.IsHitTestVisible = false; break;
                            case 12: img_PostoRosso13.Visibility = Visibility.Visible; img_PostoVerde13.Visibility = Visibility.Hidden; BtnPosto13.IsHitTestVisible = false; break;
                            case 13: img_PostoRosso14.Visibility = Visibility.Visible; img_PostoVerde14.Visibility = Visibility.Hidden; BtnPosto14.IsHitTestVisible = false; break;
                            case 14: img_PostoRosso15.Visibility = Visibility.Visible; img_PostoVerde15.Visibility = Visibility.Hidden; BtnPosto15.IsHitTestVisible = false; break;
                            case 15: img_PostoRosso16.Visibility = Visibility.Visible; img_PostoVerde16.Visibility = Visibility.Hidden; BtnPosto16.IsHitTestVisible = false; break;
                        }
                    }
                }
            }
            for (int i = 0; i < 16; i++)
            {
                if (PostiOccupatiPrimoU[i] != 0)
                {
                    PostiOccupati = PostiOccupati + " " + PostiOccupatiPrimoU[i] + ",";
                    trovato = true;
                }
            }

            // avviso 
            if (miHannoRubatoUnPosto)
            {
                MessageBox.Show("Attenzione! Uno o più posti che avevi scelto erano già stati confermati dall'altro utente. Sono tornati verdi.");
            }

            if (!trovato)
            {
                if (!miHannoRubatoUnPosto)
                {
                    MessageBox.Show("Prenota almeno un posto");
                }
            }
            else
            {
                PostiOccupati = PostiOccupati.TrimEnd(',');
                MessageBox.Show($"Hai prenotato i posti: {PostiOccupati}");
            }

            // invio i dati alla seconda finestra, così aggiorna i posti occupati dal secondo utente anche lì
            if (secondaFinestra != null)
            {
                secondaFinestra.RiceviArrayDalPrimoUtente(PostiOccupatiPrimoU);
            }
        }

        public void RiceviArrayDalSecondoUtente(int[] arrayRicevuto)
        {
            for (int i = 0; i < 16; i++)
            {
                PostiGiaPrenotatiDalSecondo[i] = arrayRicevuto[i];
            }

            // IsHitTestVisible = false: Non si può più cliccare sul posto
            if (arrayRicevuto[0] != 0) { img_PostoRosso1.Visibility = Visibility.Visible; img_PostoVerde1.Visibility = Visibility.Hidden; BtnPosto1.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[0] == 0) { img_PostoRosso1.Visibility = Visibility.Hidden; img_PostoVerde1.Visibility = Visibility.Visible; BtnPosto1.IsHitTestVisible = true; }

            if (arrayRicevuto[1] != 0) { img_PostoRosso2.Visibility = Visibility.Visible; img_PostoVerde2.Visibility = Visibility.Hidden; BtnPosto2.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[1] == 0) { img_PostoRosso2.Visibility = Visibility.Hidden; img_PostoVerde2.Visibility = Visibility.Visible; BtnPosto2.IsHitTestVisible = true; }

            if (arrayRicevuto[2] != 0) { img_PostoRosso3.Visibility = Visibility.Visible; img_PostoVerde3.Visibility = Visibility.Hidden; BtnPosto3.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[2] == 0) { img_PostoRosso3.Visibility = Visibility.Hidden; img_PostoVerde3.Visibility = Visibility.Visible; BtnPosto3.IsHitTestVisible = true; }

            if (arrayRicevuto[3] != 0) { img_PostoRosso4.Visibility = Visibility.Visible; img_PostoVerde4.Visibility = Visibility.Hidden; BtnPosto4.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[3] == 0) { img_PostoRosso4.Visibility = Visibility.Hidden; img_PostoVerde4.Visibility = Visibility.Visible; BtnPosto4.IsHitTestVisible = true; }

            if (arrayRicevuto[4] != 0) { img_PostoRosso5.Visibility = Visibility.Visible; img_PostoVerde5.Visibility = Visibility.Hidden; BtnPosto5.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[4] == 0) { img_PostoRosso5.Visibility = Visibility.Hidden; img_PostoVerde5.Visibility = Visibility.Visible; BtnPosto5.IsHitTestVisible = true; }

            if (arrayRicevuto[5] != 0) { img_PostoRosso6.Visibility = Visibility.Visible; img_PostoVerde6.Visibility = Visibility.Hidden; BtnPosto6.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[5] == 0) { img_PostoRosso6.Visibility = Visibility.Hidden; img_PostoVerde6.Visibility = Visibility.Visible; BtnPosto6.IsHitTestVisible = true; }

            if (arrayRicevuto[6] != 0) { img_PostoRosso7.Visibility = Visibility.Visible; img_PostoVerde7.Visibility = Visibility.Hidden; BtnPosto7.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[6] == 0) { img_PostoRosso7.Visibility = Visibility.Hidden; img_PostoVerde7.Visibility = Visibility.Visible; BtnPosto7.IsHitTestVisible = true; }

            if (arrayRicevuto[7] != 0) { img_PostoRosso8.Visibility = Visibility.Visible; img_PostoVerde8.Visibility = Visibility.Hidden; BtnPosto8.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[7] == 0) { img_PostoRosso8.Visibility = Visibility.Hidden; img_PostoVerde8.Visibility = Visibility.Visible; BtnPosto8.IsHitTestVisible = true; }

            if (arrayRicevuto[8] != 0) { img_PostoRosso9.Visibility = Visibility.Visible; img_PostoVerde9.Visibility = Visibility.Hidden; BtnPosto9.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[8] == 0) { img_PostoRosso9.Visibility = Visibility.Hidden; img_PostoVerde9.Visibility = Visibility.Visible; BtnPosto9.IsHitTestVisible = true; }

            if (arrayRicevuto[9] != 0) { img_PostoRosso10.Visibility = Visibility.Visible; img_PostoVerde10.Visibility = Visibility.Hidden; BtnPosto10.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[9] == 0) { img_PostoRosso10.Visibility = Visibility.Hidden; img_PostoVerde10.Visibility = Visibility.Visible; BtnPosto10.IsHitTestVisible = true; }

            if (arrayRicevuto[10] != 0) { img_PostoRosso11.Visibility = Visibility.Visible; img_PostoVerde11.Visibility = Visibility.Hidden; BtnPosto11.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[10] == 0) { img_PostoRosso11.Visibility = Visibility.Hidden; img_PostoVerde11.Visibility = Visibility.Visible; BtnPosto11.IsHitTestVisible = true; }

            if (arrayRicevuto[11] != 0) { img_PostoRosso12.Visibility = Visibility.Visible; img_PostoVerde12.Visibility = Visibility.Hidden; BtnPosto12.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[11] == 0) { img_PostoRosso12.Visibility = Visibility.Hidden; img_PostoVerde12.Visibility = Visibility.Visible; BtnPosto12.IsHitTestVisible = true; }

            if (arrayRicevuto[12] != 0) { img_PostoRosso13.Visibility = Visibility.Visible; img_PostoVerde13.Visibility = Visibility.Hidden; BtnPosto13.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[12] == 0) { img_PostoRosso13.Visibility = Visibility.Hidden; img_PostoVerde13.Visibility = Visibility.Visible; BtnPosto13.IsHitTestVisible = true; }

            if (arrayRicevuto[13] != 0) { img_PostoRosso14.Visibility = Visibility.Visible; img_PostoVerde14.Visibility = Visibility.Hidden; BtnPosto14.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[13] == 0) { img_PostoRosso14.Visibility = Visibility.Hidden; img_PostoVerde14.Visibility = Visibility.Visible; BtnPosto14.IsHitTestVisible = true; }

            if (arrayRicevuto[14] != 0) { img_PostoRosso15.Visibility = Visibility.Visible; img_PostoVerde15.Visibility = Visibility.Hidden; BtnPosto15.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[14] == 0) { img_PostoRosso15.Visibility = Visibility.Hidden; img_PostoVerde15.Visibility = Visibility.Visible; BtnPosto15.IsHitTestVisible = true; }

            if (arrayRicevuto[15] != 0) { img_PostoRosso16.Visibility = Visibility.Visible; img_PostoVerde16.Visibility = Visibility.Hidden; BtnPosto16.IsHitTestVisible = false; }
            else if (PostiOccupatiPrimoU[15] == 0) { img_PostoRosso16.Visibility = Visibility.Hidden; img_PostoVerde16.Visibility = Visibility.Visible; BtnPosto16.IsHitTestVisible = true; }
        }
        // Avvio il thread che simula la gara, se la seconda finestra è aperta avvio anche lì il thread
        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(LavoroThread));
            t1.Start();
            if (secondaFinestra != null)
            {
                secondaFinestra.AvviaThreadDiGara();
            }
        }
        public void AvviaThreadDiGara()
        {
            Thread t1 = new Thread(new ThreadStart(LavoroThread));
            t1.Start();
        }

        public void LavoroThread()
        {
            // ogni thread ha 3 tentavivi per prenotare un posto a caso, se il posto è già occupato, il tentativo va "a vuoto" e si passa al successivo
            for (int tentativi = 0; tentativi < 3; tentativi++)
            {
                Thread.Sleep(500);
                this.Dispatcher.Invoke(() =>
                {
                    lock (SemaforoThread)
                    {
                        int postoCasuale = rndGenerale.Next(0, 16);

                        // Controllo se il posto è libero dalla selezione manuale del primo utente (PostiOccupatiPrimoU) e se non è già stato prenotato dal secondo utente (PostiGiaPrenotatiDalSecondo)
                        if (PostiOccupatiPrimoU[postoCasuale] == 0 && PostiGiaPrenotatiDalSecondo[postoCasuale] == 0)
                        {
                            PostiOccupatiPrimoU[postoCasuale] = postoCasuale + 1;

                            switch (postoCasuale)
                            {
                                case 0: img_PostoRosso1.Visibility = Visibility.Visible; img_PostoVerde1.Visibility = Visibility.Hidden; BtnPosto1.IsHitTestVisible = false; break;
                                case 1: img_PostoRosso2.Visibility = Visibility.Visible; img_PostoVerde2.Visibility = Visibility.Hidden; BtnPosto2.IsHitTestVisible = false; break;
                                case 2: img_PostoRosso3.Visibility = Visibility.Visible; img_PostoVerde3.Visibility = Visibility.Hidden; BtnPosto3.IsHitTestVisible = false; break;
                                case 3: img_PostoRosso4.Visibility = Visibility.Visible; img_PostoVerde4.Visibility = Visibility.Hidden; BtnPosto4.IsHitTestVisible = false; break;
                                case 4: img_PostoRosso5.Visibility = Visibility.Visible; img_PostoVerde5.Visibility = Visibility.Hidden; BtnPosto5.IsHitTestVisible = false; break;
                                case 5: img_PostoRosso6.Visibility = Visibility.Visible; img_PostoVerde6.Visibility = Visibility.Hidden; BtnPosto6.IsHitTestVisible = false; break;
                                case 6: img_PostoRosso7.Visibility = Visibility.Visible; img_PostoVerde7.Visibility = Visibility.Hidden; BtnPosto7.IsHitTestVisible = false; break;
                                case 7: img_PostoRosso8.Visibility = Visibility.Visible; img_PostoVerde8.Visibility = Visibility.Hidden; BtnPosto8.IsHitTestVisible = false; break;
                                case 8: img_PostoRosso9.Visibility = Visibility.Visible; img_PostoVerde9.Visibility = Visibility.Hidden; BtnPosto9.IsHitTestVisible = false; break;
                                case 9: img_PostoRosso10.Visibility = Visibility.Visible; img_PostoVerde10.Visibility = Visibility.Hidden; BtnPosto10.IsHitTestVisible = false; break;
                                case 10: img_PostoRosso11.Visibility = Visibility.Visible; img_PostoVerde11.Visibility = Visibility.Hidden; BtnPosto11.IsHitTestVisible = false; break;
                                case 11: img_PostoRosso12.Visibility = Visibility.Visible; img_PostoVerde12.Visibility = Visibility.Hidden; BtnPosto12.IsHitTestVisible = false; break;
                                case 12: img_PostoRosso13.Visibility = Visibility.Visible; img_PostoVerde13.Visibility = Visibility.Hidden; BtnPosto13.IsHitTestVisible = false; break;
                                case 13: img_PostoRosso14.Visibility = Visibility.Visible; img_PostoVerde14.Visibility = Visibility.Hidden; BtnPosto14.IsHitTestVisible = false; break;
                                case 14: img_PostoRosso15.Visibility = Visibility.Visible; img_PostoVerde15.Visibility = Visibility.Hidden; BtnPosto15.IsHitTestVisible = false; break;
                                case 15: img_PostoRosso16.Visibility = Visibility.Visible; img_PostoVerde16.Visibility = Visibility.Hidden; BtnPosto16.IsHitTestVisible = false; break;
                            }

                            if (secondaFinestra != null)
                            {
                                secondaFinestra.RiceviArrayDalPrimoUtente(PostiOccupatiPrimoU);
                            }
                        }
                    }
                });
            }
        }
    }
}