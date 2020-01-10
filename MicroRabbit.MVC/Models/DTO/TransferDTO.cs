using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Models.DTO
{
	public class TransferDTO
	{
		public int FromAccount { get; set; }
		public int ToAccount { get; set; }
		public decimal TransferAccount { get; set; }
	}
}
