using MicroRabbit.Transfer.Rabbit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Application.Interfaces
{
	public interface ITransferService
	{
		IEnumerable<TransferLog> GetTransferLogs();
	}
}
