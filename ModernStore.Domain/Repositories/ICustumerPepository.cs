using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustumerPepository
    {
        Custumer Get(Guid id);

        Custumer GetByUserId(Guid id);

    }
}
