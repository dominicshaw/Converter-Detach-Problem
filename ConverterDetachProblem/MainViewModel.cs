using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ConverterDetachProblem.Annotations;

namespace ConverterDetachProblem
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand OpenItemCommand => new DelegateCommand<ItemViewModel>(Open, () => true);

        public ObservableCollection<ItemViewModel> Items { get; } = new ObservableCollection<ItemViewModel>();

        public ICommand SetPaidCommand => new DelegateCommand<object>(o => SetPaid(), () => true);

        public MainViewModel()
        {
            Items.Add(new ItemViewModel() {Id = 1, Name = "Item 1", Stage = Stages.InExchqr});
            Items.Add(new ItemViewModel() {Id = 2, Name = "Item 2", Stage = Stages.InExchqr});
            Items.Add(new ItemViewModel() {Id = 3, Name = "Item 3", Stage = Stages.InExchqr});
            Items.Add(new ItemViewModel() {Id = 4, Name = "Item 4", Stage = Stages.ManagerApproved});
            Items.Add(new ItemViewModel() {Id = 5, Name = "Item 5", Stage = Stages.ManagerApproved});
        }

        private void Open(ItemViewModel item)
        {
            new ViewItem(item).Show();
        }

        private void SetPaid()
        {
            foreach (var i in Items)
                i.Stage = Stages.Paid;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}