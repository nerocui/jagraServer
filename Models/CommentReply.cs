namespace server.Models
{
    public class CommentReply
    {
        public Comment Reply { get; set; }
        public int ReplyId { get; set; }
        public Comment ReplyTo { get; set; }
        public int ReplyToId { get; set; }
    }
}