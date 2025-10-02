using Lib8;
using Libmas;
using Microsoft.Win32;
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
using Пример_таблицы_WPF;

namespace Pr_2
{
    public partial class MainWindow : Window
    {
        private int[,] matrix;

        public MainWindow()

        {
            InitializeComponent();
            tabl.IsReadOnly = true;
        }
        private void zap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rows = Convert.ToInt32(razm.Text);
                int cols = Convert.ToInt32(razm1.Text);//kyj
                int maxValue = Convert.ToInt32(znach.Text); // fjfj

                if (rows <= 0 || cols <= 0)
                {
                    MessageBox.Show("Размеры матрицы должны быть положительными!");
                    return;
                }
                if (maxValue < 0)
                {
                    MessageBox.Show("Диапазон должен быть положительным числом!");
                    return;
                }

                Class3.FillMatrix(out matrix, rows, cols, maxValue);
                tabl.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            catch
            {
                MessageBox.Show("Ошибка при заполнении матрицы!");
            }
        }

        // Очистка матрицы
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                Class3.ClearMatrix(matrix);
                tabl.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                znach.Clear();
                razm.Clear();
                razm1.Clear();
            }
            else
            {
                MessageBox.Show("Матрица еще не создана!");
            }
        }
        // Поиск максимальных элементов в каждом столбце
        private void otvet_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                int[] maxValues = Class2.FindMaxInColumns(matrix);

                string result = "Максимальные элементы в каждом столбце:\n\n";
                for (int j = 0; j < maxValues.Length; j++)
                {
                    result += $"Столбец {j + 1}: {maxValues[j]}\n";
                }

                MessageBox.Show(result, "Результаты");
            }
            else
            {
                MessageBox.Show("Сначала заполните матрицу!");
            }
        }

        // Сохранение матрицы в файл
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

                if (saveDialog.ShowDialog() == true)
                {
                    try
                    {
                        Class3.SaveMatrix(matrix, saveDialog.FileName);
                        MessageBox.Show("Матрица успешно сохранена!");
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при сохранении");
                    }
                }
            }
            else
            {
                MessageBox.Show("Сначала заполните матрицу!");
            }
        }

        // Загрузка матрицы из файла
        private void load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (openDialog.ShowDialog() == true)
            {
                try
                {
                    matrix = Class3.LoadMatrix(openDialog.FileName);

                    razm.Text = matrix.GetLength(0).ToString();
                    razm1.Text = matrix.GetLength(1).ToString();
                    tabl.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                    MessageBox.Show("Матрица загружена!", "Загрузка");
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке");
                }
            }
        }

        // Выход из программы
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // О программе
        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №1, вариант 8\n" +
                            "Задача: найти максимальный элемент в каждом столбце матрицы.");
        }
    }
}