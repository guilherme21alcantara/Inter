using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Produto
    //Propriedades  & atributos:
    {
        public int? IdProduto {get; set;}

        [Required]
        public string Descricao {get;set;}

        [Required]
        public string Categoria {get;set;}

        [Required]
        [DataType(DataType.Currency)]
        public decimal Valor{get;set;}
    }
    
}