﻿using AutoMapper;
using TransportGlobal.Application.CQRSs.ReviewContextCQRSs.CommandCreateReview;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandCreateUser;
using TransportGlobal.Application.CQRSs.UserContextCQRSs.CommandUpdateUser;
using TransportGlobal.Domain.Entities.ReviewContextEntities;
using TransportGlobal.Domain.Entities.UserContextEntities;

namespace TransportGlobal.Application.Mappings
{
    public class CommandRequestToEntityMappings : Profile
    {
        public CommandRequestToEntityMappings()
        {
            #region User Bounded Context Mappings
            CreateMap<CreateUserCommandRequest, UserEntity>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ConstructUsing(src => new UserEntity(src.Name, src.Surname, src.Email, src.Password, src.Type));

            CreateMap<UpdateUserCommandRequest, UserEntity>();
            #endregion

            #region Review Bounded Context Mappings
            CreateMap<CreateReviewCommandRequest, ReviewEntity>();
            #endregion
        }
    }
}
