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
        readonly FeedBackRepo _feedBackRepo;

        public FeedBackController()
        {
            _feedBackRepo = new FeedBackRepo();
        }

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
