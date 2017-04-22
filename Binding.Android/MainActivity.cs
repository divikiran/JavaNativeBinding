using Android.App;
using Android.Widget;
using Android.OS;
using Com.Xamarin.Textcounter;
using Android.Views.InputMethods;
using Android.Content;

namespace Binding.Android
{
	[Activity(Label = "Binding.Android", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
		InputMethodManager imm;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);


			imm = (InputMethodManager)GetSystemService(Context.InputMethodService);

			var vowelsBtn = FindViewById<Button>(Resource.Id.vowels);
			var consonBtn = FindViewById<Button>(Resource.Id.consonants);
			var edittext = FindViewById<EditText>(Resource.Id.input);
			//edittext.InputType = Android.Text.InputTypes.TextVariationPassword;

			edittext.KeyPress += (sender, e) =>
			{
				imm.HideSoftInputFromWindow(edittext.WindowToken, HideSoftInputFlags.NotAlways);
				e.Handled = true;
			};

			vowelsBtn.Click += (sender, e) =>
			{
				int count = TextCounter.NumVowels(edittext.Text);
				string msg = count + " vowels found.";
				Toast.MakeText(this, msg, ToastLength.Short).Show();
			};

			consonBtn.Click += (sender, e) =>
			{
				int count = TextCounter.NumConsonants(edittext.Text);
				string msg = count + " consonants found.";
				Toast.MakeText(this, msg, ToastLength.Short).Show();
			};
		}
	}
}

