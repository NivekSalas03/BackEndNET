using System;
using Reclutamiento_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Reclutamiento_NET.Context
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Human> Human { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

	}
}

