using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var now = GetDateAsync().Result;
            label2.Text = now.ToString();
        }

        private async Task<DateTime> GetDateAsync()
        {
            await Task.Delay(100);
            return DateTime.Now;
        }
    }
}
