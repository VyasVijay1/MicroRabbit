using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Service;
using MicroRabbit.MVC.Models.DTO;

namespace MicroRabbit.MVC.Controllers
{
	public class HomeController : Controller
	{

		private readonly ITransferService _transferService;

		public HomeController(ITransferService transferService)
		{
			_transferService = transferService;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpPost]
		public async Task<IActionResult> Transfer(TransferViewModel model)
		{

			TransferDTO transferDTO = new TransferDTO()
			{
				FromAccount = model.FromAccount,
				ToAccount = model.ToAccount,
				TransferAccount = model.TransferAmount
			};

			await _transferService.Transfer(transferDTO);
			return View("Index");
		}
	}
}
