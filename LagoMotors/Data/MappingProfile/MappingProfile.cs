﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LagoMotors.Controllers.Resources;
using LagoMotors.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace LagoMotors.Data.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {   //Domain to API Resource
            CreateMap<Make, MakeResource>().ReverseMap();
             CreateMap<Make, KeyValuePairResource>().ReverseMap();
            CreateMap<Feature, KeyValuePairResource>().ReverseMap();
            CreateMap<Model, KeyValuePairResource>().ReverseMap();
            CreateMap<Vehicle,SaveVehicleResource>()
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
            // map get vehicle
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Make,opt=>opt.MapFrom(v=>v.Model.Make))
                .ForMember(vr => vr.Contact,
                    opt => opt.MapFrom(
                        v => new ContactResource
                        {
                            Name = v.ContactName,
                            Email = v.ContactEmail,
                            Phone = v.ContactPhone
                        }))

                .ForMember(vr => vr.Features,
                    opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairResource
                    {
                        Id = vf.FeatureId,
                        Name = vf.Feature.Name
                    })));

            // API Resource to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName,
                    opt => opt.MapFrom(vr => vr.Contact.Name))

                .ForMember(v => v.ContactEmail,
                    opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone,
                    opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                 // removing unselected features
                  var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                  foreach (var f in removedFeatures)
                        v.Features.Remove(f);

                  // Add new features
                  var addedFeatures = vr.Features.Where(id => v.Features.All(f => f.FeatureId != id))
                      .Select(id => new VehicleFeature {FeatureId = id}).ToList();

                  foreach (var f in addedFeatures)
                  {
                      v.Features.Add( f);
                  }

                });
                    




        }

    }
}