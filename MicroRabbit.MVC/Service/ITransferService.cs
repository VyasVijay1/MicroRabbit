using MicroRabbit.MVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Service
{
	public interface ITransferService
	{
		Task Transfer(TransferDTO transferDTO);
	}
}
