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

namespace AdressVerwaltungProjekt
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private bool newPerson;
        public Person zuBearbeitendePerson;

        readonly List<string> AnredeListe = new List<string> { "Herr", "Frau", "Divers"};
        readonly List<string> TitelListe = new List<string> { "Prof.Dr.", "Dr.", "Assistent",""};
        public Window1() // Hinzufügen
        {
            InitializeComponent();
            cb_anrede.ItemsSource = AnredeListe;
            cb_titel.ItemsSource = TitelListe;
            newPerson = true;
        }
        public Window1(Person person) // Editieren
        {
            InitializeComponent();

            zuBearbeitendePerson = person;

            cb_anrede.ItemsSource = AnredeListe;
            cb_titel.ItemsSource = TitelListe;
            cb_anrede.SelectedItem = person.Anrede;
            tb_vorname.Text = person.Vorname;
            tb_nachname.Text = person.Nachname;
            dt_Geburtsdatum.SelectedDate = Convert.ToDateTime(person.Geburtsdatum);
            tb_email.Text = person.Email;
            tb_telefon.Text = person.Telefon;
            //Adresse
            tb_strasse.Text = person.GetAdresse().Strasse;
            tb_hausnummer.Text = person.GetAdresse().Hausnummer.ToString();
            tb_PLZ.Text = person.GetAdresse().PLZ.ToString();
            tb_stadt.Text = person.GetAdresse().Stadt;
            tb_land.Text = person.GetAdresse().Land;

            if (person.GetType() == typeof(Student))
            {
                var student = person as Student;
                rb_Student.IsChecked = true;
                tb_fachbereich.Text = student.Fachbereich.ToString();
                tb_fachsemester.Text = student.Fachsemester.ToString();
                tb_studingang.Text = student.Studiengang;
                tb_matrikelnummer.Text = student.Matrikelnummer.ToString();
                cb_bafoeg.IsChecked = student.Bafoeg;
            }
            else
            {
                var mitarbeiter = person as Mitarbeiter;
                rb_Mitarbeiter.IsChecked = true;
                tb_raum.Text = mitarbeiter.Raum;
                cb_titel.SelectedItem = mitarbeiter.Titel;
            }
            rb_Student.IsEnabled = false;
            rb_Mitarbeiter.IsEnabled = false;

        }
        private void bt_abbrechen_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(string.Format("Möchten Sie den Vorgang wirklich abbrechen?"),
                "ABBRECHEN ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
        private void rb_Student_Checked(object sender, RoutedEventArgs e)
        {
            cb_titel.IsEnabled = false;
            tb_raum.IsEnabled = false;

            tb_fachbereich.IsEnabled = true;
            tb_fachsemester.IsEnabled = true;
            tb_studingang.IsEnabled = true;
            tb_matrikelnummer.IsEnabled = true;
            cb_bafoeg.IsEnabled = true;
        }
        private void rb_Mitarbeiter_Checked(object sender, RoutedEventArgs e)
        {
            tb_fachbereich.IsEnabled = false;
            tb_fachsemester.IsEnabled = false;
            tb_studingang.IsEnabled = false;
            tb_matrikelnummer.IsEnabled = false;
            cb_bafoeg.IsEnabled = false;

            cb_titel.IsEnabled = true;
            tb_raum.IsEnabled = true;
        }
        private void bt_speichern_Click(object sender, RoutedEventArgs e)
        {
            if (rb_Student.IsChecked == true)
            {
                if (string.IsNullOrEmpty(cb_anrede.Text) || tb_vorname.Text == "" || tb_nachname.Text == "" ||
                    dt_Geburtsdatum.SelectedDate.ToString() == "" || tb_telefon.Text == "" || tb_email.Text == ""
                    || tb_strasse.Text == "" || tb_hausnummer.Text == "" || tb_PLZ.Text == "" || tb_stadt.Text == "" || tb_land.Text == ""
                    || tb_fachbereich.Text == "" || tb_studingang.Text == "" || tb_fachsemester.Text == ""|| tb_matrikelnummer.Text == "" )
                {
                    MessageBox.Show("Bitte vollständig ausfüllen, Felder können nicht leer sein!");
                    return;
                }
            }
            else if (rb_Mitarbeiter.IsChecked==true)
            {
                if (string.IsNullOrEmpty(cb_anrede.Text)|| tb_vorname.Text == "" || tb_nachname.Text == "" ||
                    dt_Geburtsdatum.SelectedDate.ToString() == "" || tb_telefon.Text == "" || tb_email.Text == ""
                    || tb_strasse.Text == "" || tb_hausnummer.Text == "" || tb_PLZ.Text == "" || tb_stadt.Text == "" || tb_land.Text == ""
                    || tb_raum.Text == "")
                {
                    MessageBox.Show("Bitte vollständig ausfüllen, Felder können nicht leer sein!");
                    return;
                }
            }
            else
            {
                return;
            }

            if (newPerson)
            {
                Adresse adresse = new Adresse(tb_strasse.Text, tb_hausnummer.Text, int.Parse(tb_PLZ.Text), tb_stadt.Text, tb_land.Text);

                if (rb_Student.IsChecked==true)
                {
                    Student student = new Student(cb_anrede.SelectedItem.ToString(), tb_vorname.Text, tb_nachname.Text,dt_Geburtsdatum.SelectedDate.ToString(), tb_telefon.Text,
                                    adresse, tb_email.Text, int.Parse(tb_matrikelnummer.Text), int.Parse(tb_fachsemester.Text),
                                    tb_studingang.Text, int.Parse(tb_fachsemester.Text), (cb_bafoeg.IsChecked == true) );

                    zuBearbeitendePerson = student;
                }
                else
                {  
                    Mitarbeiter mitarbeiter = new Mitarbeiter(cb_anrede.SelectedItem.ToString(), tb_vorname.Text, tb_nachname.Text, 
                                             dt_Geburtsdatum.SelectedDate.ToString(), tb_telefon.Text,
                                             adresse, tb_email.Text, "", tb_raum.Text);

                    zuBearbeitendePerson = mitarbeiter;
                }
            }
            else // Vom Editieren zur Bearbeitung - Aktualisierung
            {
                zuBearbeitendePerson.Anrede = cb_anrede.SelectedItem.ToString();
                zuBearbeitendePerson.Vorname = tb_vorname.Text;
                zuBearbeitendePerson.Nachname = tb_nachname.Text;
                zuBearbeitendePerson.Geburtsdatum = dt_Geburtsdatum.Text;
                zuBearbeitendePerson.Telefon = tb_telefon.Text;
                zuBearbeitendePerson.Email = tb_email.Text;
                zuBearbeitendePerson.GetAdresse().Strasse = tb_strasse.Text;
                zuBearbeitendePerson.GetAdresse().Hausnummer = tb_hausnummer.Text;
                zuBearbeitendePerson.GetAdresse().PLZ =int.Parse(tb_PLZ.Text);
                zuBearbeitendePerson.GetAdresse().Stadt = tb_stadt.Text;
                zuBearbeitendePerson.GetAdresse().Land = tb_land.Text;

                if (zuBearbeitendePerson.GetType() == typeof(Student))
                {
                    var student = zuBearbeitendePerson as Student;
                    student.Fachbereich = int.Parse(tb_fachbereich.Text);
                    student.Studiengang = tb_studingang.Text;
                    student.Fachsemester = int.Parse(tb_fachsemester.Text);
                    student.Matrikelnummer = int.Parse(tb_matrikelnummer.Text);
                    student.Bafoeg = cb_bafoeg.IsChecked.Value;
                }
                else
                {
                    var mitarbeiter = zuBearbeitendePerson as Mitarbeiter;
                    mitarbeiter.Raum = tb_raum.Text;
                    if (cb_titel.SelectedItem==null)
                    {
                        mitarbeiter.Titel = "";
                    }
                    else
                    {
                        mitarbeiter.Titel = cb_titel.SelectedItem.ToString();
                    }

                }
            }
            this.DialogResult = true;
            this.Close();
        }
        private void dt_Geburtsdatum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dt_Geburtsdatum.SelectedDate.ToString();
        }
    }
}
