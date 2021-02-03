using AutoMapper;
using InvoiceManagementSystem.DTOs;
using InvoicesManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DetaliiFacturaDto, DetaliiFactura>();
            CreateMap<FacturaDto, Factura>();
            CreateMap<Factura, FacturaDto>();
        }

    }
}
