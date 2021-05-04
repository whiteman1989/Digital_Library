using Microsoft.VisualStudio.TestTools.UnitTesting;
using Digital_Library.DAL.Entities;
using Digital_Library.DAL.Interfaces;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Services;
using Digital_Library.BL.Infrastructure;
using System;
using System.Linq;
using System.Collections.Generic;
using Moq;

namespace Digital_Library.Tests.Services
{
    [TestClass]
    public class CommentServiceTest
    {
        [TestMethod]
        public void AdddComment_AddCommentAndSaveChange()
        {
            //Arrange
            var commentRepMoq = new Mock<IRepository<Comment>>();
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(m => m.Comments).Returns(commentRepMoq.Object);
            var commentService = new CommentService(uowMoq.Object);
            var newComment = new CommetDTO { Text = "1", Author = "2" };

            //Act
            commentService.AddComment(newComment);

            //Assert
            uowMoq.Verify(m => m.Comments.Create(It.Is<Comment>(c => c.Text == newComment.Text)));
            uowMoq.Verify(m => m.Save(), Times.Once());
        }

        [TestMethod]
        public void DleteComment_DeleteCommentAndSaveChange_IfCommentIsExist()
        {
            //Arrange
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(m => m.Comments.Delete(It.IsAny<int>())).Returns(true);
            var commentService = new CommentService(uowMoq.Object);
            int commentId = 1;

            //Act
            commentService.DeleteComment(commentId);

            //Assert
            uowMoq.Verify(m => m.Comments.Delete(It.Is<int>(id => id == commentId)));
            uowMoq.Verify(m => m.Save(), Times.Once);
        }

        [TestMethod]
        public void DeleteComment_TrowValidationExceptionAndNotSaveChanges_IfCommentIsNotExist()
        {
            //Arrange
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(m => m.Comments.Delete(It.IsAny<int>())).Returns(false);
            var commentService = new CommentService(uowMoq.Object);
            int commentId = 10;

            //Act
            Action act = () => commentService.DeleteComment(commentId);

            //Assert
            Assert.ThrowsException<ValidationException>(act);
            uowMoq.Verify(m => m.Save(), Times.Never);
        }

        [TestMethod]
        public void GetComment_ReturnsCorrectComment()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var commentService = new CommentService(uowMoq.Object);
            int commentId = 2;

            //Act
            var result = commentService.GetComment(commentId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(commentId, result.ID);
        }

        [TestMethod]
        public void GetComments_ReturnsCollectionOfAllComments()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var commentService = new CommentService(uowMoq.Object);

            //Act
            var result = commentService.GetComments();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(GetComments().Count, result.Count());
        }

        [TestMethod]
        public void GetComments_ReturnstCurentNumberOfComments_WhenUseItWithArguments()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var commentService = new CommentService(uowMoq.Object);
            int commentsOnPage = 3;

            //Act
            var result = commentService.GetComments(commentsOnPage, 1);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() <= commentsOnPage);
        }

        [TestMethod]
        public void PageCount_ReturnsNumberOfPages()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var commentService = new CommentService(uowMoq.Object);
            int commentsOnPage = 2;

            //Act
            var res = commentService.PageCount(commentsOnPage);

            //Assert
            Assert.AreEqual(3, res);
        }

        [TestMethod]
        public void UpdateComment_UpdateCommentAndSaveChange()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var commentService = new CommentService(uowMoq.Object);
            var updatedComment = new CommetDTO { ID = 1, Author = "1", Text = "2", Date = DateTime.Now };

            //Act
            commentService.UpdateComment(updatedComment);

            //Assert
            uowMoq.Verify(m => m.Comments.Update(It.Is<Comment>(c => c.Id == updatedComment.ID &&
                                                                     c.Text == updatedComment.Text &&
                                                                     c.Author == updatedComment.Author &&
                                                                     c.Date == updatedComment.Date)));
            uowMoq.Verify(m => m.Save(), Times.Once);
        }

        #region DATA AND REPO
        private Mock<IRepository<Comment>> GetCommentRepositoryMoq()
        {
            var postRepMoq = new Mock<IRepository<Comment>>();
            postRepMoq.Setup(m => m.Get(It.IsAny<int>()))
                .Returns((int id) => GetComments().SingleOrDefault(p => p.Id == id));
            postRepMoq.Setup(m => m.GetAll()).Returns(GetComments().AsQueryable());
            postRepMoq.Setup(m => m.Find(It.IsAny<Func<Comment, bool>>()))
                .Returns((Func<Comment, bool> func) => GetComments().Where(func).AsQueryable());
            return postRepMoq;
        }

        private Mock<IUnitOfWork> GetUowMoq()
        {
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(m => m.Comments).Returns(GetCommentRepositoryMoq().Object);
            return uow;
        }

        private List<Comment> GetComments()
        {
            return new List<Comment>
        {
                new Comment
                {
                    Id = 1,
                    Author = "Oleg",
                    Text = "I am ready to meet my Maker. Whether my Maker is prepared for the " +
                    "great ordeal of meeting me is another matter.",
                    Date = new DateTime(2021, 04, 02)
                },
                new Comment
                {
                    Id = 2,
                    Author = "Ihor",
                    Text = "Microsoft bought Skype for 8,5 billion!.. what a bunch of idiots! I " +
                    "downloaded it for free!",
                    Date = new DateTime(2021, 04, 15)
                },
                new Comment
                {
                    Id = 3,
                    Author = "User 1",
                    Text = "Don't steal, don't lie, don't cheat, don't sell drugs. The " +
                    "government hates competition!",
                    Date = new DateTime(2021,04,16)
                },
                new Comment
                {
                    Id = 4,
                    Author = "Max",
                    Text = "Some people come into our lives and leave footprints on our hearts, " +
                    "while others come into our lives and make us wanna leave footprints on their " +
                    "face.",
                    Date = new DateTime(2021,04,16)
                },
                new Comment
                {
                    Id = 5,
                    Author = "Olga",
                    Text = "Some people come into our lives and leave footprints on our hearts, " +
                    "while others come into our lives and make us wanna leave footprints on their face.",
                    Date = new DateTime(2021,04,17)
                }
        };
        }
        #endregion DATA AND REPO
    }
}
