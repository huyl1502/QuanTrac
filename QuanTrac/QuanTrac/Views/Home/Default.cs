using QuanTrac;
using System;
using Xamarin;
using Xamarin.Forms;

namespace QuanTrac.Views.Home
{
    public class Default : Renderer<object>
    {
        public override object GetResult()
        {
            MainContent.Add(new MyImage("logo"));
            BeginWaiting(() => {
                MyApp.Execute("Login");
            });
            return base.GetResult();
        }
        protected override void LoadItems()
        {
        }
    }
}
