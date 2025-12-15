using eb4395u202117303.API.Assets.Domain.Model.Aggregates;
using eb4395u202117303.API.Assets.Interfaces.REST.Resources;

namespace eb4395u202117303.API.Assets.Interfaces.REST.Transform
{
    public static class CreateBusCommandFromResourceAssembler
    {
        public static Bus ToEntityFromResource(CreateBusResource resource)
        {
            return new Bus(resource.VehiclePlate, resource.FuelTankType, resource.DistrictId, resource.TotalSeats);
        }
    }
}