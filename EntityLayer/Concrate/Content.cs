using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
	public class Content
	{
        [Key]
        public int ContentID { get; set; }

		[StringLength(1000)]
		public string ContentValue { get; set; }

        public bool ContentStatus { get; set; }

        public DateTime ContentDate { get; set; }
        //Contentin yazarı ve contentint başlığı

        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        public int WriteId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
