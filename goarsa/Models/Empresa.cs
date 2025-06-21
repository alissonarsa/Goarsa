using System.Collections.Generic;

namespace Goarsa.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Endereco { get; set; }
        public List<Solicitante> Solicitantes { get; set; } = new();
    }
}
