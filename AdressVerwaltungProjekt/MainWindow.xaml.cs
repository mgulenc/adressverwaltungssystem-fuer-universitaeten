using System;
using System.Collections.Generic;
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
using System.Xml.Serialization;

namespace AdressVerwaltungProjekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> allePersonen = new List<Person>();
        string filtered = "";

        public MainWindow()
        {
            InitializeComponent();
            MusterPersonen();
            lb_Personen.ItemsSource = allePersonen;
            lb_Personen.Items.Refresh();
        }
        private void MusterPersonen()
        {
            Adresse studentAdresse = new Adresse("Wilhelminenhof Str.", "43", 10247, "Berlin", "Deutschland");
            Student student = new Student("Herr", "Tamer", "Hakan","01.01.1991", "12134240", studentAdresse,
                             "muster2020@gmail.com", 123456, 2, "Umweltinformatik", 2, true);
            Adresse studentAdresse2 = new Adresse("Tischstr.", "16", 14247, "Berlin", "Deutschland");
            Student student2 = new Student("Herr", "Karl", "Heinrich", "01.05.2000", "12134240", studentAdresse2,
                             "karl2020@gmail.com", 123456, 2, "Angewandte Informatik", 2, false);
            Adresse studentAdresse3 = new Adresse("Fensterstr.", "12", 15647, "Bremen", "Deutschland");
            Student student3 = new Student("Frau", "Angela", "Rosa", "22.09.1998", "92098740", studentAdresse3,
                             "angela10101@gmail.com", 123456, 2, "Fahrzeugtechnik", 5, true);
            Adresse mitarbeiterAdresse = new Adresse("Musterstr.", "53", 10249, "Hamburg", "Deutschland");
            Mitarbeiter mitarbeiter = new Mitarbeiter("Frau", "Selma", "Hayal", "06.03.1956", "121344240", mitarbeiterAdresse,
                             "frauselma001@gmail.com", "Sachbearbeiter", "C3");
            Adresse mitarbeiterAdresse2 = new Adresse("Hermannstr.", "90", 12249, "Frankfurt", "Deutschland");
            Mitarbeiter mitarbeiter2 = new Mitarbeiter("Frau", "Leila", "Blume", "02.01.1989", "67898940", mitarbeiterAdresse2,
                             "fraublume999@gmail.com", "Assistent", "C3");

            Adresse studentAdresse4 = new Adresse("Wilhelminenhof Str.", "43", 10247, "Berlin", "Deutschland");
            Student student4 = new Student("Herr", "Cenk", "Altan", "02.07.1993", "12134240", studentAdresse4,
                             "muster2020@gmail.com", 123456, 2, "Umweltinformatik", 2, true);
            Adresse studentAdresse5 = new Adresse("Tischstr.", "16", 14247, "Berlin", "Deutschland");
            Student student5 = new Student("Herr", "Marcel", "Müller", "02.10.1998","12134240", studentAdresse5,
                             "karl2020@gmail.com", 123456, 2, "Angewandte Informatik", 2, false);
            Adresse studentAdresse6 = new Adresse("Fensterstr.", "12", 15647, "Bremen", "Deutschland");
            Student student6 = new Student("Frau", "Lisa", "Meier", "02.01.1997", "92098740", studentAdresse6,
                             "angela10101@gmail.com", 123456, 2, "Fahrzeugtechnik", 5, true);
            Adresse mitarbeiterAdresse3 = new Adresse("Musterstr.", "53", 10249, "Hamburg", "Deutschland");
            Mitarbeiter mitarbeiter3 = new Mitarbeiter("Frau", "Petra", "Schmidt", "02.03.1989", "121344240", mitarbeiterAdresse3,
                             "frauselma001@gmail.com", "Sachbearbeiter", "C3");
            Adresse mitarbeiterAdresse4 = new Adresse("Hermannstr.", "90", 12249, "Frankfurt", "Deutschland");
            Mitarbeiter mitarbeiter4 = new Mitarbeiter("Herr", "Klaus", "Johnmeier", "02.01.1977", "67898940", mitarbeiterAdresse4,
                             "fraublume999@gmail.com", "Assistent", "C3");
            allePersonen.Add(student);
            allePersonen.Add(student2);
            allePersonen.Add(student3);
            allePersonen.Add(student4);
            allePersonen.Add(student5);
            allePersonen.Add(student6);
            allePersonen.Add(mitarbeiter);
            allePersonen.Add(mitarbeiter2);
            allePersonen.Add(mitarbeiter3);
            allePersonen.Add(mitarbeiter4);
        }
        public void FilterMitarbeiter()
        {
            List<Person> mitarbeiterListe = new List<Person>();
            foreach (Person item in allePersonen)
            {
                if (item.GetType() == typeof(Mitarbeiter))
                {
                    mitarbeiterListe.Add(item);
                }
            }
            lb_Personen.ItemsSource = mitarbeiterListe;
            lb_Personen.Items.Refresh();
        }
        public void FilterStudenten()
        {
            List<Person> studentListe = new List<Person>();
            foreach (Person item in allePersonen)
            {
                if (item.GetType() == typeof(Student))
                {
                    studentListe.Add(item);
                }
            }
            lb_Personen.ItemsSource = studentListe;
            lb_Personen.Items.Refresh();
        }
        private void bt_close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void bt_Add_Click(object sender, RoutedEventArgs e)
        {
            Window1 bearbeitung = new Window1();
            bearbeitung.ShowDialog();

            if (bearbeitung.DialogResult.HasValue && bearbeitung.DialogResult.Value)
            {
                allePersonen.Add(bearbeitung.zuBearbeitendePerson);

                if (filtered == "Mitarbeiter")
                {
                    FilterMitarbeiter();
                }
                else if (filtered == "Student")
                {
                    FilterStudenten();
                }
                else
                {
                    lb_Personen.Items.Refresh();
                }
            }
        }
        private void bt_Mitarbeiter_Click(object sender, RoutedEventArgs e)
        {
            filtered = "Mitarbeiter";
            FilterMitarbeiter();
        }
        private void bt_Student_Click(object sender, RoutedEventArgs e)
        {
            filtered = "Student";
            FilterStudenten();
        }
        private void bt_Alle_Click(object sender, RoutedEventArgs e)
        {
            filtered = "";
            lb_Personen.ItemsSource = allePersonen;
            lb_Personen.Items.Refresh();
        }
        private void bt_SortAZ_Click(object sender, RoutedEventArgs e)
        {
            allePersonen.Sort();
            if (filtered == "Mitarbeiter")
            {
                FilterMitarbeiter();
            }
            else if (filtered == "Student")
            {
                FilterStudenten();
            }
            else
            {
                lb_Personen.Items.Refresh();
            }
        }
        private void bt_SortZA_Click(object sender, RoutedEventArgs e)
        {
            allePersonen.Sort();
            allePersonen.Reverse();
            if (filtered == "Mitarbeiter")
            {
                FilterMitarbeiter();
            }
            else if (filtered == "Student")
            { 
                FilterStudenten();
            }
            else
            {
            lb_Personen.Items.Refresh();
            }

        }
        private void bt_SortAsc_Click(object sender, RoutedEventArgs e)
        {
            IComparer<Person> comparer = new ErstellungsDatumSortieren();
            allePersonen.Sort(comparer);
            if (filtered == "Mitarbeiter")
            {
                FilterMitarbeiter();
            }
            else if (filtered == "Student")
            {
                FilterStudenten();
            }
            else
            {
                lb_Personen.Items.Refresh();
            }

        }
        private void bt_SortDesc_Click(object sender, RoutedEventArgs e)
        {
            IComparer<Person> comparer = new ErstellungsDatumSortieren();
            allePersonen.Sort(comparer);
            allePersonen.Reverse();

            if (filtered == "Mitarbeiter")
            {
                FilterMitarbeiter();
            }
            else if (filtered == "Student")
            {
                FilterStudenten();
            }
            else
            {
                lb_Personen.Items.Refresh();
            }
        }
        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (lb_Personen.SelectedItem==null)
            {
                MessageBox.Show("Bitte wählen Sie eine Person zum Löschen aus!");
            }
            else
            {
                Person selectedPerson = (Person)lb_Personen.SelectedItem;
                var message = MessageBox.Show(selectedPerson.Vorname+" "+ selectedPerson.Nachname+" wird gelöscht!", "LÖSCHEN", MessageBoxButton.YesNo, MessageBoxImage.Stop);

                if (message == MessageBoxResult.Yes)
                {
                    allePersonen.Remove(selectedPerson);
                    if (filtered == "Mitarbeiter")
                    {
                        FilterMitarbeiter();
                    }
                    else if (filtered == "Student")
                    {
                        FilterStudenten();
                    }
                    else
                    {
                        lb_Personen.Items.Refresh();
                    }
                }
            }
        }
        private void bt_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (lb_Personen.SelectedItem != null)
            {
                Person person = (Person)lb_Personen.SelectedItem;
                Window1 bearbeitung = new Window1(person);
                bearbeitung.ShowDialog();

                if (bearbeitung.DialogResult.HasValue && bearbeitung.DialogResult.Value)
                {
                    allePersonen.Add(bearbeitung.zuBearbeitendePerson);
                    allePersonen.Remove(person);
                    if (filtered == "Mitarbeiter")
                    {
                        FilterMitarbeiter();
                    }
                    else if (filtered == "Student")
                    {
                        FilterStudenten();
                    }
                    else
                    {
                        lb_Personen.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Person zur Bearbeitung aus!");
            }
        }
        private void bt_Exportieren_SW_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter myStreamWriter = new StreamWriter("C:\\Users\\admin\\Desktop\\PersonenDaten.txt"))
            {
                foreach (Person daten in allePersonen)
                {
                    if (daten.GetType() == typeof(Student))
                    {
                        myStreamWriter.WriteLine("Student");
                        //studentendaten hinzugüfen
                    }
                    else
                    {
                        myStreamWriter.WriteLine("Mitarbeiter");
                        //mitarbeiterdaten hinzugüfen
                    }
                    myStreamWriter.Write(daten.Anrede);
                    myStreamWriter.Write(" "+daten.Vorname);
                    myStreamWriter.WriteLine(" "+daten.Nachname);
                    myStreamWriter.WriteLine("geb."+daten.Geburtsdatum);
                    myStreamWriter.WriteLine("Tel: "+daten.Telefon);
                    myStreamWriter.WriteLine(daten.Email);
                    myStreamWriter.WriteLine("***Adressdaten der Person:");
                    myStreamWriter.Write(daten.GetAdresse().Strasse);
                    myStreamWriter.WriteLine(daten.GetAdresse().Hausnummer);
                    myStreamWriter.Write(daten.GetAdresse().PLZ);
                    myStreamWriter.Write(","+daten.GetAdresse().Stadt);
                    myStreamWriter.WriteLine("/"+daten.GetAdresse().Land);
                    myStreamWriter.WriteLine("-------------------------------------------------");
                }
            }
        }
        private void bt_Exportieren_XS_Click(object sender, RoutedEventArgs e)
        {
            TextWriter personWriter = null;

            try
            {
                /*
                XmlSerializer studentSerializer = new XmlSerializer(typeof(Student));
                TextWriter studentWriter = new StreamWriter("C:\\Users\\admin\\Desktop\\StudentenListe.xml");

                XmlSerializer mitarbeiterSerializer = new XmlSerializer(typeof(Mitarbeiter));
                TextWriter mitarbeiterWriter = new StreamWriter("C:\\Users\\admin\\Desktop\\MitarbeiterListe.xml");

                foreach (Person person in allePersonen)
                {
                    if (person != null && person is Student)
                    {
                        studentSerializer.Serialize(studentWriter, person);
                    }
                    if (person != null && person is Mitarbeiter)
                    {
                        mitarbeiterSerializer.Serialize(mitarbeiterWriter, person);
                    }
                }
                studentWriter.Close();
                mitarbeiterWriter.Close();

                */

                XmlSerializer personSerializer = new XmlSerializer(typeof(List<Person>));
                personWriter = new StreamWriter("C:\\Users\\admin\\Desktop\\Personenliste.xml");
                personSerializer.Serialize(personWriter, allePersonen);
                lab_message.Visibility = Visibility.Visible;

                //MessageBox.Show("Daten wurden erfolgreich exportiert!");
            }
            catch (IOException ioex)
            {
                MessageBox.Show("Fehler beim Dateizugriff!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UnauthorizedAccessException uaex)
            {
                MessageBox.Show("Keine Berechtigung zum Dateizufriff!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Irgendein unbekannter Fehler ist aufgetreten.Message: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                personWriter.Close();
            }
        }  
        private void bt_Importieren_XS_Click(object sender, RoutedEventArgs e) 
        {
            XmlSerializer personenSerializer = new XmlSerializer(typeof(List<Person>));
            FileStream read = new FileStream("C:\\Users\\admin\\Desktop\\Personenliste.xml", FileMode.Open);
            List<Person> personListe = (List<Person>) personenSerializer.Deserialize(read);
            allePersonen.AddRange(personListe);
            lb_Personen.Items.Refresh();
        } 

    }
}
