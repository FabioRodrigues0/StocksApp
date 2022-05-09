using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Models;
using FinancialApp.Domain.Services.Services;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace FinancialApp.Tests.DocumentTest;

public class DocumentServiceTest
{
	public readonly AutoMocker _mocker;

	public DocumentServiceTest()
	{
		_mocker = new AutoMocker();
	}

	[Fact]
	public async Task DocumentService_GetAll()
	{
		//Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var repository = _mocker.GetMock<IDocumentRepository>();
		repository.Setup(x => x.GetAll());

		var service = _mocker.CreateInstance<DocumentService>();

		//Act
		await service.GetAll();

		//Assert
		repository.Verify(x => x.GetAll(), Times.Once);
	}

	[Fact]
	public async Task DocumentService_GetById()
	{
		//Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var repository = _mocker.GetMock<IDocumentRepository>();
		repository.Setup(x => x.GetById(document.Id));

		var service = _mocker.CreateInstance<DocumentService>();

		//Act
		await service.GetById(document.Id);

		//Assert
		repository.Verify(x => x.GetById(document.Id), Times.Once);
	}

	[Fact]
	public async Task DocumentService_Add()
	{
		//Arrange

		#region Vars

		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var repository = _mocker.GetMock<IDocumentRepository>();
		repository.Setup(x => x.Add(document));

		var service = _mocker.CreateInstance<DocumentService>();

		#endregion Vars

		//Act
		await service.Add(document);

		//Assert
		repository.Verify(x => x.Add(It.IsAny<Document>()), Times.Once);
	}

	[Fact]
	public async Task DocumentService_Update()
	{
		//Arrange

		#region Vars

		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var repository = _mocker.GetMock<IDocumentRepository>();
		repository.Setup(x => x.Update(document));

		var service = _mocker.CreateInstance<DocumentService>();

		#endregion Vars

		//Act
		await service.Update(document);

		//Assert
		repository.Verify(x => x.Update(It.IsAny<Document>()), Times.Once);
	}

	[Fact]
	public async Task DocumentService_Patch()
	{
		//Arrange

		#region Vars

		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var repository = _mocker.GetMock<IDocumentRepository>();
		repository.Setup(x => x.Patch(document));

		var service = _mocker.CreateInstance<DocumentService>();

		#endregion Vars

		//Act
		await service.Patch(document);

		//Assert
		repository.Verify(x => x.Patch(It.IsAny<Document>()), Times.Once);
	}
}