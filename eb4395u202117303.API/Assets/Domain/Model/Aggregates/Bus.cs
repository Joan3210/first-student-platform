using System.Text.RegularExpressions;

namespace eb4395u202117303.API.Assets.Domain.Model.Aggregates
{
    /// <summary>
    /// Represents a Bus in the First Student fleet.
    /// <remarks>
    /// Developer: Joan Fernando Teves Samaniego
    /// </remarks>
    /// </summary>
    public class Bus
    {
        public int Id { get; private set; }
        public string VehiclePlate { get; private set; }
        public string FuelTankType { get; private set; }
        public int DistrictId { get; private set; }
        public int TotalSeats { get; private set; }
        
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        
        public Bus() { } 

        public Bus(string vehiclePlate, string fuelTankType, int districtId, int totalSeats)
        {
            if (!Regex.IsMatch(vehiclePlate, @"^[A-Z]{3}-\d{4}$"))
                throw new ArgumentException("VehiclePlate must be in the format 'ABC-1234' (3 Uppercase letters, hyphen, 4 digits).");
            
            var allowedFuels = new[] { "A", "B", "C", "D" };
            if (!allowedFuels.Contains(fuelTankType))
                throw new ArgumentException("FuelTankType must be 'A', 'B', 'C', or 'D'.");
            
            if (districtId < 1 || districtId > 3)
                throw new ArgumentException("DistrictId must be 1, 2, or 3.");
            
            if (totalSeats < 20 || totalSeats > 40)
                throw new ArgumentException("TotalSeats must be between 20 and 40.");

            VehiclePlate = vehiclePlate;
            FuelTankType = fuelTankType;
            DistrictId = districtId;
            TotalSeats = totalSeats;
        }
    }
}