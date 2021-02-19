using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuotingDojo.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId{get;set;}

        [Required]
        [MinLength(2)]
        public string Name{get;set;}

        [Required]
        [MinLength(10)]
        public string UserQuote{get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}