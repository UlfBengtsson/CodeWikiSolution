using System.ComponentModel.DataAnnotations;

namespace CodeWikiWebApplication.Models.ViewModels
{
    public class CodeInfoCreateViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Code { get; set; }

        [Required]
        [StringLength(9000, MinimumLength = 1)]
        public string Explanation { get; set; }

        public CodeInfoCreateViewModel(string code, string explanation)
        {
            Code = code;
            Explanation = explanation;
        }

    }
}
