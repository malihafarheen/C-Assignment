using System;
namespace Assignment4
{
    class Adult : Patient
    {
        public Adult()
        {
        }

        public Adult(int age, string name, string villageName, string patientType, Appointment appointment) : base(age, name, villageName, patientType, appointment)
        {
        }

        public override void SpecificAction()
        {
            Console.WriteLine("Check cholesterol");
            MainWindow.WriteIntoBinFile("appointmentData.txt", "Check cholesterol");
        }
    }
}
