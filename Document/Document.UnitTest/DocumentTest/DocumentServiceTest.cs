using Document.Application.Services;
using Document.Data.Repositories.Interfaces;
using Document.Domain.Models;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace Document.UnitTest.DocumentTest;

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
		int totalPages = 1, page = 1;
		var list = (documentFaker.listModel, totalPages, page); ;

		var repository = _mocker.GetMock<IDocumentRepository>();
		repository.Setup(x => x.GetAll(page)).ReturnsAsync(list);

		var service = _mocker.CreateInstance<DocumentService>();

		//Act
		await service.GetAll(1);

		//Assert
		repository.Verify(x => x.GetAll(1), Times.Once);
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
		repository.Verify(x => x.Add(It.IsAny<Documents>()), Times.Once);
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
		repository.Verify(x => x.Update(It.IsAny<Documents>()), Times.Once);
	}

	[Fact]
	public async Task DocumentService_Patch()
	{
		//Arrange

		#region Vars

		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var repository = _mocker.GetMock<IDocumentRepository>();
		var repositoryId = repository.Setup(x => x.GetById(document.Id)).ReturnsAsync(document);
		repository.Setup(x => x.Patch(document)).ReturnsAsync(document);

		var service = _mocker.CreateInstance<DocumentService>();

		#endregion Vars

		//Act
		await service.Patch(document);

		//Assert
		repository.Verify(x => x.Patch(It.IsAny<Documents>()), Times.Once);
	}
}