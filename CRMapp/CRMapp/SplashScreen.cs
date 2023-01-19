using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRMapp
{
   public class SplashScreen : ContentPage
    {
        Image SplashImage;

        public SplashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            var assembly = typeof(SplashScreen);
            SplashImage = new Image
            {
                Source = ImageSource.FromResource("CRMapp.Assets.Images.STC.png", assembly),
                WidthRequest =200,
                HeightRequest=200
            };

            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(SplashImage);

            this.BackgroundColor = Color.FromHex("#000000");
            this.Content = sub;
        } 

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await SplashImage.ScaleTo(1, 1500);
            await SplashImage.ScaleTo(0.8, 1500, Easing.Linear);
            await SplashImage.ScaleTo(150, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }

     

    }
}
