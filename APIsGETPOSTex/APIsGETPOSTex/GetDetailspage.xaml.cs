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
    public partial class GetDetailspage : ContentPage
    {
        public GetDetailspage()
        {
            InitializeComponent();
            getemployeList();
        }
        private async void getemployeList()
        {
            HttpClient objhttpclient = new HttpClient();

            var content = await objhttpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");

            var httpcontent = JsonConvert.DeserializeObject<List<DelAip>>(content.ToString());

            lblist.ItemsSource = httpcontent;
            lblist.ItemSelected += Lblist_ItemSelected;
        }

        private void Lblist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
               var Companyitem = e.SelectedItem as GetApi;


        }
    }
}