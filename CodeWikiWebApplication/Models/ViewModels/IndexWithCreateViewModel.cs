using CodeWikiWebApplication.Models.Entitys;
using System.Collections.Generic;

namespace CodeWikiWebApplication.Models.ViewModels
{
    public class IndexWithCreateViewModel
    {
        public List<CodeInfo> TheList { get; set; }
        public CodeInfoCreateViewModel CreateViewModel { get; set; }

    }
}
