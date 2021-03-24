using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class Response
    {
        //primary key
        [Key]
        public int SubmissionId { get; set; }

        [Required(ErrorMessage = "Please enter the Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter the Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the Year")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Please enter the Director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter the Rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes should be limited to 25 characters.")]
        public string Notes { get; set; }

  
    }
}
