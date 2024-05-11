using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussineslogic1.Manager
{
    public class PatientManager1
    {
        public string GeneratePatientCode(string name, string lastName, string ci)
        {
            string initials = $"{name.Substring(0, 1)}{lastName.Substring(0, 1)}";
            return $"{initials.ToUpper()}-{ci}";
        }
    }
}
