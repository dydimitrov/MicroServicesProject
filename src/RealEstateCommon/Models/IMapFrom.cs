using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace RealEstateCommon.Models
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
    }
}