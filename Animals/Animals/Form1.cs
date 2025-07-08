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
using Newtonsoft.Json;

namespace Animals
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string input = textBox1.Text;
            string url = $"https://eol.org/api/search/1.0.json?q={input.ToLower()}&page=1&images_per_page=1";
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;
                        Animals myDeserializedClass = JsonConvert.DeserializeObject<Animals>(json);

                        if (myDeserializedClass.totalResults != 0)
                        {
                            foreach (Animal result in myDeserializedClass.results)
                            {
                                listBox1.Items.Add(result.title);
                            }

                        }
                        else listBox1.Items.Add("Ничего не нашел(");

                    }
                    else
                    {
                        MessageBox.Show(response.StatusCode.ToString());
                    }
                }
                catch (HttpRequestException eg)
                {
                    MessageBox.Show(eg.ToString());
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                string SelectedAnimal = listBox1.Items[listBox1.SelectedIndex].ToString();
                string url = $"https://api.inaturalist.org/v1/taxa?q={SelectedAnimal.Replace(" ", "%20")}";
                string urlname = $"https://eol.org/api/search/1.0.json?q={SelectedAnimal.Replace(" ", "%20")}&page=1&locale=ru";
                using (HttpClient httpClient = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = httpClient.GetAsync(url).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string json = response.Content.ReadAsStringAsync().Result;
                            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
                            pictureBox1.Load(myDeserializedClass.results[0].default_photo.medium_url);
                        }
                        else
                        {
                            MessageBox.Show(response.StatusCode.ToString());
                        }
                    }
                    catch (HttpRequestException eg)
                    {
                        MessageBox.Show(eg.ToString());
                    }
                }
            }
            catch
            {
                label1.Text = "Фото не найдено";
                pictureBox1.Image = null;
            }
        }
    }
}
