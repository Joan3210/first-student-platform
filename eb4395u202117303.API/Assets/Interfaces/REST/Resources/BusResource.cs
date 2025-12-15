namespace eb4395u202117303.API.Assets.Interfaces.REST.Resources
{
    public record BusResource(
        int Id, 
        string VehiclePlate, 
        string FuelTankType, 
        int DistrictId, 
        int TotalSeats
    );
}