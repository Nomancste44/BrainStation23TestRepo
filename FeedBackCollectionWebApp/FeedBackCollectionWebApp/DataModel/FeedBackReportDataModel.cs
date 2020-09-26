using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedBackCollectionWebApp.Models;

namespace FeedBackCollectionWebApp.DataModel
{
    public class FeedBackReportDataModel
    {
        public FeedBackReportDataModel()
        {
            Comments = new List<CommentDataModel>();
        }
        public PostDataModel Post { get; set; }
        public List<CommentDataModel> Comments { get; set; }
    }
    public class PostDataModel
    {
      public int PostId { get; set; }
        public string PostContent { get; set; }
        public DateTime PostTime { get; set; }
        public string UserName { get; set; }
        public string CommentCount { get; set; }
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