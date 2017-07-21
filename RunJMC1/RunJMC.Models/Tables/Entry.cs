using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunJMC.Models.Tables
{
    public class Entry
    {
        public int EntryId { get; set; }
        public string Content { get; set; }
        public bool IsApproved { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public bool IsStatic { get; set; }
    }
}
