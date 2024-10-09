using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace пр6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }



        public int[] mas = new int[20];
        int end = 0;

        private void gen_mas_Click(object sender, RoutedEventArgs e)
        {
            bool tr = true;
            Random rnd = new Random();
            int r = rnd.Next(15, 25);
            end = r;
            mas = new int[r];
            for (int i = 0; i < mas.Length; i++) 
            {
                mas[i] = rnd.Next(-100, 101);
            }
            massiv.Text = ""; 
            foreach (int em in mas)
            {
                massiv.Text += Convert.ToString(em) + "\r\n";
            }
            if (tr) 
            { 
                bubleS.IsEnabled = true;
                insertS.IsEnabled = true;
                selectionS.IsEnabled = true;
                quickS.IsEnabled = true;
            }
        }

        private void bubleS_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i]> mas[j])
                    {
                        swap(mas, i, j);
                    }
                }
            }
            vivod();
        }
        private void insertS_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < mas.Length; i++)
            {
                int k = mas[i];
                int j = i - 1;
                while (j >= 0 && mas[j] > k)
                {
                    mas[j + 1] = mas[j];
                    j--;
                }
                mas[j + 1] = k;
            }
            vivod();
        }

        private void selectionS_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                int minI = i;
                for(int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[minI])
                    {
                        minI = j;
                    }
                }
                if (minI != i)
                {
                    swap(mas, i, minI);
                }
            }
            vivod();
        }

        private void quickS_Click(object sender, RoutedEventArgs e)
        {
            QuickSort(mas,0,end-1);
            vivod();
        }

        public static int Partition(int[] mas, int low, int high)
        {
            int pivot = mas[(low+high)/2];
            int i = low - 1;
            int j = high + 1;
            while (true)
            {
                do
                {
                    i++;
                }
                while (mas[i] < pivot);
                do
                {
                    j--;
                }
                while (mas[j] > pivot);
                if (i >= j) return j;
                swap(mas, i, j);
            }
        }
        
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotI = Partition(array, low, high);
                QuickSort(array, low, pivotI );
                QuickSort(array, pivotI + 1, high);
            }
        }

        public static void swap(int[] mas, int index1, int index2)
        {
            int t = mas[index1];
            mas[index1] = mas[index2];
            mas[index2] = t;
        }

        void vivod()
        {
            massiv.Text = "";
            foreach (int em in mas)
            {
                massiv.Text += Convert.ToString(em) + "\r\n";
            }
        }
    }
}
