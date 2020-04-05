using System;
using System.Collections.Generic;
using System.Text;

namespace APIsGETPOSTex.ConfigUtil
{
   public class ConfigUtility
    {

        private static string BASE_URL = "http://dummy.restapiexample.com/api";
        public static string FEATCH_EMPLOYEE_API = BASE_URL + "/v1/employees";
        public static string UPDATE_EMPLOYEE_API = BASE_URL + "/v1/update/";
        public static string DELETE_EMPLOYEE_API = BASE_URL + "/v1/delete/";
    }
}
