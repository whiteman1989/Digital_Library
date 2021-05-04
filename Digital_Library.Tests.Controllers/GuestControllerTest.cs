using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Infrastructure;
using Digital_Library.BL.Interfaces;
using Digital_Library.PL.Models;
using Digital_Library.PL.Controllers;
using System.Web.Mvc;

namespace Digital_Library.Tests.Controllers
{
    [TestClass]
    public class GuestControllerTest
    {
        [TestMethod]
        public void Index_ReturnsModelAndModelNotNull()
        {
            //Arrange
            var serCreatMoq = new Mock<IServiceCreator>();
            var commentServMoq = new Mock<ICommentsSerice>();
            serCreatMoq.Setup(m => m.CreateCommentService()).Returns(commentServMoq.Object);
            commentServMoq.Setup(m => m.GetComments()).Returns(GetComments());
            var controller = new GuestController(serCreatMoq.Object);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexPost_ReturnsModelAndModelNotNull()
        {
            //Arrange
            var serCreatMoq = new Mock<IServiceCreator>();
            var commentServMoq = new Mock<ICommentsSerice>();
            serCreatMoq.Setup(m => m.CreateCommentService()).Returns(commentServMoq.Object);
            commentServMoq.Setup(m => m.GetComments()).Returns(GetComments());
            var controller = new GuestController(serCreatMoq.Object);
            var newComment = new CommentsViewModel { NewCommentAuthor = "author1", NewCommentText = "test1" };

            //Act
            var result = controller.Index(newComment) as PartialViewResult;

            //Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexPost_CallAddCommentInCommentService()
        {
            //Arrange
            var serCreatMoq = new Mock<IServiceCreator>();
            var commentServMoq = new Mock<ICommentsSerice>();
            serCreatMoq.Setup(m => m.CreateCommentService()).Returns(commentServMoq.Object);
            commentServMoq.Setup(m => m.GetComments()).Returns(GetComments());
            var controller = new GuestController(serCreatMoq.Object);
            var newComment = new CommentsViewModel { NewCommentAuthor = "author1", NewCommentText = "test1" };

            //Act
            controller.Index(newComment);

            //Assert
            commentServMoq.Verify(m => m.AddComment(It.Is<CommentDTO>(c =>
                                c.Author == newComment.NewCommentAuthor &&
                                c.Text == newComment.NewCommentText)));
        }

        private List<CommentDTO> GetComments()
        {
            return new List<CommentDTO>
            {
                    new CommentDTO
                    {
                        Id = 1,
                        Author = "Oleg",
                        Text = "I am ready to meet my Maker. Whether my Maker is prepared for the " +
                        "great ordeal of meeting me is another matter.",
                        Date = new DateTime(2021, 04, 02)
                    },
                    new CommentDTO
                    {
                        Id = 2,
                        Author = "Ihor",
                        Text = "Microsoft bought Skype for 8,5 billion!.. what a bunch of idiots! I " +
                        "downloaded it for free!",
                        Date = new DateTime(2021, 04, 15)
                    },
                    new CommentDTO
                    {
                        Id = 3,
                        Author = "User 1",
                        Text = "Don't steal, don't lie, don't cheat, don't sell drugs. The " +
                        "government hates competition!",
                        Date = new DateTime(2021,04,16)
                    },
                    new CommentDTO
                    {
                        Id = 4,
                        Author = "Max",
                        Text = "Some people come into our lives and leave footprints on our hearts, " +
                        "while others come into our lives and make us wanna leave footprints on their " +
                        "face.",
                        Date = new DateTime(2021,04,16)
                    },
                    new CommentDTO
                    {
                        Id = 5,
                        Author = "Olga",
                        Text = "Some people come into our lives and leave footprints on our hearts, " +
                        "while others come into our lives and make us wanna leave footprints on their face.",
                        Date = new DateTime(2021,04,17)
                    }
            };
        }
    }
}
