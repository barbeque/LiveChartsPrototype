using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LiveChartsPrototype
{
    public class LiveChartViewModel : ViewModelBase
    {
        public ICommand StartAddingPointsCommand { get; }

        public ChartValues<double> PrimaryPoints { get; private set; }
        public VisualElementsCollection Graffiti { get; private set; }

        public LiveChartViewModel()
        {
            PrimaryPoints = new ChartValues<double>();
            Graffiti = new VisualElementsCollection()
            {
                new VisualElement()
                {
                    X = 0,
                    Y = 0,
                    UIElement = new TextBlock()
                    {
                        Text = "Added beforehand",
                        Foreground = Brushes.Orange,
                        Background = Brushes.Black,
                        Padding = new System.Windows.Thickness(3),
                        Opacity = 0.5
                    }
                }
            };

            StartAddingPointsCommand = new RelayCommand(async () =>
            {
                double t = DateTime.UtcNow.Ticks;

                await Task.Delay(10);

                var y = Math.Sin(t);

                PrimaryPoints.Add(y);

                Graffiti.Add(new VisualElement()
                {
                    X = PrimaryPoints.Count - 1,
                    Y = y,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    UIElement = new TextBlock()
                    {
                        Text = "Hello",
                        Foreground = Brushes.Black
                    }
                });
            });
        }
    }
}
