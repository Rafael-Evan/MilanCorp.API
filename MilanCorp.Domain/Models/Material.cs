using MilanCorp.Domain.Identity;
using System;

namespace MilanCorp.Domain.Models
{
    public class Material
    {
        public Guid Id { get; set; }
        public string NumeroDaNota { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public decimal? ValorTotal { get; set; }
        public int? Quantidade { get; set; }
        public Guid UploadId { get; set; }
        public int UserId { get; set; }
        public virtual FileUpload Upload { get; set; }

        public virtual User Usuario { get; set; }


    }
}
