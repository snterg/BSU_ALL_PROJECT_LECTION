using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSU_ALL_PROJECT_LECTION
{
    public class Users
    {
        private int iD;

        private string name;

        private bool car;

        private float salary;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public bool Car { get => car; set => car = value; }
        public float Salary { get => salary; set => salary = value; }

        public Users()
        {

        }
    }
}
