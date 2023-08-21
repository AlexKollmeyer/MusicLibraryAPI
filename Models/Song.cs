﻿using System.ComponentModel.DataAnnotations;

namespace Music_LibraryBackend.Models
{
    public class Song
    {
        [Key]
        public int Id {get; set;}
        public string Title {get; set;}
        public string Artist {get; set;}
        public string Album {get; set;}
        public string Genre {get; set;}
        public DateTime ReleaseDate { get; set; }
        public int Likes { get; set; }

   

    }
}
