using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyMutex mutexObj = new MyMutex();
        
        public MainWindow()
        {
            InitializeComponent();

            SomeClass obj = new SomeClass() {SomeInt = 5, SomeString = "Some string data" };
            SomeClass cloneObj = (SomeClass)obj.Clone();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                //Task.Run(async () =>
                //{
                //    await mutexObj.Lock();
                //    for (int k = 0; k < 10; k++)
                //    {
                //        Thread.Sleep(1000);
                //    }
                //    mutexObj.Release();
                //});
                Task.Run(async () =>
                {
                    using (await mutexObj.LockSection())
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                });
            }
        }
    }
}
