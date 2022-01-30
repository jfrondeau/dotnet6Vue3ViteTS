namespace OnePunchDbContext.Models
{
    public class Orotime
    {
        public int Id { get; set; }

        /// <summary>
        /// Datetime of the record punch
        /// </summary>
        public DateTimeOffset PunchAt { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// If the record represent an entry or exit
        /// </summary>
        public bool IsIn { get; set; } = true;

        /// <summary>
        /// The user ownership
        /// </summary>
        public int UserId { get; set; }
    }
}
