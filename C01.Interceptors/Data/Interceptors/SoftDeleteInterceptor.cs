using C01.Interceptors.Entities.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace C01.Interceptors.Data.Interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null)
                return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                // if (entry is null || entry.State != EntityState.Deleted || !(entry.Entity is ISoftDeleteable entity))
                if (entry is not { State: EntityState.Deleted, Entity: ISoftDeleteable entity })
                    continue;
                entry.State = EntityState.Modified;

                entity.Delete();
            }

            return result;
        }
    }
}
