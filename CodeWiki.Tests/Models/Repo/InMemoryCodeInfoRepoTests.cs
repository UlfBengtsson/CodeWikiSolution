using CodeWikiWebApplication.Models.Entitys;
using CodeWikiWebApplication.Models.Repo;
using System;
using Xunit;

namespace CodeWiki.Tests.Models.Repo
{
    public class InMemoryCodeInfoRepoTests
    {
        [Fact]
        public void Create_IdGeneration_UniqueIds()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            CodeInfo codeInfo = new CodeInfo();

            // Act
            CodeInfo result1 = inMemoryCodeInfoRepo.Create(codeInfo); 
            CodeInfo result2 = inMemoryCodeInfoRepo.Create(codeInfo); 
            CodeInfo result3 = inMemoryCodeInfoRepo.Create(codeInfo);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotNull(result3);

            Assert.NotEqual(0, result1.Id);// It can be a problem if we can have 0 as a Id (defualt value for a int is 0)
            Assert.NotEqual(0, result2.Id);
            Assert.NotEqual(0, result3.Id);

            Assert.True(result1.Id != result2.Id || result1.Id != result3.Id);
            Assert.True(result2.Id != result3.Id);
        }

        [Fact]
        public void Create_AllValuesSet_ValuesAreSetRight()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            string codeText = "Assert.Equal(expectedValue, actualValue);";
            string explanation = "Assert Equal method will check if the expectedValue is the same as actualValue and fail the test if they are not";

            CodeInfo codeInfo = new CodeInfo() { Code = codeText, Explanation = explanation };

            // Act
            CodeInfo result = inMemoryCodeInfoRepo.Create(codeInfo);

            // Assert
            Assert.Equal(codeText, result.Code);
            Assert.Equal(explanation, result.Explanation);
            Assert.Equal(DateTime.Now.Date, result.Created.Date);//Made a very simpel check here, DateTime can be very tricky if it has to be tested very precise.
        }

        [Fact]
        public void Read_ListIsInstansiated_NotNull()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();

            // Act
            var result = inMemoryCodeInfoRepo.Read();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Read_ListHasCreatedCodeInfo_ListContainsCreated()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            CodeInfo codeInfo1 = inMemoryCodeInfoRepo.Create( new CodeInfo() { Code = "code1", Explanation = "explanation1" });
            CodeInfo codeInfo2 = inMemoryCodeInfoRepo.Create( new CodeInfo() { Code = "code2", Explanation = "explanation2" });
            CodeInfo codeInfo3 = inMemoryCodeInfoRepo.Create( new CodeInfo() { Code = "code3", Explanation = "explanation3" });
            CodeInfo codeInfoLocal = new CodeInfo() { Code = "codeLocal", Explanation = "explanationLocal" };

            // Act
            var result = inMemoryCodeInfoRepo.Read();

            // Assert
            Assert.Contains(codeInfo1, result);
            Assert.Contains(codeInfo2, result);
            Assert.Contains(codeInfo3, result);
            /* edge case */
            Assert.DoesNotContain(codeInfoLocal, result);//locally created CodeInfo shall not be in the list.

        }

        [Fact]
        public void Read_ExistingId_ReturnsCorrectCodeInfo()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            CodeInfo codeInfo1 = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = "code1", Explanation = "explanation1" });
            CodeInfo codeInfo2 = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = "code2", Explanation = "explanation2" });
            CodeInfo codeInfo3 = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = "code3", Explanation = "explanation3" });

            // Act
            var result = inMemoryCodeInfoRepo.Read(codeInfo2.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(codeInfo2.Id, result.Id);
        }

        [Fact]
        public void Read_NoneExistingId_ReturnsNull()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            CodeInfo codeInfo1 = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = "code1", Explanation = "explanation1" });
            CodeInfo codeInfo2 = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = "code2", Explanation = "explanation2" });
            CodeInfo codeInfo3 = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = "code3", Explanation = "explanation3" });

            int noneCreatedId = int.MaxValue;// I will assume the max int Id has not bin used.

            // Act
            var result = inMemoryCodeInfoRepo.Read(noneCreatedId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Update_UpdateExcistingCodeInfo_ReturnsUpdatedCodeInfo()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            string originalCodeText = "original";
            string originalExplanationText = "before update";
            CodeInfo original = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = originalCodeText, Explanation = originalExplanationText });
            CodeInfo toUpdateCodeInfo = new CodeInfo() { Id = original.Id, Code = "modefied", Explanation = "after update" };

            // Act
            var result = inMemoryCodeInfoRepo.Update(toUpdateCodeInfo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(original.Id, result.Id);
            Assert.Equal(toUpdateCodeInfo.Id, result.Id);

            Assert.NotEqual(originalCodeText, result.Code);
            Assert.NotEqual(originalExplanationText, result.Explanation);

            Assert.Equal(toUpdateCodeInfo.Code, result.Code);
            Assert.Equal(toUpdateCodeInfo.Explanation, result.Explanation);
        }

        [Fact]
        public void Update_CanNotUpdateNoneExcistingCodeInfo_ReturnsNull()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            CodeInfo toUpdateCodeInfo = new CodeInfo() { Id = int.MaxValue, Code = "fake", Explanation = "bad Id" };

            // Act
            var result = inMemoryCodeInfoRepo.Update(toUpdateCodeInfo);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Delete_RemoveExcisting_ReturnsTrue()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            CodeInfo shortLived = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = "original", Explanation = "before update" });

            // Act
            var result = inMemoryCodeInfoRepo.Delete(shortLived.Id);
            var resultRead = inMemoryCodeInfoRepo.Read(shortLived.Id);

            // Assert
            Assert.True(result);
            Assert.Null(resultRead);//validate its removed from list too
        }

        [Fact]
        public void Delete_CanNotDeleteNoneExcistingCodeInfo_ReturnsFalse()
        {
            // Arrange
            var inMemoryCodeInfoRepo = new InMemoryCodeInfoRepo();
            CodeInfo longLived = inMemoryCodeInfoRepo.Create(new CodeInfo() { Code = "original", Explanation = "before update" });

            // Act
            var result = inMemoryCodeInfoRepo.Delete(int.MaxValue);

            // Assert
            Assert.False(result);
        }
    }
}
