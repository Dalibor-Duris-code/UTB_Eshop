using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UTB.Eshop.Web.Models.Entity
{
    [Table(nameof(Complain))]
    public class Complain
    {
        [Key]
        [Required]
        public int ID { get; set; }

        // [StringLength(50)]
        [Required]
        public int ProductID { get; set; }

        [StringLength(50)]
        [Required]
        public string Reason { get; set; }


        /* // new
         [StringLength(3)]

         public string isDigital { get; set; }

         // Bylo zboží vráceno včas
         [StringLength(50)]

         public string ManagerNote { get; set; }*/
    }
}



