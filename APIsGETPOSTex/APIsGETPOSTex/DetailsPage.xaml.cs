using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIsGETPOSTex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {


        public DetailsPage()
        {
            InitializeComponent();

            btnAdd.Clicked += BtnAdd_Clicked;

        }



        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                Details objdetails = new Details();
                objdetails.name = etname.Text;
                objdetails.salary = etsalary.Text;
                objdetails.age = etage.Text;

                HttpClient objhttpclient = new HttpClient();

                var content = JsonConvert.SerializeObject(objdetails);

                var httpcontent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await objhttpclient.PostAsync("http://dummy.restapiexample.com/api/v1/create", httpcontent);

                if (response.IsSuccessStatusCode)
                {
                    var Result = await response.Content.ReadAsStringAsync();
                }
                else
                {

                }

            }

            catch (Exception ex)
            {

                await DisplayAlert("Results", ex.Message, "ok");
            }
        }
    }
}

	


            
