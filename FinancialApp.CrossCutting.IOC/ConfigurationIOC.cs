using Autofac;
using FinancialApp.Application.Interface;
using FinancialApp.Application.Service;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Services.Services;
using FinancialApp.CrossCutting.Adapter.Interfaces;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.Data;
using FinancialApp.Data.Repositories;

namespace FinancialApp.CrossCutting.IOC;

public class ConfigurationIOC
{
	public static void Load(ContainerBuilder builder)
	{
		#region Register IOC

		#region IOC Application

		builder.RegisterType<ApplicationBuyRequestService>().As<IApplicationBuyRequestService>();
		builder.RegisterType<ApplicationDocumentService>().As<IApplicationDocumentService>();
		builder.RegisterType<ApplicationCashBookService>().As<IApplicationCashBookService>();

		#endregion IOC Application

		#region IOC Services

		builder.RegisterType<BuyRequestService>().As<IBuyRequestService>();
		builder.RegisterType<DocumentService>().As<IDocumentService>();
		builder.RegisterType<CashBookService>().As<ICashBookService>();

		#endregion IOC Services

		#region IOC Repositories SQL

		builder.RegisterType<BuyRequestRepository>().As<IBuyRequestRepository>();
		builder.RegisterType<DocumentRepository>().As<IDocumentRepository>();
		builder.RegisterType<CashBookRepository>().As<ICashBookRepository>();

		#endregion IOC Repositories SQL

		#region IOC Mapper

		builder.RegisterType<DocumentMapper>().As<IDocumentMapper>();
		builder.RegisterType<CashBookMapper>().As<ICashBookMapper>();

		#endregion IOC Mapper

		#endregion Register IOC
	}
}