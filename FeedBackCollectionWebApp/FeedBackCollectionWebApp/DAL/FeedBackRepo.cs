using System;
using System.Collections;
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
         FeedBackDbContext _feedBackDbContext;

        private FeedBackDbContext FeedBackDbContext
            => _feedBackDbContext ?? (_feedBackDbContext = new FeedBackDbContext());

        public IEnumerable<FeedBackReportDataModel> GetAllFeedBacks()
        {
            var result = (from user in FeedBackDbContext.Users
                          join post in FeedBackDbContext.Posts on user.UserId equals post.User.UserId
                          join comment in FeedBackDbContext.Comments on post.PostId equals comment.Post.PostId
                          join reaction in FeedBackDbContext.Reactions on comment.CommentId equals reaction.Comment.CommentId
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
                    PostId = x.Key.PostId,
                    CommentContent = x.Key.CommentContent,
                    UserName = x.Key.UserName,
                    CommentTime = x.Key.CommentTime,
                    LikeCount = x.Sum(y => y.Like),
                    DisLikeCount = x.Sum(y => y.DisLike)
                }).ToList();

            var postsResult = FeedBackDbContext.Posts.GroupJoin(FeedBackDbContext.Comments,
                p => p.PostId,
                c => c.Post.PostId,
                (p, c) => new PostDataModel
                {
                    PostId = p.PostId,
                    PostTime = p.PostTime,
                    UserName = p.User.UserName,
                    CommentCount = c.Count() + "Comments"
                }).ToList();

            var groupedResult = postsResult
                .GroupJoin(result,
                p => p.PostId,
                r => r.PostId,
                (p, r) => new FeedBackReportDataModel
                {
                    Post = p,
                    Comments = r.ToList()
                }).ToList();

            return groupedResult;
        }
        public object GetAllFeedBackByPostId(int postId)
        {
            return null;
        }
    }
}