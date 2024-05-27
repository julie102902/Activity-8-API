using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity_8_API
{
    public partial class Books : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Books()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var otherform = new users();
            otherform.Show();
            this.Hide();
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutput.Clear();
                HttpResponseMessage response = await client.GetAsync("http://localhost/phpapi-main/booksapi.php");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                txtOutput.Text = responseBody;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnPost_Click(object sender, EventArgs e)
        {
            var bookData = new
            {
                book_title = txtBooktitle.Text,
                year = txtYear.Text,
                price = txtPrice.Text
            };

            string json = JsonConvert.SerializeObject(bookData);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var userData = new { book_title = txtBooktitle.Text, year = txtYear.Text, price = txtPrice.Text };
                HttpResponseMessage response = await client.PostAsync("http://localhost/phpapi-main/booksapi.php", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                txtOutput.Text = responseBody;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtBooktitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
