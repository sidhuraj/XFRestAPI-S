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
    public partial class DeletePageE : ContentPage
    {
        public DeletePageE()
        {
            InitializeComponent();
            getemployeList();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private async void getemployeList()
        {
            HttpClient objhttpclient = new HttpClient();
            var content = await objhttpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");
            var httpcontent = JsonConvert.DeserializeObject<List<DelAip>>(content.ToString());
            lblist.ItemsSource = httpcontent;
            lblist.ItemSelected += Lblist_ItemSelectedAsync;
        }

        private async  void Lblist_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
           var Deleteitem = e.SelectedItem as DelAip;
           HttpClient objhttpclient = new HttpClient();
           var response = await objhttpclient.DeleteAsync("http://dummy.restapiexample.com/api/v1/delete/" + Deleteitem.id);

            getemployeList();
        }
    }
}