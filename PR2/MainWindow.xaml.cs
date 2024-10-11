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
using Microsoft.Win32;
using LibMas;
using Lib_6;
using System.IO;
namespace PR2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void SaveMas(int[] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы *.*|*.*|Текстовый файл|*txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(mas.Length);
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
        }
        public void OpenMas(int[] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы *.*|*.*|Текстовый файл|*txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                int len = Convert.ToInt32(file.ReadLine());
                mas = new int[len];
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
                Calculater.SumMas(out int sumMas, mas);
                tbCalc.Text = Convert.ToString(sumMas);
            }
        }
        public void CleanMas(int[] mas)
        {
            mas = null;
            tbCalc.Text = Convert.ToString(mas);
        }
        int[] mas;
        private void btCalc_Click(object sender, RoutedEventArgs e)
        {
            bool boolColumn = int.TryParse(tbColumn.Text, out int Column);
            bool boolRandom = int.TryParse(tbRandom.Text, out int Random);
            if (boolRandom == true && boolColumn == true && Column > 0)
            {
                    int sumMas;
                    int count = Convert.ToInt32(Column);
                    int randMax = Convert.ToInt32(Random);
                    randomMas.InitMas(out mas, count, randMax);
                    Calculater.SumMas(out sumMas, mas);
                    tbCalc.Text = Convert.ToString(sumMas);
            }
            else MessageBox.Show("Введите числа !!!!!");
        }

        private void btInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сделал:Ермаков Павел \nПрактическая работа №2 \nЗадание:Ввести n целых чисел. Найти сумму чисел < 15. Результат вывести на экран.");
        }
        private void btSaveMas_Click(object sender, RoutedEventArgs e)
        {
            SaveMas(mas);
        }

        private void btOpenMas_Click(object sender, RoutedEventArgs e)
        {
            OpenMas(mas);
        }

        private void btCleanMas_Click(object sender, RoutedEventArgs e)
        {
            CleanMas(mas);
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}