using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace SkiaSharpAndroidDemo
{
	[Activity(Label = "Custom Canvas")]
	public class CustomActivity : AppCompatActivity
	{
		private CustomCanvasView customCanvasView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Custom);

			customCanvasView = FindViewById<CustomCanvasView>(Resource.Id.customCanvasView);
		}
	}
}
