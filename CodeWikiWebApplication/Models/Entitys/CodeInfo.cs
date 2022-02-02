using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWikiWebApplication.Models.Entitys
{
    public class CodeInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }
        [Required]
        public string Explanation { get; set; }

        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

    }
}
