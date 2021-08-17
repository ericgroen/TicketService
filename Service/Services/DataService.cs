using Domain.DataContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DataService : IDataService
    {
        private readonly ServiceDbContext context;

        public DataService(ServiceDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        void IDataService.CreateAsync(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            context.Ticket.Add(ticket);
        }

        void IDataService.DeleteAsync(Ticket ticket)
        {
            context.Ticket.Remove(ticket);
        }

        async Task<IEnumerable<Ticket>> IDataService.GetAllAsync()
        {
            return await context.Ticket.ToListAsync();
        }

        async Task<Ticket> IDataService.GetByIdAsync(int id)
        {
            return await context.Ticket.FindAsync(id);
        }

        bool IDataService.SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        void IDataService.UpdateAsync(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            context.Ticket.Update(ticket);
        }
    }
}
