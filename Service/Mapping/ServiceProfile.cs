using AutoMapper;
using Domain.Models;
using Service.DataTransferObjects;

namespace Commander.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            //Source -> Target
            CreateMap<Ticket, TicketReadDto>();
            CreateMap<TicketCreateDto, Ticket>();
            CreateMap<TicketUpdateDto, Ticket>();
            CreateMap<Ticket, TicketUpdateDto>();
            CreateMap<TicketDeleteDto, Ticket>();
            CreateMap<Ticket, TicketDeleteDto>();
        }

    }

}