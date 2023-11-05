using RESTApi.Dtos;
using RESTApi.Models.Database;

namespace RESTApi.Interface.Service
{
    public interface IPolicieService
    {
        public void AddPolicie(PolicieDto data);
        public Policie? FindByNumber(string number);
        public Policie? FindByVehicle(string id);
    }
}
