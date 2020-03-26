using System;
namespace Assignment4
{
    class Children : Patient
    {
        public Children()
        {
        }

        public Children(int age, string name, string villageName, string patientType, Appointment appointment) : base(age, name, villageName, patientType, appointment)
        {
        }

        public override void SpecificAction()
        {
            Console.WriteLine("Vaccination needed");
            MainWindow.WriteIntoBinFile("appointmentData.txt", "Vaccination needed");
        }
    }
}
