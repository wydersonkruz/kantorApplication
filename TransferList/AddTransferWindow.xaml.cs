using System;
using System.Windows;
using System.Windows.Controls;

namespace TransferList
{
    public partial class AddTransferWindow : Window
    {
        public Transfer NewTransfer { get; private set; }

        public AddTransferWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Walidacja danych wejściowych
            if (string.IsNullOrWhiteSpace(PlayerNameTextBox.Text) ||
                PositionComboBox.SelectedItem == null ||
                !decimal.TryParse(TransferFeeTextBox.Text, out decimal transferFee) ||
                TransferDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola poprawnie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Tworzenie nowego obiektu Transfer
            NewTransfer = new Transfer
            {
                PlayerName = PlayerNameTextBox.Text,
                Position = ((ComboBoxItem)PositionComboBox.SelectedItem).Content.ToString(),
                TransferFee = transferFee,
                ContractDue = TransferDatePicker.SelectedDate.Value
            };

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
