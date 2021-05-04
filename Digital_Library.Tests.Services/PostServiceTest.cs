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
    public class PostServiceTest
    {
        [TestMethod]
        public void AddPost_GetPostDTOAndAddPostToReposistoryAndSaveChange()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var postService = new PostService(uowMoq.Object);
            var newPostDTO = new PostDTO() { Title = "test", Text = "test2" };

            //Act
            postService.AddPost(newPostDTO);

            //Assert
            uowMoq.Verify(m => m.Posts.Create(It.Is<Post>(p => p.Title == newPostDTO.Title
                                                            && p.Text == newPostDTO.Text)));
            uowMoq.Verify(m => m.Save(), Times.Once());
        }

        [TestMethod]
        public void DeletePost_DeletePostAndSaveChanges_IfPostIsExist()
        {
            //Arrange
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(m => m.Posts.Delete(It.IsAny<int>())).Returns(true);
            var postService = new PostService(uowMoq.Object);
            int postId = 1;

            //act
            postService.DeletePost(postId);

            uowMoq.Verify(m => m.Posts.Delete(It.Is<int>(id => id == postId)));
            uowMoq.Verify(m => m.Save(), Times.Once());
        }

        [TestMethod]
        public void DeletePost_ThrowsValidationExceptionAndNotSaveChamges_IfPostIsNotExist()
        {
            //Arrange
            var uowMoq = new Mock<IUnitOfWork>();
            uowMoq.Setup(m => m.Posts.Delete(It.IsAny<int>())).Returns(false);
            var postService = new PostService(uowMoq.Object);
            int postId = 1;

            //act
            Action act = () => postService.DeletePost(postId);

            Assert.ThrowsException<ValidationException>(act);
            uowMoq.Verify(m => m.Save(), Times.Never());
        }

        [TestMethod]
        public void EditPost_UpdatesPostAndSaveChange()
        {
            //Arrange
            var uowMoq = new Mock<IUnitOfWork>();
            var postsMoq = new Mock<IRepository<Post>>();
            uowMoq.Setup(m => m.Posts).Returns(postsMoq.Object);
            var postService = new PostService(uowMoq.Object);
            var updatedPost = new PostDTO { Id = 1, Text = "test1", Title = "test2", Date = DateTime.Now };

            //act
            postService.EditPost(updatedPost);

            uowMoq.Verify(m => m.Posts.Update(It.Is<Post>(p => p.Id == updatedPost.Id &&
                                                               p.Text == updatedPost.Text &&
                                                               p.Title == updatedPost.Title &&
                                                               p.Date == updatedPost.Date)));
            uowMoq.Verify(m => m.Save(), Times.Once());
        }

        [TestMethod]
        public void GetPost_ReturnsPost_IfPostIsExist()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var postService = new PostService(uowMoq.Object);
            int postId = 1;

            //Act
            var res = postService.GetPost(postId);

            //Assert
            Assert.AreEqual(GetPosts().FirstOrDefault(p => p.Id == postId).Text, res.Text);
        }

        public void GetPost_ReturnsNull_IfPostIsNotExist()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var postService = new PostService(uowMoq.Object);
            int postId = 10;

            //Act
            var res = postService.GetPost(postId);

            //Assert
            Assert.IsNull(res);
        }

        [TestMethod]
        public void GetPosts_ReturnsCollectionOfAllPostsDTO()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var postService = new PostService(uowMoq.Object);

            //Act
            var res = postService.GetPosts();

            //Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(GetPosts().Count, res.Count());
        }

        [TestMethod]
        public void GetPosts_ReturnstCurentNumberOfPosts_WhenUseItWithArguments()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var postService = new PostService(uowMoq.Object);
            int postOnPage = 2;

            //Act
            var res = postService.GetPosts(postOnPage, 1);

            //Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count() <= postOnPage);
        }

        [TestMethod]
        public void PageCount_ReturnsNumberOfPages()
        {
            //Arrange
            var uowMoq = GetUowMoq();
            var postService = new PostService(uowMoq.Object);
            int postOnPage = 2;

            //Act
            var res = postService.PageCount(postOnPage);

            //Assert
            Assert.AreEqual(2, res);
        }

        #region DATA AND REPO
        private Mock<IRepository<Post>> GetPostRepositoryMoq()
        {
            var postRepMoq = new Mock<IRepository<Post>>();
            postRepMoq.Setup(m => m.Get(It.IsAny<int>()))
                .Returns((int id) => GetPosts().SingleOrDefault(p => p.Id == id));
            postRepMoq.Setup(m => m.GetAll()).Returns(GetPosts().AsQueryable());
            postRepMoq.Setup(m => m.Find(It.IsAny<Func<Post, bool>>()))
                .Returns((Func<Post, bool> func) => GetPosts().Where(func).AsQueryable());
            return postRepMoq;
        }

        private Mock<IUnitOfWork> GetUowMoq()
        {
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(m => m.Posts).Returns(GetPostRepositoryMoq().Object);
            return uow;
        }

        private List<Post> GetPosts()
        {
            return new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "What is Lorem Ipsum?",
                    Text = "Lorem Ipsum is simply dummy text of the printing and " +
                    "typesetting industry. Lorem Ipsum has been the industry's standard dummy text " +
                    "ever since the 1500s, when an unknown printer took a galley of type and scrambled " +
                    "it to make a type specimen book. It has survived not only five centuries, but " +
                    "also the leap into electronic typesetting, remaining essentially unchanged. " +
                    "It was popularised in the 1960s with the release of Letraset sheets containing " +
                    "Lorem Ipsum passages, and more recently with desktop publishing software like " +
                    "Aldus PageMaker including versions of Lorem Ipsum.",
                    Date = new DateTime(2021,04,01)
                },
                new Post
                {
                    Id = 2,
                    Title = "Why do we use it?",
                    Text = "It is a long established fact that a reader will be distracted " +
                    "by the readable content of a page when looking at its layout. The point of using " +
                    "Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed " +
                    "to using 'Content here, content here', making it look like readable English. Many " +
                    "desktop publishing packages and web page editors now use Lorem Ipsum as their default " +
                    "model text, and a search for 'lorem ipsum' will uncover many web sites still in their " +
                    "infancy. Various versions have evolved over the years, sometimes by accident, sometimes " +
                    "on purpose (injected humour and the like).",
                    Date = new DateTime(2021,04, 05)
                },
                new Post
                {
                    Id = 3,
                    Title = "Where does it come from?",
                    Text = "Contrary to popular belief, Lorem Ipsum is not simply " +
                    "random text. It has roots in a piece of classical Latin literature from 45 BC, making " +
                    "it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College " +
                    "in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem " +
                    "Ipsum passage, and going through the cites of the word in classical literature, " +
                    "discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 " +
                    "of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written " +
                    "in 45 BC. This book is a treatise on the theory of ethics, very popular during the " +
                    "Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes " +
                    "from a line in section 1.10.32.",
                    Date = new DateTime(2021, 04, 16)
                }
            };
        }
        #endregion DATA AND REPO
    }
}
