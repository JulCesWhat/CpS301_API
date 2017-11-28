using CpS301_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpS301_API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            // Init dummy data
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 0,
                    Name = "capi",
                    Description = "City .... ",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 0,
                            Name = "capi11",
                            Description = "City .... 11"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "capi22",
                            Description = "City .... 22"
                        },
                    }
                },
                new CityDto()
                {
                    Id = 1,
                    Name = "Shishi",
                    Description = "capivra .... ",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 0,
                            Name = "Shishi",
                            Description = "capivra .... ",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Shishi",
                            Description = "capivra .... ",
                        },
                    }
                }
            };
        }
    }
}
