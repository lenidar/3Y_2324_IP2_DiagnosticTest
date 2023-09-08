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

namespace _3Y_2324_IP2_DiagnosticTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] _value = new string[] { null, null, null, null, null, null};
        string[] _mask = new string[] { "-", "-", "-", "-", "-", "-" };
        string[] _numValue = new string[] { "1","2","3","4","5","6","7","8","9","0"};
        Label[] _display = new Label[6];
        Button[] _numButtons = new Button[10];
        int _lastNumIn = -1;

        public MainWindow()
        {
            InitializeComponent();

            _display = new Label[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 };

            _numButtons = new Button[] { btn01, btn02, btn03, btn04, btn05, btn06, btn07, btn08, btn09, btn00};

            //_value = new string[] { "1","2","3","4","5","6"};

            displayButtonLabels();
        }

        #region Label Events
        private void lbl1_MouseEnter(object sender, MouseEventArgs e)
        {
            displayLogic(0);
        }

        private void lbl2_MouseEnter(object sender, MouseEventArgs e)
        {
            displayLogic(1);
        }

        private void lbl3_MouseEnter(object sender, MouseEventArgs e)
        {
            displayLogic(2);
        }

        private void lbl4_MouseEnter(object sender, MouseEventArgs e)
        {
            displayLogic(3);
        }

        private void lbl5_MouseEnter(object sender, MouseEventArgs e)
        {
            displayLogic(4);
        }

        private void lbl6_MouseEnter(object sender, MouseEventArgs e)
        {
            displayLogic(5);
        }

        private void lbl1_MouseLeave(object sender, MouseEventArgs e)
        {
            lbl1.Content = _mask[0];
        }

        private void lbl2_MouseLeave(object sender, MouseEventArgs e)
        {
            lbl2.Content = _mask[1];
        }

        private void lbl3_MouseLeave(object sender, MouseEventArgs e)
        {
            lbl3.Content = _mask[2];
        }

        private void lbl4_MouseLeave(object sender, MouseEventArgs e)
        {
            lbl4.Content = _mask[3];
        }

        private void lbl5_MouseLeave(object sender, MouseEventArgs e)
        {
            lbl5.Content = _mask[4];
        }

        private void lbl6_MouseLeave(object sender, MouseEventArgs e)
        {
            lbl6.Content = _mask[5];
        }

        #endregion

        private void displayLogic(int index)
        {
            if(_value[index] != null)
                _display[index].Content = _value[index];
        }

        private void displayButtonLabels()
        {
            for(int x = 0; x < _numButtons.Length; x++) 
            {
                _numButtons[x].Content = _numValue[x];
            }
        }

        private void buttonEventLogic(int index)
        {
            _lastNumIn++;
            if (_lastNumIn == _display.Length)
                _lastNumIn = 0;

            if (_lastNumIn == _display.Length - 1)
                btnEnter.IsEnabled = true;

            lblDebug.Content = _lastNumIn;

            _value[_lastNumIn] = _numValue[index];
            _mask[_lastNumIn] = "X";

            for (int x = 0; x < _display.Length; x++)
                _display[x].Content = _mask[x];

            numberShuffle();
        }

        private void numberShuffle()
        {
            Random rnd = new Random();
            List<string> numList = new List<string>();
            for (int x = 0; x < _numButtons.Length; x++)
                numList.Add(x + "");

            for(int x = 0; x < _numValue.Length; x++)
            {
                _numValue[x] = numList[rnd.Next(numList.Count)];
                numList.Remove(_numValue[x]);
            }

            displayButtonLabels();
        }

        #region Button Events
        private void btn01_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(0);
        }

        private void btn02_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(1);
        }

        private void btn03_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(2);
        }

        private void btn04_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(3);
        }

        private void btn05_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(4);
        }

        private void btn06_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(5);
        }

        private void btn07_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(6);
        }

        private void btn08_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(7);
        }

        private void btn09_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(8);
        }

        private void btn00_Click(object sender, RoutedEventArgs e)
        {
            buttonEventLogic(9);
        }
        #endregion

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string passcode = "";

            foreach(string v in _value)
                passcode += v;

            MessageBox.Show($"The value entered is {passcode}");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < _display.Length; x++)
            {
                _mask[x] = "-";
                _display[x].Content = _mask[x];
                _value[x] = null;
            }

            _lastNumIn = -1;
        }
    }
}
