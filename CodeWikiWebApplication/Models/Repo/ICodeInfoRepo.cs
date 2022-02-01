using CodeWikiWebApplication.Models.Entitys;
using System.Collections.Generic;

namespace CodeWikiWebApplication.Models.Repo
{
    public interface ICodeInfoRepo
    {
        //C.R.U.D for CodeInfo

        /// <summary>
        /// Creates a new CodeInfo with a unique Id and saves it to storage.
        /// </summary>
        /// <param name="codeInfo">CodeInfo to be created and stored</param>
        /// <returns>Returns created CodeInfo</returns>
        CodeInfo Create(CodeInfo codeInfo);

        /// <summary>
        /// Returns list of stored CodeInfo
        /// </summary>
        /// <returns>Returns list of stored CodeInfo</returns>
        List<CodeInfo> Read();

        /// <summary>
        /// Finds the CodeInfo in the storage with the provided Id
        /// </summary>
        /// <param name="id">Id of Codeinfo to find</param>
        /// <returns>Returns CodeInfo if found, returns null if not found</returns>
        CodeInfo Read(int id);

        /// <summary>
        /// Updates CodeInfo in storage and returns it.
        /// </summary>
        /// <param name="codeInfo">CodeInfo to be updated in storage</param>
        /// <returns>Returns updated CodeInfo, Returns null if CodeInfo can not be found</returns>
        CodeInfo Update(CodeInfo codeInfo);

        /// <summary>
        /// Deletes CodeInfo with provided Id from storage if found.
        /// </summary>
        /// <param name="id">Id of CodeInfo to delete from storage</param>
        /// <returns>Returns True if deleted, False if not deleted</returns>
        bool Delete(int id);
    }
}
