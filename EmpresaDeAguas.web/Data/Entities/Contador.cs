namespace EmpresaDeAguas.web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Contador
    {
        public int Id { get; set; }

        public string Morada { get; set; }

        [Display(Name = "Código de Postal")]
        public int Codigo_postal { get; set; }
    }
}
