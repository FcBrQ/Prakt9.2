using System.Reflection;
using System.Xml.Linq;


namespace Prakt9._2
{
    public partial class MainPage : ContentPage
    {
       
        StreamReader inFile;
        string mainDir = FileSystem.Current.AppDataDirectory;
        StreamWriter outFile;
        string folderPath;





        public MainPage()
        {
            InitializeComponent();
        }
        private string GetLocalFolderPath()
        {
            // Получение пути к локальному каталогу приложения
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            return folderPath;
        }
        private void BornDP_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync();
            if (result != null)
            {
                var selectedPhotoStream = await result.OpenReadAsync();
                ImageView.Source = ImageSource.FromStream(() => selectedPhotoStream);
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

            StreamWriter outFile = new StreamWriter(Path.Combine(mainDir, "file.txt"));
            outFile.WriteLine(Surname.Text);
            outFile.Close();

        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {

            if (File.Exists(Path.Combine(folderPath, "file.txt")) == true)
            {
                StreamReader outFile = new StreamReader(Path.Combine(folderPath, "file.txt"));
                Surname.Text = outFile.ReadLine();
                outFile.Close();
            }
        }
    }
}
