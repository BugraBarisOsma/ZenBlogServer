using System;
using System.Collections.Generic;
using System.Text;

namespace ZenBlog.Application.Features.Users.Results
{
    public class GetUsersQueryResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        public string UserName { get; set; }   
        public string Email { get; set; }   
        public string ImageUrl { get; set; }   

    }
}
