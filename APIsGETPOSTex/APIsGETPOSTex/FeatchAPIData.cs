using System;
using System.Collections.Generic;
using System.Text;

namespace APIsGETPOSTex
{
    public class FeatchAPIData
    {
        private static FeatchAPIData instance;
        private FeatchAPIData()
        {
        }

        public static FeatchAPIData getinstance()
        {
            if (instance == null)
            {
                return instance = new FeatchAPIData();
            }
            return instance;
        }

    }
}
