using System;

using Xamarin.Forms;

namespace MenuPage
{
	public class App : Application
	{
		public static MasterDetailPage MasterDetailPage;

		public App ()
		{
			MasterDetailPage = new MasterDetailPage {
				Master = new MenuPage (),
				Detail = new NavigationPage (new LinkPage ("A")),
			};
			MainPage = MasterDetailPage;
		}

		public class MenuPage: ContentPage
		{
			public MenuPage ()
			{
				Content = new StackLayout {
					Padding = new Thickness (0, Device.OnPlatform<int> (20, 0, 0), 0, 0),
					Children = {
						new MainLink ("Page A"),
						new MainLink ("Page B"),
						new MainLink ("Page C"),
					}
				};
				Title = "Master";
				BackgroundColor = Color.Gray.WithLuminosity (0.9);
				Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null;
			}
		}

		public class MainLink: Button
		{
			public MainLink (string name)
			{
				Text = name;
				Command = new Command (o => {
					App.MasterDetailPage.Detail = new NavigationPage (new LinkPage (name));
					App.MasterDetailPage.IsPresented = false;
				});
			}
		}

		public class LinkPage: ContentPage
		{
			public LinkPage (string name)
			{
				Title = name;
				Content = new StackLayout {
					Children = {
						new SubLink (name + ".1"),
						new SubLink (name + ".2"),
						new SubLink (name + ".3"),
					},
				};
			}
		}

		public class SubLink: Button
		{
			public SubLink (string name)
			{
				Text = name;
				Command = new Command (o => App.MasterDetailPage.Detail.Navigation.PushAsync (new LinkPage (name)));
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

