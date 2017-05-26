using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

using SkiaSharp;
using SkiaSharp.Views.Android;

namespace SkiaSharpAndroidDemo
{
	[Activity(Label = "Default Canvas", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		private SKCanvasView canvasView;
		private SKBitmap backgroundBitmap;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			canvasView = FindViewById<SKCanvasView>(Resource.Id.canvasView);
			canvasView.PaintSurface += OnPaint;

			// load the image
			backgroundBitmap = SKBitmap.Decode(Assets.Open("background.png"));
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.MainMenu, menu);

			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item.ItemId == Resource.Id.action_custom)
			{
				StartActivity(typeof(CustomActivity));

				return true;
			}

			return base.OnOptionsItemSelected(item);
		}

		private void OnPaint(object sender, SKPaintSurfaceEventArgs e)
		{
			var surface = e.Surface;
			var canvas = surface.Canvas;
			var info = e.Info;

			canvas.Clear(0xFF59C0C8);

			// tile the bitmap across the bottom
			var y = info.Height - backgroundBitmap.Height;
			for (var x = 0; x < info.Width; x += backgroundBitmap.Width)
			{
				canvas.DrawBitmap(backgroundBitmap, x, y);
			}
		}
	}
}
