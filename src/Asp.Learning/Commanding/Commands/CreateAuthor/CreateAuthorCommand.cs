﻿using Asp.Learning.Dtos.requests;

namespace Asp.Learning.Commanding.Commands.CreateAuthor
{
    public class CreateAuthorCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public DateTimeOffset? DateOfDeath { get; set; }
        public string MainCategory { get; set; }
        public ICollection<AddCourseToAuthorV1Dto> Courses { get; set; }
    }
}
