﻿using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Events
{
	public class TransferCreatedEvents : Event
	{
		public int From { get; private set; }
		public int To { get; private set; }
		public decimal Amount { get; private set; }

		public TransferCreatedEvents(int from, int to, decimal amount)
		{
			From = from;
			To = to;
			Amount = amount;
		}
	}
}