using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangement.Models
{
    public class StudentAlreadyExistsException : Exception
    {
        public StudentAlreadyExistsException() : base("Student with the provided roll number already exists.")
        {

        }

    }
}
