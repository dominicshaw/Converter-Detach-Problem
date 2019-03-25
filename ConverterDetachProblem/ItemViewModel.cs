using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ConverterDetachProblem.Annotations;

namespace ConverterDetachProblem
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private Stage _stage;

        public ICommand ChangeStageCommand => new DelegateCommand<SelectionChangedEventArgs>(ChangeStage, () => true);

        private void ChangeStage(SelectionChangedEventArgs args)
        {
            var oldStage = args.RemovedItems.OfType<Stage>().FirstOrDefault();
            var newStage = args.AddedItems.OfType<Stage>().FirstOrDefault();

            if (oldStage != null && newStage != null)
            {
                if (oldStage.StageID == 7 && newStage.StageID == 8)
                    Stage = newStage;

                MessageBox.Show("The converter fired!", "Converter!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }
        public Stage Stage
        {
            get => _stage;
            set
            {
                if (Equals(value, _stage)) return;
                _stage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}