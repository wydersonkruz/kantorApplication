using System.Windows;
using System.Windows.Controls;

namespace TransferList
{
    public partial class EditTransferWindow : Window
    {
        public Transfer EditedTransfer { get; private set; }

        public EditTransferWindow(Transfer transfer)
        {
            InitializeComponent();
            EditedTransfer = transfer;

            // Bindujemy dane do kontrolek
            this.DataContext = EditedTransfer;
        }

        private void SaveButton_ClickEdit(object sender, RoutedEventArgs e)
        {
            // Walidacja danych wejściowych
            if (TransferDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola poprawnie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EditedTransfer.ContractDue = TransferDatePicker.SelectedDate.Value;

            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
