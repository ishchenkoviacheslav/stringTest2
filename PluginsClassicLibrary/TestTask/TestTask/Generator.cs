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
using System.Net;
using System.Web;
using System.IO;

namespace TestTask
{
    //https://www.random.org/integers/?num=10&min=1&max=6&col=1&base=10&format=plain&rnd=new
    //1   https://www.random.org/integers/?num=10&min=0&max=999999999&col=2&base=10&format=plain&rnd=new
    class Generator
    {
        Queue<int> NumberSequence = new Queue<int>();
        private Queue<int> ParseStringRespons(string stringResponse)
        {
            List<string> allNumbers = stringResponse.Split('\n', '\0', '\r').ToList();
            string last = allNumbers.Last();
            allNumbers.Remove(last);
            foreach (string str in allNumbers)
            {
                NumberSequence.Enqueue(int.Parse(str));
            }
            return NumberSequence;
        }
        public Queue<int> GetNumberSequence(int MaxNumber = 5)
        {
            string returnedString;
            HttpWebRequest request = WebRequest.Create(@String.Format("https://www.random.org/integers/?num=10&min=0&max={0}&col=1&base=10&format=plain&rnd=new", MaxNumber.ToString())) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

                Stream recieveStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(recieveStream, Encoding.UTF8);
                returnedString = reader.ReadToEnd();
            }
            return ParseStringRespons(returnedString);
        }
        private async void MakeRequest()
        {
            await Task.Run(() =>
            {
                GetNumberSequence(5);
            });
        }
        //if take -1, than Queue is empty, and was made new async request

        public int GetOneNumber()
        {
            try
            {
                return NumberSequence.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                MakeRequest();
                //wait 2 seconds for async request
                Thread.Sleep(2000);
                return -1;
            }
        }
    }
}
