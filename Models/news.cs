using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace pp.Models
{
    public class news
    {
        public int Id { get; set; }
        [DisplayName("Title Of News")]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Topic { get; set; }

        [ForeignKey("categrory")]
        [DisplayName("categrory")]
        public int categroryId { get; set; }
        public categrory categrory { get; set; }


        public news()
        {

        }

    }
}
