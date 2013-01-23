using System.Collections.Generic;

namespace Facebook.Presentation.Web.ViewModels
{
    public class CommentCollectionViewModel
    {
        public int OwnerId { get; set; }

        public IList<CommentViewModel> Comments { get; set; }
    }
}