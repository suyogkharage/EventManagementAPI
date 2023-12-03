using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IEventRepository
    {
        Task<Event?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Event?> GetByIdWithCreatorAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> Add(Event newEvent);
    }
}
