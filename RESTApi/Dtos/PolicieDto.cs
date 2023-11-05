namespace RESTApi.Dtos
{
    public class PolicieDto
    {
        public string Number { get; set; }
        public string ClientName { get; set; }
        public DateTime ClientBirthDay { get; set; }
        public string ClientCity { get; set; }
        public string ClientDirection { get; set; }
        public List<string> Coverages { get; set; }
        public string MaxValue { get; set; }
        public string PlanName { get; set; }
        public string VehicleId { get; set; }
        public string VehicleModel { get; set; }
        public bool VehicleInspect { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
