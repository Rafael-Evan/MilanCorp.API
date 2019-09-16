using MilanCorp.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilanCorp.Domain.Models
{
    public class Material
    {
        [Key]
        public Guid Id { get; set; }
        public string NumeroDaNota { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public decimal? ValorTotal { get; set; }
        public int? Quantidade { get; set; }

        public Guid UploadId { get; set; }
        public FileUpload Upload { get; set; }

        public int UserId { get; set; }
        public User Usuario { get; set; }


    }
}
