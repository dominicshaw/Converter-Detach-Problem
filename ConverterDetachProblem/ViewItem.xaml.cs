using System.Windows.Input;
using DevExpress.Mvvm;

namespace ConverterDetachProblem
{
    public partial class ViewItem
    {
        public ViewItem(ItemViewModel item)
        {
            InitializeComponent();
            DataContext = item;
        }

        public ICommand CloseCommand => new DelegateCommand(Close);
    }
}
