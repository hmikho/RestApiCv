using System.ComponentModel.DataAnnotations;

namespace Backend_Api.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        public string Namn { get; set; }

        public string Beskrivning { get; set; }

        public int Telefonnummer { get; set; }

        public string Email { get; set; }

        public virtual List<Utbildning> Utbildningar { get; set; } = new List<Utbildning>();

        public virtual List<Arbetserfarenhet> Arbetserfarenheter { get; set; } = new List<Arbetserfarenhet>();
    }
}
