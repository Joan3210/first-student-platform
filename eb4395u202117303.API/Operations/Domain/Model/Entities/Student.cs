namespace eb4395u202117303.API.Operations.Domain.Model.Entities
{
    /// <summary>
    /// Represents a Student Entity.
    /// <remarks>Developer: Joan Fernando Teves Samaniego</remarks>
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DistrictId { get; set; }
        public int ParentId { get; set; }
    }
}