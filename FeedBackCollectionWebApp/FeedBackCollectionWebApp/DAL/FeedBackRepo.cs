using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedBackCollectionWebApp.DataModel;
using FeedBackCollectionWebApp.DbContexts;
using FeedBackCollectionWebApp.Models;
using WebGrease.Css.Extensions;

namespace FeedBackCollectionWebApp.DAL
{
    public class FeedBackRepo
    {
        readonly FeedBackDbContext _feedBackDbContext;
        public FeedBackRepo(FeedBackDbContext feedBackDbContext)
        {
            _feedBackDbContext = feedBackDbContext;
        }
        //public IEnumerable<FeedBackReportDataModel> GetAllFeedBacks()
        public IEnumerable<CommentDataModel> GetAllFeedBacks()
        {
            var result = (from user in _feedBackDbContext.Users
                join post in _feedBackDbContext.Posts on user.UserId equals post.User.UserId
                join comment in _feedBackDbContext.Comments on post.PostId equals comment.Post.PostId
                join reaction in _feedBackDbContext.Reactions on comment.CommentId equals reaction.Comment.CommentId
                select new
                {
                    post.PostId,
                    comment.User.UserName,
                    post.PostTime,
                    comment.CommentTime,
                    comment.CommentContent,
                    Like = reaction.IsLike ? 1 : 0,
                    DisLike = reaction.IsLike ? 0 : 1
                })
                .GroupBy(x => new
                {
                    x.PostId,
                    x.UserName,
                    x.CommentTime,
                    x.CommentContent
                }).Select(x => new CommentDataModel
                {
                   PostId= x.Key.PostId,
                    CommentContent =x.Key.CommentContent,
                    UserName =x.Key.UserName,
                    CommentTime = x.Key.CommentTime,
                    LikeCount = x.Sum(y => y.Like),
                    DisLikeCount = x.Sum(y => y.DisLike)
                }).ToList();

            //var goupedJoinedData = _feedBackDbContext.Posts.GroupJoin(result,
            //    p => p.PostId,
            //    c => c.PostId,
            //    (p, c) => new FeedBackReportDataModel
            //    {
            //        Post = p,
            //        Comments = c
            //    });

            //return goupedJoinedData;

            return result;

        }

        public object GetAllFeedBackByPostId(int postId)
        {
            return null;
        }
    }
}