using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.BL.DTO;

namespace Digital_Library.BL.Interfaces
{
    /// <summary>
    /// Posts service interface
    /// </summary>
    public interface IPostsService
    {
        /// <summary>
        /// Add new post
        /// </summary>
        /// <param name="postDTO">post object</param>
        void AddPost(PostDTO postDTO);

        /// <summary>
        /// Update post in repository
        /// </summary>
        /// <param name="postDTO">post object</param>
        void EditPost(PostDTO postDTO);

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id">post id</param>
        /// <returns>post DTO object</returns>
        PostDTO GetPost(int id);

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns>collection of posts DTO objects</returns>
        IEnumerable<PostDTO> GetPosts();

        /// <summary>
        /// Gett some of the comments to be posted on the page
        /// </summary>
        /// <param name="pageSize">number of posts per page</param>
        /// <param name="page">Page number</param>
        /// <returns>posts collection</returns>
        IEnumerable<PostDTO> GetPosts(int pageSize, int page);

        /// <summary>
        /// Delete post by id
        /// </summary>
        /// <param name="id">post id</param>
        void DeletePost(int id);

        /// <summary>
        /// Number of pages
        /// </summary>
        /// <param name="pageSize">number of posts per page</param>
        /// <returns>number of pages</returns>
        int PageCount(int pageSize);
    }
}
