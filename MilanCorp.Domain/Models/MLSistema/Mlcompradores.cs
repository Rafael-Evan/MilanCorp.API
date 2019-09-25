using System;
using System.Collections.Generic;

namespace MilanCorp.Domain
{
    public partial class Mlcompradores
    {
        public Mlcompradores()
        {
            MlcompradoresEnd = new HashSet<MlcompradoresEnd>();
            MlformaPagamento = new HashSet<MlformaPagamento>();
            Mllotes = new HashSet<Mllotes>();
        }

        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Ufold { get; set; }
        public string CidadeOld { get; set; }
        public string BairroOld { get; set; }
        public string EnderecoOld { get; set; }
        public string Cepold { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string Ddd { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Fax { get; set; }
        public string ComplementoOld { get; set; }
        public string NumeroOld { get; set; }
        public string Fantasia { get; set; }
        public string Celular { get; set; }
        public byte? EstadoCivil { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public string TipoPessoa { get; set; }
        public string ContatoCpf { get; set; }
        public string Observacao { get; set; }
        public string StatusObs { get; set; }
        public DateTime? DataRegistro { get; set; }
        public string RazaoSocialAbrev { get; set; }
        public string MbbclienteSap { get; set; }
        public string RgorgaoExp { get; set; }

        public virtual ICollection<MlcompradoresEnd> MlcompradoresEnd { get; set; }
        public virtual ICollection<MlformaPagamento> MlformaPagamento { get; set; }
        public virtual ICollection<Mllotes> Mllotes { get; set; }
    }
}
