using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace CarExpenses
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText inputDanak;
        EditText inputGTP;
        EditText inputGrajdanska;
        EditText inputObslujvane;
        TextView txtResult;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            double resultDanak = 0;
            double resultGTP = 0;
            double resultGrajdanska = 0;
            double resultObslujvane = 0;

            inputDanak = FindViewById<EditText>(Resource.Id.inputDanak);
            inputGTP = FindViewById<EditText>(Resource.Id.inputGTP);
            inputGrajdanska = FindViewById<EditText>(Resource.Id.inputGrajdanska);
            inputObslujvane = FindViewById<EditText>(Resource.Id.inputObslujvane);
            txtResult = FindViewById<TextView>(Resource.Id.txtResult);


            inputDanak.TextChanged += delegate
            {
                if (inputDanak.Text != "")
                {
                    resultDanak = double.Parse(inputDanak.Text);
                }
            };

            inputGTP.TextChanged += delegate
            {
                if (inputGTP.Text != "")
                {
                    resultGTP = double.Parse(inputGTP.Text);
                }
            };

            inputGrajdanska.TextChanged += delegate
            {
                if (inputGrajdanska.Text != "")
                {
                    resultGrajdanska = double.Parse(inputGrajdanska.Text);
                }
            };

            inputObslujvane.TextChanged += delegate
            {
                if (inputObslujvane.Text != "")
                {
                    resultObslujvane = double.Parse(inputObslujvane.Text);
                }
            };

            FindViewById<Button>(Resource.Id.btnResult).Click += (e, o) => txtResult.Text = String.Format("Your car is cost you {0}st. every minute",
                (((resultDanak + resultGTP + resultGrajdanska + resultObslujvane) / 525949 * 1.0) * 10).ToString());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}