using AutoMapper;
using InvoiceManagementSystem.DTOs;
using InvoicesManagementSystem.Entities;

namespace InvoiceManagementSystem.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DetaliiFacturaDto, DetaliiFactura>();
            CreateMap<DetaliiFactura, DetaliiFacturaDto>();
            CreateMap<FacturaDto, Factura>();
            CreateMap<Factura, FacturaDto>();
        }
    }
}
