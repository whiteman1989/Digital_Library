using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.BL.DTO;

namespace Digital_Library.BL.Interfaces
{
    public interface IPostsService
    {
        void AddPost(PostDTO postDTO);
        void EditPost(PostDTO postDTO);
        PostDTO GetPost(int id);
        IEnumerable<PostDTO> GetPosts();
        IEnumerable<PostDTO> GetPosts(int pageSize, int page);
        void DeletePost(int id);
        int PageCount(int pageSize);
    }
}
