using MicroRabbit.Transfer.Rabbit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Data.Context
{
	public class TransferDbContext : DbContext
	{
		public TransferDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<TransferLog> TransferLogs { get; set; }
	}
}
