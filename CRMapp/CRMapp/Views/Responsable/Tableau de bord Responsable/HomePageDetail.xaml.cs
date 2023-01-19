using CRMapp.ViewModel;
using CRMapp.Views.Agent;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetail : ContentPage
    {
        HomePageViewModel viewModel;

       private readonly ChartEntry[] entries_Agents = new[]
          {
            new ChartEntry(App.Database.numberofAgents())
            {
                Label = "En Ligne",
                ValueLabel = App.Database.numberofAgents().ToString(),
                Color = SKColor.Parse("#488A99")
            },
            new ChartEntry( App.Database.numberofResponsable())
            {
                Label = "Hors-Ligne",
                ValueLabel = App.Database.numberofResponsable().ToString(),
                Color = SKColor.Parse("#000000")
            },
        };

        private readonly ChartEntry[] entries_Pauses= new[]
         {
            new ChartEntry(App.Database.NBofacceptedPauses())
            {     
                Color = SKColor.Parse("#488A99"),

            },
            new ChartEntry(App.Database.NBofRefusedPauses())
            {
                Color = SKColor.Parse("#CED2CC")
            },
        };

        private readonly ChartEntry[] entries_Clients = new[]
           {
            new ChartEntry(20)
            {
                Label = "Lundi",
                ValueLabel ="20",
                Color = SKColor.Parse("#488A99")
            },
            new ChartEntry(15)
            {
                Label = "Mardi",
                ValueLabel ="15",
                Color = SKColor.Parse("#AC3E31")
            },
            new ChartEntry(25)
            {
                Label = "Mercredi",
                ValueLabel ="25",
                Color = SKColor.Parse("#DBAE58")
            },
             new ChartEntry(30)
            {
                Label = "Jeudi",
                ValueLabel ="30",
                Color = SKColor.Parse("#484848")
            },
            new ChartEntry(10)
            {
                Label = "Vendredi",
                ValueLabel ="10",
                Color = SKColor.Parse("#EA6A47")
            },

        };
        protected override void OnAppearing()
        {
            base.OnAppearing();

            chartViewBar.Chart = new BarChart
            {
                Entries = entries_Agents,
                MaxValue = 20,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelTextSize = 30,
                IsAnimated = true,
                LabelOrientation = Orientation.Horizontal,
                BackgroundColor = SKColor.Parse("#F1F1F1")
            };

            ChartViewPie.Chart= new PieChart
            {
                Entries = entries_Pauses,
                HoleRadius = 0.5f,     
                IsAnimated = true,
                BackgroundColor = SKColor.Parse("#F1F1F1")
            };

            chartViewLine.Chart = new LineChart
            { 
                Entries = entries_Clients,
                BackgroundColor = SKColor.Parse("#F1F1F1"),
                LineMode = LineMode.Straight,
                IsAnimated=true,
                LabelTextSize=25,
                LabelOrientation=Orientation.Horizontal,
                ValueLabelOrientation=Orientation.Horizontal,            
                MaxValue=40,
            };
        }

        public HomePageDetail()
        {
            InitializeComponent();
            viewModel = new HomePageViewModel();
            this.BindingContext = viewModel;       
        }  
    }
}