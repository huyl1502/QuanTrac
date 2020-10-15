using System;
using Android.Content;
using Android.Views;
using Android.Graphics;
using Android.Text;
using CustomRenderer.Android;
using Xamarin.Forms.Platform.Android;

using X = Xamarin.Forms;

[assembly: X.ExportRenderer(typeof(X.Entry), typeof(MyEntryRenderer))]
[assembly: X.ExportRenderer(typeof(X.Editor), typeof(MyEditorRenderer))]
[assembly: X.ExportRenderer(typeof(X.Picker), typeof(MyPickerRenderer))]
[assembly: X.ExportRenderer(typeof(X.DatePicker), typeof(MyDatePickerRenderer))]
[assembly: X.ExportRenderer(typeof(X.TimePicker), typeof(MyTimePickerRenderer))]

namespace CustomRenderer.Android
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context){ }
        protected override void OnElementChanged(ElementChangedEventArgs<X.Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null) { Control.SetBackgroundColor(Color.Transparent); }
        }
    }
    public class MyEditorRenderer : EditorRenderer
    {
        public MyEditorRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<X.Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null) { Control.SetBackgroundColor(Color.Transparent); }
        }
    }
    public class MyPickerRenderer : PickerRenderer
    {
        public MyPickerRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<X.Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null) { Control.SetBackgroundColor(Color.Transparent); }
        }
    }
    public class MyDatePickerRenderer : DatePickerRenderer
    {
        public MyDatePickerRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<X.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null) { Control.SetBackgroundColor(Color.Transparent); }
        }
    }
    public class MyTimePickerRenderer : TimePickerRenderer
    {
        public MyTimePickerRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<X.TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null) { Control.SetBackgroundColor(Color.Transparent); }
        }
    }

}