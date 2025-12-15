using eb4395u202117303.API.Assets.Domain.Model.Aggregates;
using eb4395u202117303.API.Assets.Interfaces.REST.Resources;

namespace eb4395u202117303.API.Assets.Interfaces.REST.Transform
{
    public static class BusResourceFromEntityAssembler
    {
        public static BusResource ToResourceFromEntity(Bus entity)
        {
            return new BusResource(entity.Id, entity.VehiclePlate, entity.FuelTankType, entity.DistrictId, entity.TotalSeats);
        }
    }
}