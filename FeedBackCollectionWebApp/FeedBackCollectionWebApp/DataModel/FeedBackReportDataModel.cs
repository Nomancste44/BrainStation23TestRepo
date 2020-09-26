using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedBackCollectionWebApp.Models;

namespace FeedBackCollectionWebApp.DataModel
{
    public class FeedBackReportDataModel
    {
        public Post Post { get; set; }
        public IEnumerable<CommentDataModel> Comments { get; set; }
    }

    public class CommentDataModel   
    {
        public int PostId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentTime { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
    }
}