using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AWEMobileApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private int _temperature = 28;

        public int Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Color.FromArgb("#FFb1ff0a");
            button.ImageSource = GetImageSourceWithSuffix(button.ImageSource, "_selected");
        }

        private void Button_Released(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Color.FromArgb("#FF313131");
            button.ImageSource = GetImageSourceWithSuffix(button.ImageSource, string.Empty);
        }

        private ImageSource GetImageSourceWithSuffix(ImageSource imageSource, string suffix)
        {
            if (imageSource == null)
                return null;

            string originalImageFile = imageSource.ToString().Split(' ').Last();
            string newImageFile = suffix == string.Empty
                ? originalImageFile.Replace("_selected.png", ".png")
                : originalImageFile.Replace(".png", $"{suffix}.png");

            return ImageSource.FromFile(newImageFile);
        }

        private void ArrowUp_Pressed(object sender, EventArgs e)
        {
            Temperature++;
        }

        private void ArrowDown_Pressed(object sender, EventArgs e)
        {
            Temperature--;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
