using Cadastro.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O Id é requerido.")]
        public int Id { get; set; }

        [Display(Name = "CódigoCategoria")]
        [Required(ErrorMessage = "O id do Cliente é requerido.")]
        public int IdCategory { get; set; }

        [Display(Name = "Nome")]
        public Category? Category { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        public decimal Value { get; set; }

        [Display(Name = "Disponível")]
        public bool Active { get; set; }
        public IEnumerable<ClientViewModel> Clients { get; set; }
    }

}
