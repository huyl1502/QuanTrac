using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.IO;
using CustomRenderer.Android;
using QuanTrac.Droid;
using static QuanTrac.Droid.Resource;
using Rect = Android.Graphics.Rect;

[assembly: ExportRenderer(typeof(MyIcon), typeof(IconRenderer))]
namespace CustomRenderer.Android
{
    public class IconRenderer : ViewRenderer<MyIcon, global::Android.Views.View>
    {
        public IconRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<MyIcon> e)
        {
            base.OnElementChanged(e);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetWillNotDraw(false);

            Invalidate();
        }

        Bitmap bmp;
        protected override void OnDraw(Canvas canvas)
        {
            try
            {
                var field = typeof(Drawable).GetField(Element.Key);
                var id = (int)field.GetValue(null);
                bmp = BitmapFactory.DecodeResource(Resources, id);

                var h = Element.Size * Resources.DisplayMetrics.Density;
                var w = h;
                if (h < 0) h = canvas.Height;
                if (w < 0) w = canvas.Width;

                int x = 0;
                int y = 0;

                double bh = bmp.Height;
                double bw = bmp.Width;


                if (bh != bw)
                {
                    var sh = h / bh;
                    var sw = w / bw;
                    if (sw > sh)
                    {
                        h *= bh / bw;
                    }
                    else
                    {
                        w *= bw / bh;
                    }
                }
                if (!Element.HorizontalOptions.Equals(LayoutOptions.Start))
                {
                    x = canvas.Width - (int)w;
                    if (Element.HorizontalOptions.Equals(LayoutOptions.Center))
                        x >>= 1;
                }
                if (!Element.VerticalOptions.Equals(LayoutOptions.Start))
                {
                    y = canvas.Height - (int)h;
                    if (Element.VerticalOptions.Equals(LayoutOptions.Center))
                        y >>= 1;
                }

                var margin = Element.Margin;
                if (margin != null)
                {
                    x += (int)margin.Left;
                    y += (int)margin.Top;
                }

                var src = new Rect(0, 0, bmp.Width, bmp.Height);
                var dst = new Rect(x, y, (int)(x + w), (int)(y + h));
                var disp = GetDisplay(Element.Foreground);
                canvas.DrawBitmap(disp, src, dst, null);

                disp.Dispose();
            }
            catch
            {

            }
        }

        Bitmap GetDisplay(Rgb color)
        {
            var h = bmp.Height;
            var w = bmp.Width;

            var data = new int[w * h];
            bmp.GetPixels(data, 0, w, 0, 0, w, h);
            
            int r = color.R;
            int g = color.G;
            int b = color.B;
            
            for (int i = 0; i < data.Length; i++)
            {

                int a = data[i] >> 24;
                if (a == 0) continue;

                data[i] = (a << 24) | (r << 16) | (g << 8) | b;
            }
            var res = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
            res.SetPixels(data, 0, w, 0, 0, w, h);
            return res;
        }

    }
}