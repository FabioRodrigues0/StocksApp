namespace FinancialApp.Shared.Interfaces;

public interface IServiceContext
{
	IReadOnlyCollection<string> Notifications { get; }

	bool HasNotification();

	void AddNotification(string message);
}