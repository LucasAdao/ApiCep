using ApiCep.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace ApiCep
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        Main();
        async Task Main()
        {
            string cepinho = textBoxCep.Text;
            string apiUrl = $"https://api.invertexto.com/v1/cep/{cepinho}?token=6152|AxrTMQPh4Y5id5bG8WdAQUrU0KHHvxFf"
;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Converte a resposta JSON para um objeto C#
                        Cep cep = JsonConvert.DeserializeObject<Cep>(responseBody);

                        // Agora você pode trabalhar com o objeto C# conforme necessário
                        textBoxBairro.Text = cep.Bairro;
                        textBoxCep.Text = cep.CepNumero;
                        textBoxCidade.Text = cep.Cidade;
                        textBoxEstado.Text = cep.Estado;
                        textBoxRua.Text = cep.Rua;
                        
                    }
                    else
                    {
                       MessageBox.Show($"O cep:{cepinho} é inválido!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        }

        private void botaoLimpar_Click(object sender, RoutedEventArgs e)
        {
            textBoxBairro.Text = (" ");
            textBoxCep.Text = (" ");
            textBoxCidade.Text =(" ");
            textBoxEstado.Text =(" ");
            textBoxRua.Text =(" ");
        }
    }
    }

