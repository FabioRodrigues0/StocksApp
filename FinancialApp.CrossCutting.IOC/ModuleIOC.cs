using Autofac;

namespace FinancialApp.CrossCutting.IOC;

public class ModuleIOC : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		#region Load IOC

		ConfigurationIOC.Load(builder);

		#endregion Load IOC
	}
}