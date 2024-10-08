using System;

namespace AdminBlog.Models{

    public class Blog{
        public int Id { get;set;}

        public string? Title {get; set;}

        public string? Subtitle { get;set;}

        public string? Content {get;set;}

        public string? Imagepath {get;set;}

        public string? IsPublih {get;set;}

        public Author? Author {get;set;}

        public int AuthorId {get;set;}

        public Category? Category {get;set;}
    

        public int CategoryId {get;set;}
    }



}