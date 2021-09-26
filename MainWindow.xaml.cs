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


namespace Lab1_TylerHenry
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

        /// <summary>
        /// Creates a worker object. If the worker is valid, displays their pay and disables input controls.
        /// </summary>
        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            //Create worker object
            var myWorker = new PieceworkWorker(textBoxWorkerName.Text, textBoxMessagesSent.Text);

            //If the workers pay is calcualted
            if (myWorker.Pay > 0)
            {
                //Add worker details to textboxes
                textBoxTotalWorkerPay.Text = myWorker.Pay.ToString();
                textBoxTotalWorkers.Text = PieceworkWorker.TotalWorkers.ToString();
                textBoxTotalPay.Text = PieceworkWorker.TotalPay.ToString();
                textBoxAveragePay.Text = PieceworkWorker.AveragePay.ToString();

                //Disable calculate button and textboxes, set focus to clear button
                textBoxWorkerName.IsEnabled = false;
                textBoxMessagesSent.IsEnabled = false;
                buttonCalculate.IsEnabled = false;
                buttonClear.Focus();
            }
        }

        /// <summary>
        /// Clears all input fields and sets the form to its default state.
        /// </summary>
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            //Call method to clear 
            SetDefaults();
        }

        /// <summary>
        /// Clear all input fields and re-enable all controls that may be disabled.
        /// </summary>
        private void SetDefaults()
        {
            //Clear all inputed text box and current workers total pay
            textBoxMessagesSent.Text = "";
            textBoxWorkerName.Text = "";
            textBoxTotalWorkerPay.Clear();
            
            //Reanable textboxes and buttons, set focus to worker name
            textBoxMessagesSent.IsEnabled = true;
            textBoxWorkerName.IsEnabled = true;
            buttonCalculate.IsEnabled = true;
            textBoxWorkerName.Focus();
        }

    }


}