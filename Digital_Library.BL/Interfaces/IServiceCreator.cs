using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.BL.Interfaces
{
    /// <summary>
    /// Abstract Factory interface for services
    /// </summary>
    public interface IServiceCreator
    {
        /// <summary>
        /// Create post service
        /// </summary>
        /// <returns>post service</returns>
        IPostsService CreatePostService();
        
        /// <summary>
        ///create comment service 
        /// </summary>
        /// <returns>comment service</returns>
        ICommentsSerice CreateCommentService();

        /// <summary>
        /// Create questionnarie service
        /// </summary>
        /// <returns>questionnarie service</returns>
        IQestionnarieService CreatyeQestionnarieService();
    }
}
