using System;
using System.IO;
using System.Windows.Forms;

namespace _9
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        int calcbutclick = 0, clrbutclick = 0;

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                clrbutclick++;
                string logfile = "log.log".DayAdd();
                StreamWriter log = new StreamWriter(logfile, true);
                log.Write(DateTime.Now.ToString("yyyy.dd.MM; HH:mm:ss"));
                log.WriteLine("\tClearButton was clicked");
                log.Close();
                //Очистка
                InputFirst.Text = ""; InputSecond.Text = ""; TotalOutput.Text = "";
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Калькулятор
                calcbutclick++;
                string s1 = Convert.ToString(InputFirst.Text);
                string s2 = Convert.ToString(InputSecond.Text);
                if (InputFirst.Text == "")
                    TotalOutput.Text = "Заполните 1 поле!";
                else if (InputSecond.Text == "")
                    TotalOutput.Text = "Заполните 2 поле!";
                else
                    TotalOutput.Text = s1 + s2;
                string filename = "result.txt";
                StreamWriter res = new StreamWriter(filename, true);
                res.WriteLine(TotalOutput.Text);
                res.Close();
                string logfile = "log.log".DayAdd();
                StreamWriter log = new StreamWriter(logfile, true);
                log.Write(DateTime.Now.ToString("yyyy.dd.MM; HH:mm:ss"));
                log.WriteLine("\tCalculateButton was clicked");
                log.WriteLine($"Entered in TextBox1 word: {InputFirst.Text}; Entered in TextBox2 word: {InputSecond.Text};\nResulting word: {TotalOutput.Text}");
                log.Close();
            }
            catch { }
        }

        
    }
    public static class timeForFiles
    {
        public static string TimeAdd(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("-yyyy-dd-MM-HH-mm-ss"),
                Path.GetExtension(fileName)
                );
        }
        public static string DayAdd(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("-yyyy-dd-MM"),
                Path.GetExtension(fileName)
                );
        }
    }
}