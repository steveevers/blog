using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheProduct.Data;
using TheProduct.DataContracts;

namespace TheProduct
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DataPoint, DataPointDto>();
        }
    }
}
