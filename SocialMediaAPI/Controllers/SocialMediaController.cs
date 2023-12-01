using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.Models;
using SocialMediaAPI.Data;
using SocialMediaAPI.Controllers;
using System.Security.Principal;


namespace SocialMediaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly APIPostContext _contextPost;
        public bool IsLoggedIn { get; set; }
        public SocialMediaController(APIContext context, APIPostContext contextPost)
        {
            _context = context;
            _contextPost = contextPost;


        }
        
        //                                   LOG IN 
        //Create
        [HttpPost]
        public JsonResult CreateEdit(UserAccount account, bool signup)
        {
            if (signup == true)
            {
                var accountInDb = _context.MyAccount.FirstOrDefault(x => x.Username == account.Username);
                if (accountInDb == null)
                {
                    //int tempId= (_context.MyAccount.OrderByDescending(i => i.Id).FirstOrDefault().Id);
                    //if(tempId == 0)
                    //{
                    //    tempId = 1;
                    //}
                    //else
                    //{
                    //    tempId++;
                    //}
                    //account.Id = tempId;
                    _context.MyAccount.Add(account); //!!?
                    _context.SaveChanges();
                    return new JsonResult(Ok(account));
                }
                else
                {
                    return new JsonResult(NotFound()+": Sign Up Error");
                }
            }
            else
            {
                var accountInDb = _context.MyAccount.FirstOrDefault(x => x.Username == account.Username);
                if (accountInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                else if (accountInDb.Password == account.Password)
                {
                    IsLoggedIn = true;
                    
                }
                else
                {
                    return new JsonResult("Password incorrect");
                }
            }
            _context.SaveChanges();

            return new JsonResult(Ok(account));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(string username, string passwrd)
        {

                var accountInDb = _context.MyAccount.Find(username);
                
                if (accountInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                else if (accountInDb.Password == passwrd)
                {
                _context.MyAccount.Remove(accountInDb);

                }
                else
                {
                    return new JsonResult("Password incorrect");
                }
            
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.MyAccount.ToList();
            return new JsonResult(Ok(result));
            
        }



        ////                                                                 POST
        [Route("Post")]
        ////Create

        [HttpPost]
        public JsonResult CretePost(UserPost post)
        {
            _contextPost.UsersPosts.Add(post); //!!?
            _contextPost.SaveChanges();
            return new JsonResult(Ok(post));
        }
        ////Get all
        //[HttpGet("/GetAll")]
        //public JsonResult GetAllPosts()
        //{
        //    var result = _contextPost.UsersPosts.ToList();
        //    return new JsonResult(Ok(result));

        //}
    }
}
