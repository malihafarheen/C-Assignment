using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment4
{
    class PatientList : IDisposable
    {
        private List<IPatient> patientList = null;

        public PatientList()
        {
            patientList = new List<IPatient>();
        }

        public void Add(IPatient patient)
        {
            patientList.Add(patient);
        }
        public void Remove(IPatient patient)
        {
            patientList.Remove(patient);
        }

        public int Count()
        {
            return patientList.Count();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IPatient this[int i]
        {
            get { return patientList[i]; }
        }

        public void Sort()
        {
            patientList.Sort();
        }
    }
}

