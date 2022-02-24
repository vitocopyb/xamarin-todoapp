using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //se invoca este metodo cada vez que se muestra esta pagina
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

        private async void LoadItems()
        {
            List<ToDoItem> items = await App.Context.GetItemsAsync();
            lista_tareas.ItemsSource = items;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmación", "¿Está seguro de eliminar el elemento?", "SI", "NO"))
            {
                ToDoItem item = (ToDoItem)(sender as MenuItem).CommandParameter;
                int result = await App.Context.DeleteItemAsync(item);

                if (result == 1)
                {
                    LoadItems();
                }
            }
        }
    }
}