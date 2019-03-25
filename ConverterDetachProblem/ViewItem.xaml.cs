using System.Windows.Input;

namespace ConverterDetachProblem
{
    public partial class ViewItem
    {
        public ViewItem(ItemViewModel item)
        {
            InitializeComponent();
            DataContext = item;
        }

        public ICommand CloseCommand => new DelegateCommand<object>(o => Close(), () => true);
    }
}
