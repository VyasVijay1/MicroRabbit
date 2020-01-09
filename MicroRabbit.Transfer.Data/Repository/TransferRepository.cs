using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Rabbit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Data.Repository
{
	public class TransferRepository : ITransferRepository
	{
		private TransferDbContext _ctx;
		public TransferRepository(TransferDbContext ctx)
		{
			_ctx = ctx;
		}

		public void Add(TransferLog transferLog)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TransferLog> GetTransferLogs()
		{
			return _ctx.TransferLogs;
		}
	}
}
