using System;
using Bogus;
using FinancialApp.Domain.Models;
using FinancialApp.Shared;
using FinancialApp.Shared.Enums;

namespace FinancialApp.Tests.CashBookTest;

public class CashBookFaker
{
	public CashBook cashbook = new Faker<CashBook>()
		.RuleFor(x => x.Id, Guid.NewGuid)
		.RuleFor(x => x.Origin, x => x.PickRandom<Origin>())
		.RuleFor(x => x.OriginId, Guid.NewGuid)
		.RuleFor(x => x.Description, x => x.Random.String(1, 256))
		.RuleFor(x => x.Type, x => x.PickRandom<StatusCashBook>())
		.RuleFor(x => x.Valor, x => x.Random.Decimal(1, 30));
}