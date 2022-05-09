using AutoMapper;
using FinancialApp.Application.Service;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Models;
using FinancialApp.Domain.Services.Services;
using FinancialApp.DTO.DTO;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace FinancialApp.Tests.DocumentTest;

public class DocumentApplicationServiceTest
{
	public readonly AutoMocker _mocker;
	private static IMapper _mapper;

	public DocumentApplicationServiceTest()
	{
		_mocker = new AutoMocker();
		if (_mapper == null)
		{
			var mapConfig = new MapperConfiguration(x =>
			{
				x.AddProfile(new DocumentAutoMapper());
			});
			_mapper = mapConfig.CreateMapper();
		}
	}

	[Fact]
	public async Task DocumentApplicationService_GetAll()
	{
		//Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var repository = _mocker.GetMock<IDocumentService>();
		repository.Setup(x => x.GetAll());

		var service = _mocker.CreateInstance<ApplicationDocumentService>();

		//Act
		await service.GetAll(1);

		//Assert
		repository.Verify(x => x.GetAll(), Times.Once);
	}

	[Fact]
	public async Task DocumentApplicationService_GetById()
	{
		//Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var repository = _mocker.GetMock<IDocumentService>();
		repository.Setup(x => x.GetById(document.Id));

		var service = _mocker.CreateInstance<ApplicationDocumentService>();

		//Act
		await service.GetById(document.Id);

		//Assert
		repository.Verify(x => x.GetById(document.Id), Times.Once);
	}

	[Fact]
	public async Task DocumentApplicationService_Add()
	{
		//Arrange

		#region Vars

		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentDto>(document);

		var repository = _mocker.GetMock<IDocumentService>();
		repository.Setup(x => x.Add(document));

		var service = _mocker.CreateInstance<ApplicationDocumentService>();

		#endregion Vars

		//Act
		await service.Add(result);

		//Assert
		repository.Verify(x => x.Add(It.IsAny<Document>()), Times.Once);
	}

	[Fact]
	public async Task DocumentApplicationService_Update()
	{
		//Arrange

		#region Vars

		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentUpdateDto>(document);

		var repository = _mocker.GetMock<IDocumentService>();
		repository.Setup(x => x.Update(document));

		var service = _mocker.CreateInstance<ApplicationDocumentService>();

		#endregion Vars

		//Act
		await service.Update(result);

		//Assert
		repository.Verify(x => x.Update(It.IsAny<Document>()), Times.Once);
	}

	[Fact]
	public async Task DocumentApplicationService_Patch()
	{
		//Arrange

		#region Vars

		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentPatchDto>(document);

		var repository = _mocker.GetMock<IDocumentService>();
		repository.Setup(x => x.Patch(document));

		var service = _mocker.CreateInstance<ApplicationDocumentService>();

		#endregion Vars

		//Act
		await service.Patch(result);

		//Assert
		repository.Verify(x => x.Patch(It.IsAny<Document>()), Times.Once);
	}
}