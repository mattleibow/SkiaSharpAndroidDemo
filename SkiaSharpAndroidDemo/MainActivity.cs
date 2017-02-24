using Android.App;
using Android.OS;

namespace SkiaSharpAndroidDemo
{
	[Activity(Label = "SkiaSharpAndroidDemo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private CustomCanvasView customCanvasView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			customCanvasView = FindViewById<CustomCanvasView>(Resource.Id.customCanvasView);
		}
	}
}
