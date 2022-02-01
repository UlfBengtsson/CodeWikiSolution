using CodeWikiWebApplication.Models.Entitys;
using CodeWikiWebApplication.Models.Repo;
using CodeWikiWebApplication.Models.ViewModels;
using System.Collections.Generic;

namespace CodeWikiWebApplication.Models.Services
{
    public class CodeInfoService : ICodeInfoService
    {

        private readonly ICodeInfoRepo _codeInfoRepo;

        public CodeInfoService()
        {
            _codeInfoRepo = new InMemoryCodeInfoRepo();
        }

        public CodeInfo Add(CodeInfoCreateViewModel codeInfoVM)
        {
            if (string.IsNullOrWhiteSpace(codeInfoVM.Code) || string.IsNullOrWhiteSpace(codeInfoVM.Explanation))
            {
                return null;
            }
            CodeInfo newCodeInfo = new CodeInfo()
            {
                Code = codeInfoVM.Code,
                Explanation = codeInfoVM.Explanation
            };

            CodeInfo codeInfo = _codeInfoRepo.Create(newCodeInfo);

            return codeInfo;
        }

        public CodeInfo GetById(int id)
        {
            return _codeInfoRepo.Read(id);
        }

        public List<CodeInfo> GetList()
        {
            return _codeInfoRepo.Read();
        }

        public List<CodeInfo> Search(string text)
        {
            var list = _codeInfoRepo.Read();
            List<CodeInfo> matches = new List<CodeInfo>();

            if (string.IsNullOrWhiteSpace(text))
            {
                return matches;
            }

            foreach (var item in list)
            {
                if (item.Code.Contains(text))
                {
                    matches.Add(item);
                }
            }

            return matches;
        }

        public CodeInfo Edit(int id, CodeInfoCreateViewModel codeInfo)
        {
            CodeInfo editCodeInfo = new CodeInfo() 
            {
                Id = id, 
                Code = codeInfo.Code, 
                Explanation = codeInfo.Explanation 
            };
            return _codeInfoRepo.Update(editCodeInfo);
        }

        public bool Delete(int id)
        {
            return _codeInfoRepo.Delete(id);
        }
    }
}
