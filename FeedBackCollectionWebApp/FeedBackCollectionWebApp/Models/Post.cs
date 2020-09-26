using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FeedBackCollectionWebApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public DateTime PostTime { get; set; }
        public User User { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentTime { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
        public IList<Reaction> Reactions { get; set; }
    }

    public class Reaction   
    {
        [Key]
        public int ReactionId { get; set; }
        public bool IsLike { get; set; }
        public Comment Comment { get; set; }
    }
}