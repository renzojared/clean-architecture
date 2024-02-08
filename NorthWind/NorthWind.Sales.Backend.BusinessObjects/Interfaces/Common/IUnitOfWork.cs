namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Common;

public interface IUnitOfWork
{
    Task SaveChanges();
}

