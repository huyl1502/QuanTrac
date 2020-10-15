using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Mvc;
using QuanTrac;

namespace QuanTrac.Views.Home
{
    public class Login : Renderer<Models.LoginInfo>
    {

        public View _code()
        {
            var controls = new ControlBox
            {
                Binding = new Xamarin.BindingInfoCollection {
                    { "UserName", new Xamarin.BindingInfo { Caption = "Tên người dùng" } },
                    { "Password", new Xamarin.BindingInfo { Caption = "Mật khẩu", Input = "pass" } }
                },
                Margin = 40,
            };
            controls.SetValue(new Models.LoginInfo { UserName = "admin", Password = "1" });
            var btn = new MyButton
            {
                Text = "Đăng nhập",
                Margin = new Thickness(0, 40, 0, 0),
            };

            btn.Clicked += e =>
            {
                var data = controls.GetValue<Models.LoginInfo>();
                if (data == null)
                {
                    //Message.Show("Tên người dùng và mật khẩu không được để trống");
                }
                MyApp.Execute("home/login", data);
            };
            controls.AddRow(btn);

            MainContent.VerticalOptions = LayoutOptions.CenterAndExpand;
            return controls;
        }
        
    }
}
