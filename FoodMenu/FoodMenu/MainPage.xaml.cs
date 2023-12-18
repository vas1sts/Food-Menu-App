using FoodMenu.ViewModels;
using System;
using Xamarin.Forms;

namespace FoodMenu
{
    public partial class MainPage : ContentPage
    {
        private FoodViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new FoodViewModel();
            BindingContext = viewModel;
            LoadFoodItems();
        }

        private void LoadFoodItems()
        {
            IFood[] foods = Menu.GetMenuItems();
            FoodCollectionView.ItemsSource = foods;
        }

        private async void FoodCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                IFood selectedFood = e.CurrentSelection[0] as IFood;

                if (viewModel.IsPreparationOngoing)
                {
                    viewModel.CancelFoodPreparation();
                }

                await viewModel.PrepareFood(selectedFood);
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            viewModel.CancelFoodPreparation();
        }
    }
}
