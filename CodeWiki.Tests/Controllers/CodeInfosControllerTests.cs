using CodeWikiWebApplication.Controllers;
using CodeWikiWebApplication.Models;
using CodeWikiWebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace CodeWiki.Tests.Controllers
{
    public class CodeInfosControllerTests
    {
        [Fact]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();

            // Act
            var result = codeInfosController.Index();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();
            int id = 0;

            // Act
            var result = codeInfosController.Details(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Create_ValidPost_RedirectToIndex()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();
            CodeInfoCreateViewModel createViewModel = new CodeInfoCreateViewModel("ctor", "cunstructor");

            // Act
            var result = codeInfosController.Create(createViewModel);

            // Assert
            RedirectToActionResult redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("CodeInfos", redirectResult.ControllerName);
        }

        [Fact]
        public void Create_InvalidModelState_ReturnToViewWithModelStateErrors()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();
            CodeInfoCreateViewModel createViewModel = new CodeInfoCreateViewModel("ctor", "");

            // Act
            var result = codeInfosController.Create(createViewModel);

            // Assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            CodeInfoCreateViewModel codeInfoCreateVMResult = Assert.IsType<CodeInfoCreateViewModel>(viewResult.Model);
            Assert.Equal("ctor", codeInfoCreateVMResult.Code);
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();
            CodeInfoCreateViewModel createViewModel = null;

            // Act
            var result = codeInfosController.Create();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();
            int id = 0;

            // Act
            var result = codeInfosController.Edit(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();
            int id = 0;
            IFormCollection collection = null;

            // Act
            var result = codeInfosController.Edit(
                id,
                collection);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();
            int id = 0;

            // Act
            var result = codeInfosController.Delete(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var codeInfosController = new CodeInfosController();
            int id = 0;
            bool confirm = false;

            // Act
            var result = codeInfosController.Delete(
                id,
                confirm);

            // Assert
            Assert.True(false);
        }
    }
}
