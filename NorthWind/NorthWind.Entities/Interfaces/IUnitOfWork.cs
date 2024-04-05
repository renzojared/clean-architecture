namespace NorthWind.Entities.Interfaces;

public interface IUnitOfWork
{
    Task SaveChanges();
}

