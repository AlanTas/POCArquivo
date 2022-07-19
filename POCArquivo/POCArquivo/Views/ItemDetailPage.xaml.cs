using POCArquivo.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace POCArquivo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}