using System;
namespace Assignment4
{
    abstract class Patient : IPatient
    {
        private int age;
        private string name;
        private string villageName;
        private string patientType;
        private Appointment appointment;

        private PatientDelegate myDel = null;

        public Patient()
        {
            InitiateDeletes();
        }

        public Patient(int age, string name, string villageName, string patientType, Appointment appointment)
        {
            this.age = age;
            this.name = name;
            this.villageName = villageName;
            this.patientType = patientType;
            this.appointment = appointment;

            InitiateDeletes();
        }

        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public string VillageName { get => villageName; set => villageName = value; }
        public string PatientType { get => patientType; set => patientType = value; }
        public Appointment Appointment { get => appointment; set => appointment = value; }
        public PatientDelegate MyDel { get => myDel; set => myDel = value; }

        public void MeasureHeight()
        {
            Console.WriteLine("Height measured");
            MainWindow.WriteIntoBinFile("appointmentData.txt", "Height measured");
        }

        public void MeasureWeight()
        {
            Console.WriteLine("Weight measured");
            MainWindow.WriteIntoBinFile("appointmentData.txt", "Weight measured");
        }

        public void PerformCheckup()
        {
            Console.WriteLine("Performing checkup...");
            MainWindow.WriteIntoBinFile("appointmentData.txt", "Performing checkup...");
        }

        public abstract void SpecificAction();

        public int CompareTo(IPatient other)
        {
            return age.CompareTo(other.Age);
        }

        private void InitiateDeletes()
        {
            myDel += MeasureWeight;
            myDel += MeasureHeight;
            myDel += PerformCheckup;
            myDel += SpecificAction;
        }

        public override string ToString()
        {
            return string.Format("Time: {3}, Patient: {4}, Name {0} of Age {1} from village {2}", name, age, villageName, appointment.Time, patientType);
        }
    }
}
