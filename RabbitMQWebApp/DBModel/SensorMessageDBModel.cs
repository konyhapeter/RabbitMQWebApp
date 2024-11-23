using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitMQWebApp.DBModel
{
    [Table("SENSORMESSAGE")]
    public class SensorMessageDBModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; init; }

        [Required]
        [Column("MESSAGE", TypeName = "varchar(200)")]
        public string MESSAGE { set; get; }
    }
}
