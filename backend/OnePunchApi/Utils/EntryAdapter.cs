using OnePunch.Dto;
using OnePunchDbContext.Models;

namespace OnePunch.Utils
{
    public static class EntryAdapter
    {
        public static Dto.OrotimeDto ToDto(this Orotime model)
        {
            return new Dto.OrotimeDto
            {
                IsIn = model.IsIn,
                PunchAt = model.PunchAt,
                UserId = model.UserId,
                Id=model.Id
                
            };
        }

        public static void Map(this Orotime model, OrotimeDto dto)
        {
            model.IsIn = dto.IsIn;
            model.PunchAt = dto.PunchAt;
            model.UserId = dto.UserId;
        }
    }
}
