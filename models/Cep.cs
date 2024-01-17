using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCep.models
{
    public class Cep
    {
        [JsonProperty("cep")]
        public string CepNumero{ get; set; }
        [JsonProperty("state")]
        public string Estado{ get; set; }
        [JsonProperty("city")]
        public string Cidade { get; set; }
        [JsonProperty("neighborhood")]
        public string Bairro { get; set; }
        [JsonProperty("street")]
        public string Rua {  get; set; }
    }
}
