using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FeedBackCollectionWebApp.DAL;
using FeedBackCollectionWebApp.DbContexts;

namespace FeedBackCollectionWebApp.Controllers
{
    public class FeedBackController : ApiController
    {
        FeedBackRepo _feedBackRepo = new FeedBackRepo(new FeedBackDbContext());

        [HttpGet]
        public IHttpActionResult GetAllFeedBacks()
        {
            return Ok(_feedBackRepo.GetAllFeedBacks());
        }

        [HttpGet]
        public IHttpActionResult GetAllFeedBacks(int postId)
        {
            return Ok(_feedBackRepo.GetAllFeedBackByPostId(postId));
        }
    }
}
