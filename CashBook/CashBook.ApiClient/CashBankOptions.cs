using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBook.ApiClient;

public class CashBankOptions
{
	private string _baseAddress;

	public string BaseAddress
	{
		get
		{
			return _baseAddress ?? throw new InvalidOperationException("Base Address Financial API must be setted.");
		}
		set { _baseAddress = value; }
	}

	private string _cashBankPostEndPoint;

	public string CashBankPostEndPoint
	{
		get
		{
			return _cashBankPostEndPoint ?? throw new InvalidOperationException("Cash Bank EndPoint must be setted.");
		}
		set { _cashBankPostEndPoint = value; }
	}

	public string GetCashBankEndPoint() => $"{BaseAddress}/{CashBankPostEndPoint}";
}