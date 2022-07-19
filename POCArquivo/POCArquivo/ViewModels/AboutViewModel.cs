using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace POCArquivo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await SalvarImgArquivo());
        }

        public ICommand OpenWebCommand { get; }

        public async Task SalvarImgArquivo()
        {
            try
            {
                var req = WebRequest.Create("https://www.google.com/images/branding/googlelogo/1x/googlelogo_light_color_272x92dp.png");
                var response = req.GetResponse();

                var nomeArquivo = "assinatura" + Guid.NewGuid().ToString() + "|" + Guid.NewGuid().ToString() + "|" + Guid.NewGuid().ToString() + ".png";
                var mainDir = FileSystem.AppDataDirectory;

                string localPath = Path.Combine(mainDir, nomeArquivo);

                MemoryStream ms = new MemoryStream();
                response.GetResponseStream().CopyTo(ms);
                var imgBytes = ms.ToArray();

                File.WriteAllBytes(localPath, imgBytes);

                var fileEntries = Directory.GetFiles(mainDir, "assinatura*");

                foreach(var fileEntry in fileEntries)
                {
                    var file = File.ReadAllBytes(fileEntry);
                    var fileString = JsonConvert.SerializeObject(file);
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}