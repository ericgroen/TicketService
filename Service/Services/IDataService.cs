using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IDataService
    {
        bool SaveChanges();
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        void CreateAsync(Ticket ticket);
        void UpdateAsync(Ticket ticket);
        void DeleteAsync(Ticket ticket);
    }
}
