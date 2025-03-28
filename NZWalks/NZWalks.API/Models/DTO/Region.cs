﻿using NZWalks.API.Models.Domain;
using System.Text.Json.Serialization;

namespace NZWalks.API.Models.DTO
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        //Navigation Property
        //public IEnumerable<Domain.Walk> Walks { get; set; }
    }
}
