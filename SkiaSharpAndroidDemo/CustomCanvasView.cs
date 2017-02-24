using System;
using System.IO;
using Android.Content;
using Android.Runtime;
using Android.Util;

using SkiaSharp;
using SkiaSharp.Views.Android;

namespace SkiaSharpAndroidDemo
{
	public class CustomCanvasView : SKCanvasView
	{
		private SKBitmap backgroundBitmap;

		public CustomCanvasView(Context context)
			: base(context)
		{
			Init();
		}

		public CustomCanvasView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Init();
		}

		public CustomCanvasView(Context context, IAttributeSet attrs, int defStyleAttr)
			: base(context, attrs, defStyleAttr)
		{
			Init();
		}

		protected CustomCanvasView(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
			Init();
		}

		private void Init()
		{
			// we need a seekable stream for decoding files
			var ms = new MemoryStream();
			using (var asset = Context.Assets.Open("background.png"))
				asset.CopyTo(ms);
			ms.Position = 0;

			// this will dispose the memory stream
			// and this will be disposed after decoding automatically
			var stream = new SKManagedStream(ms, true);

			// load the image
			backgroundBitmap = SKBitmap.Decode(stream);
		}

		protected override void OnDraw(SKSurface surface, SKImageInfo info)
		{
			base.OnDraw(surface, info);

			var canvas = surface.Canvas;

			canvas.Clear(0xFF59C0C8);

			var y = info.Height - backgroundBitmap.Height;
			for (var x = 0; x < info.Width; x += backgroundBitmap.Width)
			{
				canvas.DrawBitmap(backgroundBitmap, x, y);
			}
		}
	}
}
