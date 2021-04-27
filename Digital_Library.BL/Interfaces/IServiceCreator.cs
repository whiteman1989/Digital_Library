using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.BL.Interfaces
{
    public interface IServiceCreator
    {
        IPostsService CreatePostService();
        ICommentsSerice CreateCommentService();
    }
}
