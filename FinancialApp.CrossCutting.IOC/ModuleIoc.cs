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

public class ModuleIoc : Module
{
    protected override void Load(ContainerBuilder moduleBuilder)
    {
        #region Register IOC

        #region IOC Application

        //moduleBuilder.RegisterType<ApplicationBuyRequestService>().As<IApplicationBuyRequestService>();
        //moduleBuilder.RegisterType<ApplicationDocumentService>().As<IApplicationDocumentService>();
        //moduleBuilder.RegisterType<ApplicationCashBookService>().As<IApplicationCashBookService>();

        #endregion IOC Application

        #region IOC Services
        
        moduleBuilder.RegisterType<BuyRequestService>().As<IBuyRequestService>();
        moduleBuilder.RegisterType<DocumentService>().As<IDocumentService>();
        moduleBuilder.RegisterType<CashBookService>().As<ICashBookService>();

        #endregion IOC Services

        #region IOC Repositories SQL

        #endregion Register IOC

        moduleBuilder.RegisterType(typeof(BuyRequestRepository))
            .As(typeof(IBuyRequestRepository))
            .InstancePerLifetimeScope();
        moduleBuilder.RegisterType(typeof(DocumentRepository))
            .As(typeof(IDocumentRepository))
            .InstancePerLifetimeScope();
        moduleBuilder.RegisterType(typeof(CashBookRepository))
            .As(typeof(ICashBookRepository))
            .InstancePerLifetimeScope();

        #endregion IOC Repositories SQL

        #region IOC Mapper

        moduleBuilder.Register(ctx => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new BuyRequestAutoMapper());
            cfg.AddProfile(new BuyRequestProductAutoMapper());
            cfg.AddProfile(new CashBookAutoMapper());
            cfg.AddProfile(new DocumentAutoMapper());
        }));

        moduleBuilder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>()
            .InstancePerLifetimeScope();

        #endregion IOC Mapper
    }
}