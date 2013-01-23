using System.Collections;
using System.Collections.Generic;

namespace Facebook.Presentation.Web.ViewModels.Posts
{
    public class PostCollectionViewModel 
    {
        public int OwnerId { get; set; }

        public int Page { get; set; }

        public int Count { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}