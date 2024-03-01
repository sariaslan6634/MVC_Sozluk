using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
	public class Context : DbContext
	{
		public DbSet<About> About { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Contact> AbContactout { get; set; }
		public DbSet<Content> Content { get; set; }
		public DbSet<Heading> Heading { get; set; }
		public DbSet<Writer> Writer { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Image> Image { get; set; }
		public DbSet<Admin> Admins { get; set; }

	}
}
