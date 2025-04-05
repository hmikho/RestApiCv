using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Api.Models
{
    public class Arbetserfarenhet
    {
        [Key]
        public int JobbID { get; set; }
        public string Jobbtitel { get; set; }
        public string Företag { get; set; }
        public string Beskrivning { get; set; }
        public string Startår { get; set; }

        [ForeignKey("Person")] 
        public int PersonID_FK { get; set; }
        public virtual Person Person { get; set; }

    }
}
