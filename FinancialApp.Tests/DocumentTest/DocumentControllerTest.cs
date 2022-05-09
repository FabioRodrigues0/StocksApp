using AutoMapper;
using FinancialApp.API.Document.Controllers;
using FinancialApp.Application.Interface;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.DTO.DTO;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace FinancialApp.Tests.DocumentTest;

public class DocumentControllerTest
{
	public readonly AutoMocker _mocker;
	private static IMapper _mapper;

	public DocumentControllerTest()
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
	public async Task DocumentController_Post()
	{
		// Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentDto>(document);

		var application = _mocker.GetMock<IApplicationDocumentService>();
		application.Setup(x => x.Add(result));

		var controller = _mocker.CreateInstance<DocumentController>();

		// Act
		await controller.Post(result);

		// Assert
		application.Verify(x => x.Add(It.IsAny<DocumentDto>()), Times.Once);
	}

	[Fact]
	public async Task DocumentController_Get()
	{
		// Arrange
		var application = _mocker.GetMock<IApplicationDocumentService>();
		application.Setup(x => x.GetAll(1));

		var controller = _mocker.CreateInstance<DocumentController>();

		// Act
		await controller.Get(1);

		// Assert
		application.Verify(x => x.GetAll(1), Times.Once);
	}

	[Fact]
	public async Task DocumentController_Update()
	{
		// Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentUpdateDto>(document);

		var application = _mocker.GetMock<IApplicationDocumentService>();
		application.Setup(x => x.Update(result));

		var controller = _mocker.CreateInstance<DocumentController>();

		// Act
		await controller.Put(result);

		// Assert
		application.Verify(x => x.Update(It.IsAny<DocumentUpdateDto>()), Times.Once);
	}

	[Fact]
	public async Task DocumentController_Patch()
	{
		// Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentPatchDto>(document);

		var application = _mocker.GetMock<IApplicationDocumentService>();
		application.Setup(x => x.Patch(result));

		var controller = _mocker.CreateInstance<DocumentController>();

		// Act
		await controller.Patch(result);

		// Assert
		application.Verify(x => x.Patch(It.IsAny<DocumentPatchDto>()), Times.Once);
	}

	[Fact]
	public async Task DocumentController_Remove()
	{
		// Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentUpdateDto>(document);

		var application = _mocker.GetMock<IApplicationDocumentService>();
		application.Setup(x => x.Remove(result.Id));

		var controller = _mocker.CreateInstance<DocumentController>();

		// Act
		await controller.Delete(result.Id);

		// Assert
		application.Verify(x => x.Remove(result.Id), Times.Once);
	}

	[Fact]
	public async Task DocumentController_GetById()
	{
		// Arrange
		var documentFaker = new DocumentFaker();
		var document = documentFaker.document;

		var result = _mapper.Map<DocumentUpdateDto>(document);

		var application = _mocker.GetMock<IApplicationDocumentService>();
		application.Setup(x => x.GetById(result.Id));

		var controller = _mocker.CreateInstance<DocumentController>();

		// Act
		await controller.Get(result.Id);

		// Assert
		application.Verify(x => x.GetById(result.Id), Times.Once);
	}
}