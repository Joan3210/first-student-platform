namespace eb4395u202117303.API.Operations.Domain.Model.Aggregates
{
    /// <summary>
    /// Represents an Assignment Aggregate Root.
    /// <remarks>Developer: Joan Fernando Teves Samaniego</remarks>
    /// </summary>
    public class Assignment
    {
        public int Id { get; private set; }
        public int StudentId { get; private set; }
        public int BusId { get; private set; }
        public DateTime AssignedAt { get; private set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Assignment() { }

        public Assignment(int studentId, int busId)
        {
            StudentId = studentId;
            BusId = busId;
            AssignedAt = DateTime.Now; // [cite: 67]
        }
    }
}