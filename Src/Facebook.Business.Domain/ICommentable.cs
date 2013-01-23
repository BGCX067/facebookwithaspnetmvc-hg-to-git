using System.Collections.Generic;

namespace Facebook.Business.Domain
{
    public interface ICommentable
    {
        IEnumerable<Comment> Comments { get; }

        void AddComment(Comment comment);
    }
}