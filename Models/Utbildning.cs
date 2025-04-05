using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Api.Models
{
    public class Utbildning
    {
        [Key]
        public int UtbildningID { get; set; }
        public string Skola { get; set; }
        public string Examen { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }

        [ForeignKey("Person")]
        public int PersonID_FK { get; set; }
        public virtual Person Person { get; set; }
    }
}
