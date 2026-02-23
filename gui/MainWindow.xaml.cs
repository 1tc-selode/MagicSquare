using core;
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

namespace gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Square> squares = new List<Square>();
        public MainWindow()
        {
            InitializeComponent();
            squares = Services.LoadSquares();
            for(int i = 0; i < squares.Count; i++)
            {
                IndexComboBox.Items.Add(i);
            }
        }

        private void ellenrozesButton_Click(object sender, RoutedEventArgs e)
        {
            if (IndexComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Kérem válasszon egy négyzetet a listából!");
                return;
            }

            int n = squares[IndexComboBox.SelectedIndex].N;

            int[,] currentmatrix = new int[n, n];
            int index = 0;

            foreach(TextBox textBox in SquaresUniformGrid.Children)
            {
                var (i, j) = ((int, int))textBox.Tag;
                currentmatrix[i, j] = int.Parse(textBox.Text);
            }

            Square checkSquare = new Square(currentmatrix);

            if (checkSquare.IsMagic())
            {
                MessageBox.Show("Ez egy varázsnégyzet!");
            }
            else
            {
                MessageBox.Show("Ez nem egy varázsnégyzet!");
            }
        }

        private void IndexComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(IndexComboBox.SelectedIndex == -1)
            {
                return;
            }

            Square selectedsquare = squares[IndexComboBox.SelectedIndex];

            showMatrix(selectedsquare);
        }

        private void showMatrix(Square selectedsquare)
        {
            SquaresUniformGrid.Children.Clear();
            SquaresUniformGrid.Rows = selectedsquare.N;
            SquaresUniformGrid.Columns = selectedsquare.N;

            for (int i = 0; i < selectedsquare.N; i++)
            {
                for (int j = 0; j < selectedsquare.N; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        Text = selectedsquare.Matrix[i, j].ToString(),
                        Width = 30,
                        Height = 30,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        FontSize = 16,
                        Margin = new Thickness(5),
                        Tag = (i, j) // Tároljuk a koordinátákat a Tag-ben
                    };
                    textBox.PreviewTextInput += (s, e) =>
                    {
                        // Csak számokat engedélyezünk
                        e.Handled = !int.TryParse(e.Text, out _);
                    };
                    SquaresUniformGrid.Children.Add(textBox);
                }
            }
        }
    }
}