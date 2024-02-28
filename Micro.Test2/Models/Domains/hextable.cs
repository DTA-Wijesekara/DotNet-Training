using System.ComponentModel.DataAnnotations;

namespace Micro.Test2.Models.Domains
{
    public class hextable
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
