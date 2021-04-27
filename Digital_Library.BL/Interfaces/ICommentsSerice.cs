using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.BL.DTO;

namespace Digital_Library.BL.Interfaces
{
    public interface ICommentsSerice
    {
        void AddComment(CommetDTO commetDTO);
        void UodateComment(CommetDTO commetDTO);
        CommetDTO GetComment(int id);
        IEnumerable<CommetDTO> GetComments();
        IEnumerable<CommetDTO> GetComments(int pageSize, int page);
        void DeleteComent(int id);
        int PageCount(int pageSize);
    }
}
