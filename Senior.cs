using System;
namespace Assignment4
{
    class Senior : Patient
    {
        public Senior()
        {
        }

        public Senior(int age, string name, string villageName, string patientType, Appointment appointment) : base(age, name, villageName, patientType, appointment)
        {
        }

        public override void SpecificAction()
        {
            Console.WriteLine("Check Blood Sugar");
            MainWindow.WriteIntoBinFile("appointmentData.txt", "Check Blood Sugar");
        }
    }
}
