using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace TransferList
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Transfer> Transfers { get; set; }
        public Transfer SelectedTransfer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeTransfers();
            this.DataContext = this;
        }

        private void InitializeTransfers()
        {
            Transfers = new ObservableCollection<Transfer>
            {
                new Transfer { PlayerName = "Kevin De Bruyne", Position = "Midfielder", TransferFee = 150000000, ContractDue = new DateTime(2024, 1, 1) },
                new Transfer { PlayerName = "Phil Foden", Position = "Forward", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Erling Haaland", Position = "Forward", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Rodri", Position = "Midfielder", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Julian Alvarez", Position = "Forward", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Jeremy Doku", Position = "Winger", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Jack Grealish", Position = "Winger", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Oscar Bobb", Position = "Winger", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Bernardo Silva", Position = "Midfielder", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Mateo Kovacic", Position = "Midfielder", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Matheus Nunes", Position = "Midfielder", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Ruben Dias", Position = "Defender", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "John Stones", Position = "Defender", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Kyle Walker", Position = "Defender", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Manuel Akanji", Position = "Defender", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Nathan Ake", Position = "Defender", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Josko Gvardiol", Position = "Defender", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Rico Lewis", Position = "Defender", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Ederson", Position = "Goalkeeper", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },
                new Transfer { PlayerName = "Stephan Ortega", Position = "Goalkeeper", TransferFee = 120000000, ContractDue = new DateTime(2023, 6, 1) },

            };

        }

        private void AddTransfer_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddTransferWindow();
            addWindow.ShowDialog();

            if (addWindow.DialogResult == true)
            {
                Transfers.Add(addWindow.NewTransfer);
                StatusText.Text = "Podpisano nowego piłkarza.";
            }
        }

        private void EditTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTransfer == null)
            {
                MessageBox.Show("Proszę wybrać zawodnika któremu chcesz przedłużyć kontrakt.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var editWindow = new EditTransferWindow(SelectedTransfer);
            editWindow.ShowDialog();

            if (editWindow.DialogResult == true)
            {
                int index = Transfers.IndexOf(SelectedTransfer);
                Transfers[index] = editWindow.EditedTransfer;
                StatusText.Text = "Przedłużono kontrakt.";
            }
        }

        private void DeleteTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTransfer == null)
            {
                MessageBox.Show("Proszę zawodnika którego chcesz zwolnić.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show("Czy na pewno chcesz chcesz zwolnić " + SelectedTransfer.PlayerName + " ?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Transfers.Remove(SelectedTransfer);
                StatusText.Text = "Zwolniono piłkarza.";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class Transfer
    {
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public decimal TransferFee { get; set; }
        public DateTime ContractDue { get; set; }
    }
}
