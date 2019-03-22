using DevExpress.Mvvm.UI;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ConverterDetachProblem
{
    public class ChangeStageEventArgsConverter : EventArgsConverterBase<SelectionChangedEventArgs>
    {
        protected override object Convert(object sender, SelectionChangedEventArgs args)
        {
            var oldStage = args.RemovedItems.OfType<Stage>().FirstOrDefault();
            var newStage = args.AddedItems.OfType<Stage>().FirstOrDefault();

            if (oldStage != null && newStage != null)
            {
                if (oldStage.StageID == 7 && newStage.StageID == 8)
                    return newStage;

                MessageBox.Show($"You cannot change an invoice from '{oldStage.Label}' to '{newStage.Label}'.\n\nIf you would find it useful to be able to do this, please contact TTDevelopers@ttint.com.", "Disabled Stage Change", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return null;
        }
    }
}