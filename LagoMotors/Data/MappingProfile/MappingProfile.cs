using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LagoMotors.Controllers.Resources;
using LagoMotors.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace LagoMotors.Data.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>().ReverseMap();
            CreateMap<Feature, FeatureResource>().ReverseMap();
            CreateMap<Model, ModelResource>().ReverseMap();
        }
       
    }
}
