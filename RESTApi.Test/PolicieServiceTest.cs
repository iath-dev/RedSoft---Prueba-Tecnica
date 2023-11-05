using AutoMapper;
using MongoDB.Driver;
using Moq;
using RESTApi.Dtos;
using RESTApi.Interface;
using RESTApi.Interface.Service;
using RESTApi.Models.Database;
using RESTApi.Profiles;
using RESTApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTApi.Test
{
    public class PolicieServiceTest
    {
        private readonly Mock<IMongoRepository<Policie>> _policieRepository;
        private IPolicieService _policieService;

        public PolicieServiceTest()
        {

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            });

            var mapper = mockMapper.CreateMapper();

            _policieRepository = new Mock<IMongoRepository<Policie>>();

            _policieService = new PolicieService(_policieRepository.Object, mapper);
        }

        [Fact]
        public void CreatePolicie()
        {
            var data = new PolicieDto()
            {
                ClientBirthDay = DateTime.Now,
                ClientCity = "string",
                ClientDirection = "string",
                ClientName = "string",
                MaxValue = "string",
                Number = "string",
                PlanName = "string",
                StartDate = DateTime.Now,
                VehicleId = "string",
                VehicleInspect = true,
                VehicleModel = "string",
                EndDate = DateTime.Now.AddDays(5),
                Coverages = new List<string> { "string" }
            };

            _policieService.AddPolicie(data);

            _policieRepository.Verify(r => r.InsertOne(It.IsAny<Policie>()), Times.Once());
        }

        [Fact]
        public void CreatePolicieError()
        {
            var data = new PolicieDto()
            {
                ClientBirthDay = DateTime.Now,
                ClientCity = "string",
                ClientDirection = "string",
                ClientName = "string",
                MaxValue = "string",
                Number = "string",
                PlanName = "string",
                StartDate = DateTime.Now,
                VehicleId = "string",
                VehicleInspect = true,
                VehicleModel = "string",
                EndDate = DateTime.MinValue,
                Coverages = new List<string> { "string" }
            };

            Assert.Throws<Exception>(() => _policieService.AddPolicie(data));
        }
    }
}
