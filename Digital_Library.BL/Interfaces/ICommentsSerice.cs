using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.BL.DTO;

namespace Digital_Library.BL.Interfaces
{
    /// <summary>
    /// Comments service interface
    /// </summary>
    public interface ICommentsSerice
    {
        /// <summary>
        /// Add new comment
        /// </summary>
        /// <param name="commetDTO">comment DTO object</param>
        void AddComment(CommetDTO commetDTO);

        /// <summary>
        /// Uodate comment in repository
        /// </summary>
        /// <param name="commetDTO">comment DTO object</param>
        void UodateComment(CommetDTO commetDTO);

        /// <summary>
        /// Get comment by id
        /// </summary>
        /// <param name="id">comment id</param>
        /// <returns>comment</returns>
        CommetDTO GetComment(int id);

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns>comments collection</returns>
        IEnumerable<CommetDTO> GetComments();

        /// <summary>
        /// Gett some of the comments to be posted on the page
        /// </summary>
        /// <param name="pageSize">number of comments per page</param>
        /// <param name="page">Page number</param>
        /// <returns>comments collection</returns>
        IEnumerable<CommetDTO> GetComments(int pageSize, int page);

        /// <summary>
        /// Delate comment by id
        /// </summary>
        /// <param name="id">comment id</param>
        void DeleteComent(int id);

        /// <summary>
        /// Number of pages
        /// </summary>
        /// <param name="pageSize">number of comments per page</param>
        /// <returns>number of pages</returns>
        int PageCount(int pageSize);
    }
}
