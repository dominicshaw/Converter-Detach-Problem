using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ConverterDetachProblem.Annotations;
using DevExpress.Mvvm;

namespace ConverterDetachProblem
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private Stage _stage;
        
        public ICommand ChangeStageCommand => new DelegateCommand<Stage>(ChangeStage);
        private void ChangeStage(Stage stage) => Stage = stage == null ? Stage : stage;

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