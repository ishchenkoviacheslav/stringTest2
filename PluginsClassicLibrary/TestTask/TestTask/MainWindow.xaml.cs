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
using System.Diagnostics;
using System.Reflection;
namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyMutex mutexObj = new MyMutex();
        
        private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            foreach (Type type in args.LoadedAssembly.GetTypes())
            {
                foreach (ConstructorInfo ctor in type.GetConstructors())
                {
                    if (ctor.GetParameters().Length == 0 && ctor.IsPublic)
                    {
                        ReflectionClass.AddCtor(type, ctor);
                    }
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            ReflectionClass.GetTypesWithDefaultCtor();
            SomeClass obj = new SomeClass() { SomeInt = 5, SomeString = "Some string data" };
            SomeClass cloneObj = (SomeClass)obj.Clone();
            
        }

        private void runMutexBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
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
        private async void generatorBtn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Generator generator = new Generator();
                generator.GetNumberSequence(7);
                this.Dispatcher.Invoke(() =>
                {
                    this.labelForNumber.Content = generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                    this.labelForNumber.Content += generator.GetOneNumber().ToString();
                });
            });
        }
    }
}
