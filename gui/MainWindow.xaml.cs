using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using core;
namespace gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List <Square> squares = new List<Square>();
        public MainWindow()
        {
            InitializeComponent();
            squares = Services.LoadSquares();
            for (int i = 0; i < squares.Count; i++)
            {
                IndexComboBox.Items.Add(i);
            }
        }

        private void ellenorzesButton_Click(object sender, RoutedEventArgs e)
        {
            if (IndexComboBox.SelectedIndex == -1) 
            {
                return;
            }

            int n = squares[IndexComboBox.SelectedIndex].N;
        }

        private void IndexComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IndexComboBox.SelectedIndex == -1)
            {
                return;
            }
            Square selectedSquare = squares[IndexComboBox.SelectedIndex];
            showMatrix(selectedSquare);

        }

        private void showMatrix(Square selectedSquare)
        {
            SquaresUniformGrid.Children.Clear();
            SquaresUniformGrid.Rows = selectedSquare.N;
            SquaresUniformGrid.Columns = selectedSquare.N;

            for (int i = 0; i < selectedSquare.N; i++)
            {
                for (int j = 0; j < selectedSquare.N; j++)
                {
                    TextBox textBox = new TextBox
                    { 
                        Text = selectedSquare.Matrix[i, j].ToString(),
                        Width = 50,
                        Height = 50,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        FontSize = 16,
                        Margin = new Thickness(5),
                        Tag = (i, j)
                    };
                    textBox.PreviewTextInput += (s, e) => e.Handled = !int.TryParse(e.Text, out _);

                    SquaresUniformGrid.Children.Add(textBox);
                }
            }
        }
    }
}