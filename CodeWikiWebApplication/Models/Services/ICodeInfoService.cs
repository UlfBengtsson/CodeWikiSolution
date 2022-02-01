using CodeWikiWebApplication.Models.Entitys;
using CodeWikiWebApplication.Models.ViewModels;
using System.Collections.Generic;

namespace CodeWikiWebApplication.Models.Services
{
    public interface ICodeInfoService
    {
        /// <summary>
        /// Adds new CodeInfo.
        /// </summary>
        /// <param name="codeInfo">Create view model of CodeInfo to be added</param>
        /// <returns>Returns added CodeInfo or null if it fails</returns>
        CodeInfo Add(CodeInfoCreateViewModel codeInfoVM);

        /// <summary>
        /// Gets the CodeInfo with the provided Id.
        /// </summary>
        /// <param name="id">Id of a CodeInfo</param>
        /// <returns>Returns CodeInfo with same Id or null if not able to get it</returns>
        CodeInfo GetById(int id);

        /// <summary>
        /// Returns list of CodeInfo´s.
        /// </summary>
        /// <returns>list of CodeInfo´s</returns>
        List<CodeInfo> GetList();

        /// <summary>
        /// Searches if any CodeInfo Code contains the following text
        /// </summary>
        /// <param name="text">Text to look for</param>
        /// <returns>Returns list of matching CodeInfo´s</returns>
        List<CodeInfo> Search(string text);

        /// <summary>
        /// Edit CodeInfo using the Id and ViewModel provided.
        /// </summary>
        /// <param name="id">Id of CodeInfo to edit</param>
        /// <param name="codeInfo">Create ViewModel of CodeInfo to contain edited information and use the same validation as when you create</param>
        /// <returns>Returns edited CodeInfo or null if edit failed</returns>
        CodeInfo Edit(int id, CodeInfoCreateViewModel codeInfo);

        /// <summary>
        /// Delete CodeInfo with provided Id
        /// </summary>
        /// <param name="id">Id of CodeInfo to delete</param>
        /// <returns>Returns True if CodeInfo was deleted or False if it was not deleted alse False if it does not excist.</returns>
        bool Delete(int id);
    }
}