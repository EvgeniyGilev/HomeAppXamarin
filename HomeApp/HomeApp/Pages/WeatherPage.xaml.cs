using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public const string BUTTON_TEXT_Wheather = "Узнать погоду";
        public const string BUTTON_TEXT_Clock = "Установить будильник";
        public WeatherPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для отображения погоды по клику
        /// </summary>
        private void LoadWeather(object sender, EventArgs e)
        {
            // Создаем новую табличную разметку
            var layout = new Grid();
            // Задаем чёрный фон
            layout.BackgroundColor = Color.Black;

            // Создаем цветной прямоугольник, который будет фоном для текста
            var upperBox = new BoxView { BackgroundColor = Color.Bisque };
            // Генерим заголовок и выравниваем с помощью свойств.
            var upperHeader = new Label() { Text = $"{Environment.NewLine}Inside", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start, FontSize = 45, TextColor = Color.FromRgb(48, 48, 48) };
            // Генерим непосредственно текст со значениями температуры и тоже выравниваем.
            var upperText = new Label() { Text = $"{Environment.NewLine}+ 26 °C  ", HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, FontSize = 105, TextColor = Color.FromRgb(48, 48, 48) };
            // Добавляем все элементы в одну ячейку табличной разметки Grid. В результате они будут помещены "один поверх другого", и прямоугольник будет фоном для текста
            layout.Children.Add(upperBox, 0, 0);
            layout.Children.Add(upperHeader, 0, 0);
            layout.Children.Add(upperText, 0, 0);

            // Аналогично заполняем средний блок
            var middleBox = new BoxView { BackgroundColor = Color.LightBlue };
            var middleHeader = new Label() { Text = $"{Environment.NewLine} Outside", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start, FontSize = 45, TextColor = Color.FromRgb(48, 48, 48) };
            var middleText = new Label() { Text = $"{Environment.NewLine}- 15 °C  ", HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, FontSize = 105, TextColor = Color.FromRgb(48, 48, 48) };
            layout.Children.Add(middleBox, 0, 1);
            layout.Children.Add(middleHeader, 0, 1);
            layout.Children.Add(middleText, 0, 1);

            // Аналогично заполняем нижний блок
            var bottomBox = new BoxView { BackgroundColor = Color.DarkCyan };
            var bottomHeader = new Label() { Text = $"{Environment.NewLine} Pressure", HorizontalTextAlignment = TextAlignment.Center, FontSize = 45, TextColor = Color.FromRgb(48, 48, 48) };
            var bottomText = new Label() { Text = $"{Environment.NewLine}760 mm ", HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, FontSize = 100, TextColor = Color.FromRgb(48, 48, 48) };
            layout.Children.Add(bottomBox, 0, 2);
            layout.Children.Add(bottomHeader, 0, 2);
            layout.Children.Add(bottomText, 0, 2);

            // Инициализация свойства Content созданным табличным лейаутом идентична тому, как если бы мы создавали его в XAML и разместили внутри ContentPage.
            this.Content = layout;
        }

        /// <summary>
        /// Метод для отображения будильника
        /// </summary>

        private void LoadClock(object sender, EventArgs e)
        {
            
        }

    }
}