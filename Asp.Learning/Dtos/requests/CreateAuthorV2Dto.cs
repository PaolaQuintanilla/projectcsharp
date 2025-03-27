namespace Asp.Learning.Dtos.requests
{
    public class CreateAuthorV2Dto
    {
        public string FullName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset? DateOfDeath { get; set; }
        public string MainCategory { get; set; }
    }
}
