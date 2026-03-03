using System.ComponentModel.DataAnnotations;

namespace CuentaBancaria.Models
{
    public class Datos_Cuenta
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titular { get; set; }

        [Required]
        public string Numero_de_Cuenta { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Saldo { get; set; }

        [Required]
        public string Tipo_de_Cuenta { get; set; }

        public DateTime Fecha_de_Creacion { get; set; } = DateTime.Now;
    }
}
