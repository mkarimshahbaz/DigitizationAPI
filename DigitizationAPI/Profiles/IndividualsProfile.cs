using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizationAPI.Profiles
{
    public class IndividualsProfile : Profile
    {
        public IndividualsProfile()
        {
            CreateMap<Entities.Individual, Models.IndividualDto>();
        }
    }
}
