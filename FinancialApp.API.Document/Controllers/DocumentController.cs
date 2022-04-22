using FinancialApp.Application.Interface;
using FinancialApp.DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.API.Document.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DocumentController : Controller
	{
		private readonly IApplicationDocumentService _applicationDocumentService;

		public DocumentController(IApplicationDocumentService applicationDocumentService)
		{
			_applicationDocumentService = applicationDocumentService;
		}

		[HttpGet]
		public ActionResult<List<string>> Get()
		{
			return Ok(_applicationDocumentService.GetAll());
		}

		[HttpGet("page/{page}")]
		public ActionResult<string> Get(int page)
		{
			return Ok(_applicationDocumentService.GetByPage(page));
		}

		[HttpGet("{id}")]
		public ActionResult<string> Get(Guid id)
		{
			return Ok(_applicationDocumentService.GetById(id));
		}

		[HttpPost]
		public ActionResult Post([FromBody] DocumentDto documentDto)
		{
			try
			{
				if(documentDto == null)
					return NotFound();

				_applicationDocumentService.Add(documentDto);
				return Ok("Document successfully registered!");
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		[HttpPut]
		public ActionResult Put([FromBody] DocumentDto documentDto)
		{
			try
			{
				if(documentDto == null)
					return NotFound();

				_applicationDocumentService.Update(documentDto);
				return Ok("Document successfully updated!");
			}
			catch(Exception)
			{
				throw;
			}
		}

		[HttpDelete()]
		public ActionResult Delete([FromBody] DocumentDto documentDto)
		{
			try
			{
				if(documentDto == null)
					return NotFound();

				_applicationDocumentService.Remove(documentDto);
				return Ok("Document successfully removed!");
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}