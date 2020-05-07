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
        {   //Domain to API Resource
            CreateMap<Make, MakeResource>().ReverseMap();
            CreateMap<Feature, FeatureResource>().ReverseMap();
            CreateMap<Model, ModelResource>().ReverseMap();
            CreateMap<Vehicle,VehicleResource>()
                .ForMember(vr => vr.Contact,
                    opt => opt.MapFrom(
                        v => new ContactResource
                        {
                            Name=v.ContactName,
                            Email = v.ContactEmail,
                            Phone = v.ContactPhone
                        }))

                .ForMember(vr => vr.Features,
                    opt => opt.MapFrom(v => v.Features.Select(vf=>vf.FeatureId)));
              
            // API Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.ContactName,
                    opt => opt.MapFrom(vr => vr.Contact.Name))

                .ForMember(v => v.ContactEmail,
                    opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone,
                    opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features,
                    opt => opt.MapFrom(
                        vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id })));
        }

    }
}
