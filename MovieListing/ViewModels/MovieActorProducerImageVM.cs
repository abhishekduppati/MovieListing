using MovieListing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieListing.ViewModels
{
    public class MovieActorProducerImageVM
    {
        [Key] //If we dont put this Key or ID we get entity key error while scaffolding or creating by which we cant create view like Index.
        public int MovieID { get; set; }
        [Display(Name = "Movie  Name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please Specify Datetime in YYYY-MM-DD Format")]
        [Display(Name = "Year of Release")]
        public System.DateTime YearOfRelease { get; set; }
        public string Plot { get; set; }
        public Nullable<int> ActorID { get; set; }
        public Nullable<int> ProducerID {get; set;}
        public string Title { get; set; }
        [Display(Name = "Poster")]
        public string ImagePath { get; set; }
    }
}