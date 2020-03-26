using System;

namespace Assignment4
{
    public delegate void PatientDelegate();
    public interface IPatient : IComparable<IPatient>
    {
        int Age { get; set; }
        string Name { get; set; }
        string VillageName { get; set; }
        string PatientType { get; set; }
        Appointment Appointment { get; set; }

        PatientDelegate MyDel { get; set; }
        void MeasureWeight();
        void MeasureHeight();
        void PerformCheckup();

        void SpecificAction();
    }
}
