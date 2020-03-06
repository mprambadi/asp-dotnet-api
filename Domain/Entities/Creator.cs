using System;

namespace dotnet_mediatr.Domain.Entities
{
    public class Creator
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}