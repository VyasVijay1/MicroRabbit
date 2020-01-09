using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Rabbit.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.TRansfer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransferController : ControllerBase
	{

		public readonly ITransferService _transferService;

		public TransferController(ITransferService transferService)
		{
			_transferService = transferService;
		}
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<TransferLog>> Get()
		{
			return Ok(_transferService.GetTransferLogs());
		}

		
	}
}
