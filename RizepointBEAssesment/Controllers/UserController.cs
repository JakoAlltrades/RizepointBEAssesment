using Ninject;
using RizepointBEAssesment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace RizepointBEAssesment.Controllers
{
    public class UserController : ApiController

    {
        RizepointDBEntities1 _db;
        StandardKernel kernel;
        ISerializer serializer;
        SerializeHandler serializeHandler;

        public UserController()
        {
            _db = new RizepointDBEntities1();
            kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            serializer = kernel.Get<ISerializer>();
            serializeHandler = new SerializeHandler(serializer);
        }

        [ActionName("Add")]
        [HttpPost]
        public HttpResponseMessage AddUser(Models.User user)
        {
            //add user to sql database
            RizepointBEAssesment.User rizeUser = new RizepointBEAssesment.User();

            rizeUser.fname = user.fname;
            rizeUser.lname = user.lname;
            rizeUser.email = user.email;
            rizeUser.interests = serializeHandler.HandleSerialize(user.interests);

            _db.Users.Add(rizeUser);

            _db.SaveChanges();
            return Request.CreateResponse(System.Net.HttpStatusCode.Accepted, "Successfully Added User");

        }

        [ActionName("Search?{name}")]
        [HttpGet]
        public HttpResponseMessage FindUserByName(string name)
        {
            List<RizepointBEAssesment.User> Users = _db.Users.ToList<RizepointBEAssesment.User>();
            List<RizepointBEAssesment.User> matchedUsers = Users.Where(x => x.fname == name).Select(x => x).ToList();
            matchedUsers.AddRange(Users.Where(x => x.lname == name).Select(x => x).ToList());
            List<Models.User> convertedUsers = new List<Models.User>();
            foreach(User u in matchedUsers)
            {
                convertedUsers.Add(new Models.User(u.fname, u.lname, u.email, serializeHandler.HandleDeserializer(u.interests)));
            }
            //might need to convert list to JSon
            return Request.CreateResponse(System.Net.HttpStatusCode.Accepted, convertedUsers);
        }
    }
}