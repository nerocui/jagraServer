using System.Threading.Tasks;
using server.Models;
using Task = server.Models.Task;

namespace server.data
{
    public interface ICommentRepository
    {
         Task<Comment> Add(Comment comment, Task task);
         Task<Comment> Delete(Comment comment);
         Task<Comment> Reply(Comment comment, Comment replyto, Task task);
         Task<Comment> Modify(Comment comment);
    }
}
