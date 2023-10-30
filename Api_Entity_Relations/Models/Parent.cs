using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api_Entity_Relations.Models
{
    public class Parent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParent { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Child> Children { get; set;}

        public Parent()
        {
            // Inicializa la colección de Children en el constructor
            Children = new List<Child>();
        }
    }
}
