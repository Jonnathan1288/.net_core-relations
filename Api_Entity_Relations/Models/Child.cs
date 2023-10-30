using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api_Entity_Relations.Models
{
    public class Child
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdChild { get; set; }
        public string Name { get; set; }
        public int IdParent { get; set; }
        [ForeignKey("IdParent")]
        public virtual Parent Parent { get; set; }
    }
}
