using CodeWikiWebApplication.Models.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace CodeWikiWebApplication.Models.Repo
{
    public class InMemoryCodeInfoRepo : ICodeInfoRepo
    {
        private static int idCounter = 0;
        private static List<CodeInfo> listOfCodeInfo = new List<CodeInfo>();

        public CodeInfo Create(CodeInfo codeInfo)
        {
            CodeInfo newCodeInfo = new CodeInfo();
            newCodeInfo.Id = ++idCounter;
            newCodeInfo.Code = codeInfo.Code;
            newCodeInfo.Explanation = codeInfo.Explanation;
            newCodeInfo.Created = System.DateTime.Now;
            
            listOfCodeInfo.Add(newCodeInfo);
            return newCodeInfo;
        }

        public List<CodeInfo> Read()
        {
            return listOfCodeInfo;
        }

        public CodeInfo Read(int id)
        {
            return listOfCodeInfo.SingleOrDefault(c => c.Id == id);
        }

        public CodeInfo Update(CodeInfo codeInfo)
        {
            CodeInfo original = Read(codeInfo.Id);

            if (original == null)
            {
                return null;
            }

            original.Code = codeInfo.Code;
            original.Explanation = codeInfo.Explanation;
            original.Edited = System.DateTime.Now;

            return original;
        }

        public bool Delete(int id)
        {
            CodeInfo original = Read(id);

            if (original == null)
            {
                return false;
            }

            return listOfCodeInfo.Remove(original);
        }
    }
}
