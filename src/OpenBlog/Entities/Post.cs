using System;
using System.ComponentModel.DataAnnotations;

namespace OpenBlog.Entities
{
    public class Post
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Slug { get; set; } 
        public string Body { get; set; }
    }
}
