using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _20220921
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Triangle
        {
            public double SideA { get; private set; }
            public double SideB { get; private set; }
            public double SideC { get; private set; }
            public bool IsTriangle { get; private set; }

            public Triangle(double sideA, double sideB, double sideC)
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
                IsTriangle = CheckIfTriangle(sideA, sideB, sideC);
            }

            private bool CheckIfTriangle(double a, double b, double c)
            {
                return a + b > c && b + c > a && a + c > b;
            }
        }

        private List<Triangle> triangles = new List<Triangle>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "請輸入有效數值";
            double A, B, C;
            List<double> Triangle = new List<double>();
            bool number = double.TryParse(textBox.Text, out A);
            bool number1 = double.TryParse(textBox1.Text, out B);
            bool number2 = double.TryParse(textBox2.Text, out C);
            if (!number || A < 0 || !number1 || B < 0 || !number2 || C < 0)
            {
                MessageBox.Show("請輸入正數!", "Error!");
                return;
            }
            Triangle triangle = new Triangle(A, B, C);
            triangles.Add(triangle);
            if (triangle.IsTriangle)
            {
                label.Background = new SolidColorBrush(Colors.Green);
                label.Content = $"邊長 {A}, {B}, {C} 可構成三角形";
            }
            else
            {
                label.Background = new SolidColorBrush(Colors.Red);
                label.Content = $"邊長 {A}, {B}, {C} 不可構成三角形";
            }

            UpdateTextBlock();
        }
        private void UpdateTextBlock()
        {
            textBlock.Text = "測試結果：\n";

            foreach (Triangle triangle in triangles)
            {
                string result = triangle.IsTriangle ? "可構成" : "不可構成";
                textBlock.Text += $"邊長 {triangle.SideA}, {triangle.SideB}, {triangle.SideC} {result}三角形\n";
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
