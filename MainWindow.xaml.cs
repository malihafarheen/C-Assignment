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

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> timeSlots;
        List<string> patientType;
        PatientList pl = new PatientList();

        public MainWindow()
        {
            InitializeComponent();

            // Clean the content of binary file initially
            FileStream fileStream = File.Open("appointmentData.txt", FileMode.OpenOrCreate);
            fileStream.SetLength(0);
            fileStream.Close();

            timeSlots = new List<string>();
            timeSlots.Add("9:00 AM");
            timeSlots.Add("10:00 AM");
            timeSlots.Add("11:00 AM");
            timeSlots.Add("01:00 PM");
            timeSlots.Add("02:00 PM");
            timeSlots.Add("03:00 PM");
            timeSlots.Add("04:00 PM");

            Appointment[] appointments = new Appointment[timeSlots.Count];

            for (int i = 0; i < timeSlots.Count; i++)
            {
                //Array of appointments initialized
                appointments[i] = new Appointment();
                appointments[i].Time = timeSlots.ElementAt(i);
            }

            patientType = new List<string>();
            patientType.Add("Children");
            patientType.Add("Adult");
            patientType.Add("Senior");

            appointmentTimeSlot.ItemsSource = timeSlots;
            appointmentTimeSlot.SelectedIndex = 0;

            patientTypeList.ItemsSource = patientType;
            patientTypeList.SelectedIndex = 0;
        }

        private void display_click(object sender, RoutedEventArgs e)
        {
            appointmentData.Text = "";
            for (int i = 0; i < pl.Count(); i++)
            {
                WriteIntoBinFile("appointmentData.txt", pl[i].ToString());
                pl[i].MyDel();
            }
            ReadFromBinFile("appointmentData.txt");
        }

        private void book_click(object sender, RoutedEventArgs e)
        {
            bool result = true;
            string timeSlot = appointmentTimeSlot.SelectedItem as string;
            string patientType = patientTypeList.SelectedItem as string;
            

                int.TryParse(age.Text, out int ageInt);

                if (patientName.Text == "")
                {
                    patientName.BorderBrush = Brushes.Red;
                    result = false;
                    return;
                }
                else
                {
                    patientName.BorderBrush = Brushes.Black;
                }
                if (villageName.Text == "")
                {
                    villageName.BorderBrush = Brushes.Red;
                    result = false;
                    return;
                }
                else
                {
                    villageName.BorderBrush = Brushes.Black;
                }
                Patient patient = null;
                if (!Appointment.CheckAge(ageInt, patientType))
                {
                    age.Foreground = Brushes.Red;
                    age.BorderBrush = Brushes.Red;
                    result = false;
                    MessageBox.Show("Invalid age" + Environment.NewLine + "For Child: age should be less than 15" + Environment.NewLine + "For Adult: age should be between 15 - 65" + Environment.NewLine + "For Senior: age should be more than 65");
                    return;
                }
                else
                {
                    age.Foreground = Brushes.Black;
                    age.BorderBrush = Brushes.Black;
                }
                if (result)
                {
                    Appointment appointment = new Appointment();
                    appointment.Time = timeSlot;

                    if (patientType.Equals("Children"))
                    {
                        patient = new Children(ageInt, patientName.Text, patientName.Text, "Child", appointment);
                    }
                    else if (patientType.Equals("Adult"))
                    {
                        patient = new Adult(ageInt, patientName.Text, patientName.Text, "Adult", appointment);
                    }
                    else if (patientType.Equals("Senior"))
                    {
                        patient = new Senior(ageInt, patientName.Text, patientName.Text, "Senior", appointment);
                    }

                    pl.Add(patient);
                    pl.Sort();
              
                    // pop the appointment time slot and refresh the list
                    timeSlots.Remove(timeSlot);
                    appointmentTimeSlot.ItemsSource = null;
                    appointmentTimeSlot.ItemsSource = timeSlots;
                    appointmentTimeSlot.SelectedIndex = 0;

                    ClearAll();
                }
 
            
      
        }

        public static void WriteIntoBinFile(string fileName, string data)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(data);
                bw.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
        private void ReadFromBinFile(string fileName)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                appointmentData.Text = "";
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    string s = br.ReadString();
                    appointmentData.Text += s + Environment.NewLine;
                }
                br.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
        private void ClearAll()
        {
            patientName.Text = "";
            villageName.Text = "";
            age.Text = "";
        }
    }

}
