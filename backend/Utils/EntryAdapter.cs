using backend.Models;

namespace OnePunch.Utils
{
    public static class EntryAdapter
    {
        public static Dto.EntryDto ToDto(this Entry model)
        {
            return new Dto.EntryDto
            {
                IsIn = model.IsIn,
                PunchAt = model.PunchAt,
                UserId = model.UserId,
                Id=model.Id
                
            };
        }

        public static void Map(this Entry model, Dto.EntryDto dto)
        {
            model.IsIn = dto.IsIn;
            model.PunchAt = dto.PunchAt;
            model.UserId = dto.UserId;
        }
    }
}
