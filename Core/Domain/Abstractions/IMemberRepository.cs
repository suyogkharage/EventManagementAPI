using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
