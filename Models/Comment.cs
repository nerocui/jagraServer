using System.Collections.Generic;

namespace server.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string content { get; set; }
        public ICollection<CommentReply> Replies { get; set; }
        public CommentReply ReplyTo { get; set; }
    }
}