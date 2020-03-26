namespace Assignment4
{
    public class Appointment
    {
        private string time;

        public string Time { get => time; set => time = value; }

        public static bool CheckAge(int age, string patientType)
        {
            bool validAge = false;
            if (age == 0)
            {
                return validAge;
            }
            if (patientType.Equals("Children"))
            {
                if (age < 15)
                {
                    validAge = true;
                }
            }
            else if (patientType.Equals("Adult"))
            {
                if (age >= 15 && age <= 65)
                {
                    validAge = true;
                }
            }
            else if (patientType.Equals("Senior"))
            {
                if (age > 65 && age <= 99)
                {
                    validAge = true;
                }
            }
            return validAge;
        }
    }

    
}
