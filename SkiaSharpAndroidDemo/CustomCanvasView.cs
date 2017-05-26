using System;
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
			// load the image
			backgroundBitmap = SKBitmap.Decode(Context.Assets.Open("background.png"));
		}

		protected override void OnDraw(SKSurface surface, SKImageInfo info)
		{
			base.OnDraw(surface, info);

			var canvas = surface.Canvas;

			canvas.Clear(0xFF59C0C8);

			// tile the bitmap across the bottom
			var y = info.Height - backgroundBitmap.Height;
			for (var x = 0; x < info.Width; x += backgroundBitmap.Width)
			{
				canvas.DrawBitmap(backgroundBitmap, x, y);
			}

			//// we could also use a shader, so that we don't have to tile manually
			//using (var paint = new SKPaint())
			//{
			//	paint.Shader = SKShader.CreateBitmap(
			//		backgroundBitmap,        // the bitmap to tile
			//		SKShaderTileMode.Repeat, // tile across the top
			//		SKShaderTileMode.Clamp); // use the bottom color to fill the rest
			//
			//	canvas.DrawRect(info.Rect, paint);
			//}
		}
	}
}
