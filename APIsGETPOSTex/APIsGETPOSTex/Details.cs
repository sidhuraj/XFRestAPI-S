using System;
using System.Collections.Generic;
using System.Text;

namespace APIsGETPOSTex
{
     public class Details
    {
        //post program : success(error list:1)see the url(api properties) details and give it in class properties
                                          //2)above android 8.9 version to add the (android-properties-AndroidManifest.xml-(add this command) android:usesCleartextTraffic= "true")
                                          //3) before start the project (create a project name)-rightclick-Manage Nuget packages-browse-newtonsoft.json-install) then start the program.


        public string name { get; set; }
       
        public string salary { get; set; }
        public string age { get; set; }

    }

}
