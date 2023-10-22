


using System.Collections.Generic;

namespace pp.Models
{
    public class categrory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<news> News { get; set; }
    }
}
