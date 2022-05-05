using Autofac;
using AutoMapper;
using FinancialApp.Application.Interface;
using FinancialApp.Application.Service;
using FinancialApp.CrossCutting.Adapter.Map;
using FinancialApp.Data;
using FinancialApp.Data.Repositories;
using FinancialApp.Domain.Core.Repositories;
using FinancialApp.Domain.Core.Services;
using FinancialApp.Domain.Services.Services;

namespace FinancialApp.CrossCutting.IOC;

public static class ConfigurationIoc
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

        builder.Register(ctx => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new BuyRequestAutoMapper());
            cfg.AddProfile(new BuyRequestProductAutoMapper());
            cfg.AddProfile(new CashBookAutoMapper());
            cfg.AddProfile(new DocumentAutoMapper());
        }));

        builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>()
            .InstancePerLifetimeScope();

        #endregion IOC Mapper

        #endregion Register IOC
    }
}