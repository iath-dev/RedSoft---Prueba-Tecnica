using Amazon.Auth.AccessControlPolicy;
using AutoMapper;
using RESTApi.Dtos;
using RESTApi.Interface;
using RESTApi.Interface.Service;
using RESTApi.Models.Database;

namespace RESTApi.Services
{
    public class PolicieService : IPolicieService
    {
        private readonly IMongoRepository<Policie> _policieRepository;

        private IMapper _mapper;

        public PolicieService(IMongoRepository<Policie> policieRepository, IMapper mapper)
        {
            _policieRepository = policieRepository;
            _mapper = mapper;
        }

        public void AddPolicie(PolicieDto data)
        {

            if (data.EndDate <= DateTime.UtcNow)
            {
                throw new Exception();
            }

            var model = _mapper.Map<Policie>(data);

            _policieRepository.InsertOne(model);
        }

        public Policie FindByNumber(string number)
        {
            var res = _policieRepository.FindOne(x => x.Number == number);

            if(res == null)
            {
                throw new Exception();
            }

            return res;
        }

        public Policie FindByVehicle(string id)
        {
            var res = _policieRepository.FindOne(x => x.VehicleId == id);

            if (res == null)
            {
                throw new Exception();
            }

            return res;
        }
    }
}
