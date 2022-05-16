using Bogus;
using Document.Application.DTO;
using Document.Domain.Models;
using Infrastructure.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Document.UnitTest.DocumentTest;

public class DocumentFaker
{
	public Documents document = new Faker<Documents>()
		.RuleFor(x => x.Id, Guid.NewGuid)
		.RuleFor(x => x.Number, x => x.Random.String(1, 256))
		.RuleFor(x => x.Date, x => DateTimeOffset.Now)
		.RuleFor(x => x.DocumentType, x => x.PickRandom<TypeDocument>())
		.RuleFor(x => x.Operation, x => x.PickRandom<Operation>())
		.RuleFor(x => x.Paid, x => x.Random.Bool())
		.RuleFor(x => x.PaymentDate, x => DateTimeOffset.Now.AddDays(2))
		.RuleFor(x => x.Description, x => x.Random.String(1, 256))
		.RuleFor(x => x.Observation, x => x.Random.String(1, 256))
		.RuleFor(x => x.Total, x => x.Random.Decimal(1, 30));

	public List<Documents> listModel = new Faker<Documents>()
		.RuleFor(x => x.Id, Guid.NewGuid)
		.RuleFor(x => x.Number, x => x.Random.String(1, 256))
		.RuleFor(x => x.Date, x => DateTimeOffset.Now)
		.RuleFor(x => x.DocumentType, x => x.PickRandom<TypeDocument>())
		.RuleFor(x => x.Operation, x => x.PickRandom<Operation>())
		.RuleFor(x => x.Paid, x => x.Random.Bool())
		.RuleFor(x => x.PaymentDate, x => DateTimeOffset.Now.AddDays(2))
		.RuleFor(x => x.Description, x => x.Random.String(1, 256))
		.RuleFor(x => x.Observation, x => x.Random.String(1, 256))
		.RuleFor(x => x.Total, x => x.Random.Decimal(1, 30))
		.GenerateBetween(1, 3);

	public List<DocumentDto> listDto = new Faker<DocumentDto>()
		.RuleFor(x => x.Number, x => x.Random.String(1, 256))
		.RuleFor(x => x.Date, x => DateTimeOffset.Now)
		.RuleFor(x => x.DocumentType, x => x.PickRandom<TypeDocument>())
		.RuleFor(x => x.Operation, x => x.PickRandom<Operation>())
		.RuleFor(x => x.Paid, x => x.Random.Bool())
		.RuleFor(x => x.PaymentDate, x => DateTimeOffset.Now.AddDays(2))
		.RuleFor(x => x.Description, x => x.Random.String(1, 256))
		.RuleFor(x => x.Observation, x => x.Random.String(1, 256))
		.RuleFor(x => x.Total, x => x.Random.Decimal(1, 30))
		.GenerateBetween(1, 3);
}