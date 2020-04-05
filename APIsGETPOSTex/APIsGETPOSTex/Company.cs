using System;
using System.Collections.Generic;
using System.Text;

namespace APIsGETPOSTex
{
    public  class Company
    {

        private static Company instance;
        public  Company()
        {
        }

        public static Company getinstance()
        {
            if (instance == null)
            {
                return instance = new Company();
            }
            return instance;
        }
        // PUT & Delect process//
        public string id { get; set; }
    public string name { get; set; }
    //public string salary { get; set; }
    //    public string age { get; set; }
    //public string image { get; set; }

    //    public string employee_name { get; set; }
    //    public string employee_salary { get; set; }
    //    public string employee_age { get; set; }
    //    public string profile_image { get; set; }
    }
}
