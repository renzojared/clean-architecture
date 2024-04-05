namespace NorthWind.Transactions.Entities.Interfaces;

public interface IDomainTransaction
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}