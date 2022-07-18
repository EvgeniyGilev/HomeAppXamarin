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
            var layout = new StackLayout();

            layout.BackgroundColor = Color.Cyan;

            var datePicker = new DatePicker
            {
                Format = "D",
                // Диапазон дат: +/- неделя
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7),

            };

            var datePickerText = new Label { Text = "Дата запуска ", Margin = new Thickness(0, 10, 0, 0) };

            // Добавляем всё на страницу
            layout.Children.Add(new Label { Text = "Будильник" });
            layout.Children.Add(datePickerText);
            layout.Children.Add(datePicker);

            // Виджет выбора времени.
            var timePickerText = new Label { Text = "Время запуска ", Margin = new Thickness(0, 10, 0, 0) };
            var timePicker = new TimePicker
            {
                Time = new TimeSpan(13, 0, 0)
            };

            layout.Children.Add(timePickerText);
            layout.Children.Add(timePicker);

            //Уровень громкости
            Slider slider = new Slider
            {
                Minimum = 0,
                Maximum = 15,
                Value = 1.0,
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray
            };

            var sliderText = new Label { Text = $"Громкость: {slider.Value} ", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 30, 0, 0) };
            layout.Children.Add(sliderText);
            layout.Children.Add(slider);

            // Создаем меню выбора в виде выпадающего списка с текстовым заголовком
            var picker = new Picker { Title = "Запускать каждый день или нет?" };
            // Добавляем значения выпадающего списка для пользовательского выбора
            picker.Items.Add("Повторять каждый день");
            picker.Items.Add("Запустить однократно");
            // Добавляем элементы на страницу
            layout.Children.Add(picker);



            Content = layout;


        }

    }
}