using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APIsGETPOSTex
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string id;

        public const string mPersonName = "Bangalore";
        public readonly int personAge;
        public MainPage()
        {
            InitializeComponent();
         
            personAge = 10;


            FeatchAPIData firstInstall = FeatchAPIData.getinstance();
            FeatchAPIData twoinstall = FeatchAPIData.getinstance();
            FeatchAPIData threeInstall = FeatchAPIData.getinstance();

            btnAdd.Clicked += BtnAdd_ClickedAsync;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            getemployeList();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private async void BtnAdd_ClickedAsync(object sender, EventArgs e)
        {
            //form object
            Company objdetails = new Company();
            Company obj1details = new Company();
            objdetails.name = etname.Text;
            objdetails.salary = etsalary.Text;
            objdetails.age = etage.Text;

            //Calling Update the employee API
            HttpClient objhttpclient = new HttpClient();
            var content = JsonConvert.SerializeObject(objdetails);
            var httpcontent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await objhttpclient.PutAsync(ConfigUtil.ConfigUtility.UPDATE_EMPLOYEE_API + id, httpcontent);

            if (response.IsSuccessStatusCode)
            {
                var Result = await response.Content.ReadAsStringAsync();
            }
        }
        private async void getemployeList()
        {


            HttpClient objhttpclient = new HttpClient();

            var content = await objhttpclient.GetStringAsync(ConfigUtil.ConfigUtility.FEATCH_EMPLOYEE_API);

            var httpcontent = JsonConvert.DeserializeObject<List<Company>>(content.ToString());

            lblist.ItemsSource = httpcontent;

            lblist.ItemSelected += Lblist_ItemSelectedAsync;


        }

        private async void Lblist_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            var CompanyItem = e.SelectedItem as Company;
            if (CompanyItem != null)
            {
                id = CompanyItem.id;
                etname.Text = CompanyItem.employee_name;
                etsalary.Text = CompanyItem.employee_salary;
                etage.Text = CompanyItem.employee_age;

                //NOTE:delete process(After gave the event click to list then will execute a below 2 commands)
                //  HttpClient objhttpclient = new HttpClient();
                //var response = await objhttpclient.DeleteAsync(ConfigUtil.ConfigUtility.DELETE_EMPLOYEE_API + id);
            }
        }
    }
}

