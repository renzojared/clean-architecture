namespace NorthWind.Sales.Backend.DataContexts.EFCore.Guards;

internal static class GuardDbContext
{
    public static async Task AgainstSaveChangesErrorAsync(DbContext context)
    {
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            throw new UpdateException(e, e.Entries.Select(s => s.Entity.GetType().Name));
        }
        catch
        {
            throw;
        }
    }
}