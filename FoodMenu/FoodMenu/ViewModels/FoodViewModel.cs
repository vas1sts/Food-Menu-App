using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace FoodMenu.ViewModels
{
    public class FoodViewModel : INotifyPropertyChanged
    {
        private bool isCancelVisible;
        private string message;
        private CancellationTokenSource cts;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCancelVisible
        {
            get { return isCancelVisible; }
            set
            {
                isCancelVisible = value;
                OnPropertyChanged(nameof(IsCancelVisible));
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public bool IsPreparationOngoing => cts != null && !cts.Token.IsCancellationRequested;

        public FoodViewModel()
        {
            IsCancelVisible = false;
        }

        public async Task PrepareFood(IFood selectedFood)
        {
            if (IsPreparationOngoing)
                CancelFoodPreparation();

            Message = $"Preparing {selectedFood.FoodTitle}...";

            IsCancelVisible = true;

            cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(10000, cts.Token);
                Message = $"Your {selectedFood.FoodTitle} is ready.";
                IsCancelVisible = false;
            }
            catch (TaskCanceledException)
            {
                Message = "Food preparation canceled.";
                IsCancelVisible = false;
            }
        }

        public void CancelFoodPreparation()
        {
            cts?.Cancel();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
