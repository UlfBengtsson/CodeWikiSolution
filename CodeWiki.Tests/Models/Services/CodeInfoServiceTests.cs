using CodeWikiWebApplication.Models.Services;
using CodeWikiWebApplication.Models.ViewModels;
using System;
using Xunit;

namespace CodeWiki.Tests.Models.Services
{
    public class CodeInfoServiceTests
    {
        [Fact]
        public void Add_WorksAsIntended_ReturnsAddedCodeInfo()
        {
            // Arrange
            var service = new CodeInfoService();
            string codeText = "ctor";
            string explinationText = "C# inside a Class - Snippet - Hit tab two times after ctor to create a constructor for current class";
            CodeInfoCreateViewModel codeInfo = new CodeInfoCreateViewModel(codeText, explinationText);

            // Act
            var result = service.Add(codeInfo);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(0, result.Id);
            Assert.Equal(codeText, result.Code);
            Assert.Equal(explinationText, result.Explanation);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "one good")]
        [InlineData("one good", null)]
        [InlineData("", "")]
        [InlineData("", "one good")]
        [InlineData("one good", "")]
        [InlineData("  ", "  ")]
        [InlineData("  ", "one good")]
        [InlineData("one good", "  ")]
        public void Add_BadInput_ReturnsNull(string codeText, string explinationText)
        {
            // Arrange
            var service = new CodeInfoService();
            CodeInfoCreateViewModel codeInfo = new CodeInfoCreateViewModel(codeText, explinationText);

            // Act
            var result = service.Add(codeInfo);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetById_GetCorrectCodeInfo_ReturnsCorrectCodeInfo()
        {
            // Arrange
            var service = new CodeInfoService();
            CodeInfoCreateViewModel codeInfoVM1 = new CodeInfoCreateViewModel("Ctrl + D", "Duplicate line(s)");
            CodeInfoCreateViewModel codeInfoVM2 = new CodeInfoCreateViewModel("cw", "C# inside a Console App - Snippet - Hit tab two times after cw to create a Console.WriteLine");
            CodeInfoCreateViewModel codeInfoVM3 = new CodeInfoCreateViewModel("Ctrl + K + D", "Format code");
            var codeInfo1 = service.Add(codeInfoVM1);
            var codeInfo2 = service.Add(codeInfoVM2);
            var codeInfo3 = service.Add(codeInfoVM3);

            // Act
            var result = service.GetById(codeInfo2.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(codeInfo2.Id, result.Id);
            Assert.Equal(codeInfo2.Code, result.Code);
            Assert.Equal(codeInfo2.Explanation, result.Explanation);
        }

        [Fact]
        public void GetById_CodeInfoDoesNotExcist_ReturnsNull()
        {
            // Arrange
            var service = new CodeInfoService();
            service.Add(new CodeInfoCreateViewModel("code 1", "text 1"));
            service.Add(new CodeInfoCreateViewModel("code 2", "text 2"));
            service.Add(new CodeInfoCreateViewModel("code 3", "text 3"));

            // Act
            var result = service.GetById(int.MaxValue);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetList_ListContainsSamepel_ReturnsListWithSampel()
        {
            // Arrange
            var service = new CodeInfoService();
            service.Add(new CodeInfoCreateViewModel("code 1", "text 1"));
            var codeInfo = service.Add(new CodeInfoCreateViewModel("code 2", "text 2"));
            service.Add(new CodeInfoCreateViewModel("code 3", "text 3"));

            // Act
            var result = service.GetList();

            // Assert
            Assert.Contains(codeInfo, result);
        }

        [Fact]
        public void Search_ListContainsSamepel_ReturnsListWithSampel()
        {
            // Arrange
            var service = new CodeInfoService();
            string codeText1 = "foreach";
            var codeInfo = service.Add(new CodeInfoCreateViewModel(codeText1, "text"));
            var codeInfoBad1 = service.Add(new CodeInfoCreateViewModel("for", "text text"));
            var codeInfoBad2 = service.Add(new CodeInfoCreateViewModel("while", "for"));

            // Act
            var result = service.Search("fore");

            // Assert
            Assert.Contains(codeInfo, result);
            Assert.DoesNotContain(codeInfoBad1, result);
            Assert.DoesNotContain(codeInfoBad2, result);
        }

        [Fact]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = new CodeInfoService();
            string code1 = "code 1";
            string code2 = "2 code 2";
            string text1 = "text 1";
            string text2 = "2 text 2";
            var codeInfo = service.Add(new CodeInfoCreateViewModel(code1, text1));
            var editCodeInfo = new CodeInfoCreateViewModel(code2, text2);

            // Act
            var result = service.Edit(codeInfo.Id, editCodeInfo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(code2, result.Code);
            Assert.Equal(text2, result.Explanation);
        }

        [Fact]
        public void Edit_FailIdCheck_ReturnNull()
        {
            // Arrange
            var service = new CodeInfoService();
            string code1 = "code 11";
            string code2 = "22 code 22";
            string text1 = "text 11";
            string text2 = "22 text 22";
            service.Add(new CodeInfoCreateViewModel(code1, text1));
            var editCodeInfo = new CodeInfoCreateViewModel(code2, text2);

            // Act
            var result = service.Edit(int.MaxValue, editCodeInfo);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = new CodeInfoService();
            CodeInfoCreateViewModel codeInfoVM1 = new CodeInfoCreateViewModel("Ctrl + D", "Duplicate line(s)");
            CodeInfoCreateViewModel codeInfoVM2 = new CodeInfoCreateViewModel("cw", "C# inside a Console App - Snippet - Hit tab two times after cw to create a Console.WriteLine");
            CodeInfoCreateViewModel codeInfoVM3 = new CodeInfoCreateViewModel("Ctrl + K + D", "Format code");
            var codeInfo1 = service.Add(codeInfoVM1);
            var codeInfo2 = service.Add(codeInfoVM2);
            var codeInfo3 = service.Add(codeInfoVM3);

            // Act
            var result = service.Delete(codeInfo2.Id);
            var resultCodeInfoDeleted = service.GetById(codeInfo2.Id);
            var resultCodeInfoStillThere = service.GetById(codeInfo3.Id);

            // Assert
            Assert.True(result);
            Assert.Null(resultCodeInfoDeleted);
            Assert.NotNull(resultCodeInfoStillThere);
        }



    }
}
