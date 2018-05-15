using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RizepointBEAssesment.Models;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Reflection;

namespace RizepointTest.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        RizepointBEAssesment.RizepointDBEntities1 _db = new RizepointBEAssesment.RizepointDBEntities1();
        StandardKernel kernel = new StandardKernel();

        [TestMethod]
        public void TestAddUser()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            var serializer = kernel.Get<ISerializer>();
            List<string> interests = new List<string>();
            var serializeHandler = new SerializeHandler(serializer);
            interests.Add("Painting");
            interests.Add("Relaxing");
            interests.Add("Listening to Music");
            User passedUser = new User("paul", "priem", "ppriemo@gmail.com", interests);
            RizepointBEAssesment.User rizeUser = new RizepointBEAssesment.User();
            rizeUser.fname = passedUser.fname;
            rizeUser.lname = passedUser.lname;
            rizeUser.email = passedUser.email;
            rizeUser.interests = serializeHandler.HandleSerialize(passedUser.interests);
            _db.Users.Add(rizeUser);

            RizepointBEAssesment.User addedUser = _db.Users.Local.Where(x => x.fname == "paul").SingleOrDefault();
            User convertedUser = new User(addedUser.fname, addedUser.lname, addedUser.email, serializeHandler.HandleDeserializer(addedUser.interests));
            Assert.IsTrue(passedUser.fname == convertedUser.fname
                && convertedUser.lname == passedUser.lname 
                && passedUser.email == convertedUser.email 
                && passedUser.interests.ElementAt(0) == convertedUser.interests.ElementAt(0)
                && passedUser.interests.ElementAt(1) == convertedUser.interests.ElementAt(1)
                && passedUser.interests.ElementAt(2) == convertedUser.interests.ElementAt(2));
        }

        [TestMethod]
        public void TestFindUsersBylName()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            var serializer = kernel.Get<ISerializer>();
            List<string> interests = new List<string>();
            var serializeHandler = new SerializeHandler(serializer);
            List<string> interests0 = new List<string>();
            interests0.Add("Painting");
            interests0.Add("Relaxing");
            interests0.Add("Listening to Music");
            User User0 = new User("paul", "priem", "ppriemo@gmail.com", interests0);
            RizepointBEAssesment.User rizeUser0 = new RizepointBEAssesment.User();
            rizeUser0.fname = User0.fname;
            rizeUser0.lname = User0.lname;
            rizeUser0.email = User0.email;
            rizeUser0.interests = serializeHandler.HandleSerialize(User0.interests);
            _db.Users.Add(rizeUser0);

            List<string> interests1 = new List<string>();
            interests1.Add("Reading");
            interests1.Add("Driving/Roadtrips");
            interests1.Add("Relaxing");
            User User1 = new User("maura", "priem", "mpriemo@gmail.com", interests1);
            RizepointBEAssesment.User rizeUser1 = new RizepointBEAssesment.User();
            rizeUser1.fname = User1.fname;
            rizeUser1.lname = User1.lname;
            rizeUser1.email = User1.email;
            rizeUser1.interests = serializeHandler.HandleSerialize(User1.interests);
            _db.Users.Add(rizeUser1);

            List<string> interests2 = new List<string>();
            interests2.Add("Watching Movies");
            interests2.Add("Hanging out with friends");
            interests2.Add("Playing Video Games");
            User User2 = new User("paul s.", "priem", "pspriemo@gmail.com", interests2);
            RizepointBEAssesment.User rizeUser2 = new RizepointBEAssesment.User();
            rizeUser2.fname = User2.fname;
            rizeUser2.lname = User2.lname;
            rizeUser2.email = User2.email;
            rizeUser2.interests = serializeHandler.HandleSerialize(User2.interests);
            _db.Users.Add(rizeUser2);

            List<string> interests3 = new List<string>();
            interests3.Add("Sports");
            interests3.Add("Playing Video Games");
            interests3.Add("Hanging out with friends");
            User User3 = new User("thomas", "priem", "tpriemo@gmail.com", interests3);
            RizepointBEAssesment.User rizeUser3 = new RizepointBEAssesment.User();
            rizeUser3.fname = User3.fname;
            rizeUser3.lname = User3.lname;
            rizeUser3.email = User3.email;
            rizeUser3.interests = serializeHandler.HandleSerialize(User3.interests);
            _db.Users.Add(rizeUser3);

            List<string> interests4 = new List<string>();
            interests4.Add("Sleeping");
            interests4.Add("Playing Video Games");
            interests4.Add("Hanging out with friends");
            User User4 = new User("john", "priem", "jpriemo@gmail.com", interests4);
            RizepointBEAssesment.User rizeUser4 = new RizepointBEAssesment.User();
            rizeUser4.fname = User4.fname;
            rizeUser4.lname = User4.lname;
            rizeUser4.email = User4.email;
            rizeUser4.interests = serializeHandler.HandleSerialize(User4.interests);
            _db.Users.Add(rizeUser4);

            List<RizepointBEAssesment.User> foundUsers = _db.Users.Local.Where(x => x.lname == "priem").ToList();
            User convertedUser0 = new User(foundUsers.ElementAt(0).fname, foundUsers.ElementAt(0).lname, foundUsers.ElementAt(0).email, serializeHandler.HandleDeserializer(foundUsers.ElementAt(0).interests));
            User convertedUser1 = new User(foundUsers.ElementAt(1).fname, foundUsers.ElementAt(1).lname, foundUsers.ElementAt(1).email, serializeHandler.HandleDeserializer(foundUsers.ElementAt(1).interests));
            User convertedUser2 = new User(foundUsers.ElementAt(2).fname, foundUsers.ElementAt(2).lname, foundUsers.ElementAt(2).email, serializeHandler.HandleDeserializer(foundUsers.ElementAt(2).interests));
            User convertedUser3 = new User(foundUsers.ElementAt(3).fname, foundUsers.ElementAt(3).lname, foundUsers.ElementAt(3).email, serializeHandler.HandleDeserializer(foundUsers.ElementAt(3).interests));
            User convertedUser4 = new User(foundUsers.ElementAt(4).fname, foundUsers.ElementAt(4).lname, foundUsers.ElementAt(4).email, serializeHandler.HandleDeserializer(foundUsers.ElementAt(4).interests));
            Assert.IsTrue(User0.fname == convertedUser0.fname
                && convertedUser0.lname == User0.lname
                && User0.email == convertedUser0.email
                && User0.interests.ElementAt(0) == convertedUser0.interests.ElementAt(0)
                && User0.interests.ElementAt(1) == convertedUser0.interests.ElementAt(1)
                && User0.interests.ElementAt(2) == convertedUser0.interests.ElementAt(2));
            Assert.IsTrue(User1.fname == convertedUser1.fname
                && convertedUser1.lname == User1.lname
                && User1.email == convertedUser1.email
                && User1.interests.ElementAt(0) == convertedUser1.interests.ElementAt(0)
                && User1.interests.ElementAt(1) == convertedUser1.interests.ElementAt(1)
                && User1.interests.ElementAt(2) == convertedUser1.interests.ElementAt(2));
            Assert.IsTrue(User2.fname == convertedUser2.fname
                && convertedUser2.lname == User2.lname
                && User2.email == convertedUser2.email
                && User2.interests.ElementAt(0) == convertedUser2.interests.ElementAt(0)
                && User2.interests.ElementAt(1) == convertedUser2.interests.ElementAt(1)
                && User2.interests.ElementAt(2) == convertedUser2.interests.ElementAt(2));
            Assert.IsTrue(User3.fname == convertedUser3.fname
                && convertedUser3.lname == User3.lname
                && User3.email == convertedUser3.email
                && User3.interests.ElementAt(0) == convertedUser3.interests.ElementAt(0)
                && User3.interests.ElementAt(1) == convertedUser3.interests.ElementAt(1)
                && User3.interests.ElementAt(2) == convertedUser3.interests.ElementAt(2));
            Assert.IsTrue(User4.fname == convertedUser4.fname
                && convertedUser4.lname == User4.lname
                && User4.email == convertedUser4.email
                && User4.interests.ElementAt(0) == convertedUser4.interests.ElementAt(0)
                && User4.interests.ElementAt(1) == convertedUser4.interests.ElementAt(1)
                && User4.interests.ElementAt(2) == convertedUser4.interests.ElementAt(2));
        }

        [TestMethod]
        public void TestFindUsersByfName()
        {
            kernel.Load(Assembly.GetExecutingAssembly());
            var serializer = kernel.Get<ISerializer>();
            List<string> interests = new List<string>();
            var serializeHandler = new SerializeHandler(serializer);
            List<string> interests0 = new List<string>();
            interests0.Add("Painting");
            interests0.Add("Relaxing");
            interests0.Add("Listening to Music");
            User User0 = new User("paul", "priem", "ppriemo@gmail.com", interests0);
            RizepointBEAssesment.User rizeUser0 = new RizepointBEAssesment.User();
            rizeUser0.fname = User0.fname;
            rizeUser0.lname = User0.lname;
            rizeUser0.email = User0.email;
            rizeUser0.interests = serializeHandler.HandleSerialize(User0.interests);
            _db.Users.Add(rizeUser0);

            List<string> interests1 = new List<string>();
            interests1.Add("Reading");
            interests1.Add("Driving/Roadtrips");
            interests1.Add("Relaxing");
            User User1 = new User("maura", "priem", "mpriemo@gmail.com", interests1);
            RizepointBEAssesment.User rizeUser1 = new RizepointBEAssesment.User();
            rizeUser1.fname = User1.fname;
            rizeUser1.lname = User1.lname;
            rizeUser1.email = User1.email;
            rizeUser1.interests = serializeHandler.HandleSerialize(User1.interests);
            _db.Users.Add(rizeUser1);

            List<string> interests2 = new List<string>();
            interests2.Add("Watching Movies");
            interests2.Add("Hanging out with friends");
            interests2.Add("Playing Video Games");
            User User2 = new User("paul s.", "priem", "pspriemo@gmail.com", interests2);
            RizepointBEAssesment.User rizeUser2 = new RizepointBEAssesment.User();
            rizeUser2.fname = User2.fname;
            rizeUser2.lname = User2.lname;
            rizeUser2.email = User2.email;
            rizeUser2.interests = serializeHandler.HandleSerialize(User2.interests);
            _db.Users.Add(rizeUser2);

            List<string> interests3 = new List<string>();
            interests3.Add("Sports");
            interests3.Add("Playing Video Games");
            interests3.Add("Hanging out with friends");
            User User3 = new User("thomas", "priem", "tpriemo@gmail.com", interests3);
            RizepointBEAssesment.User rizeUser3 = new RizepointBEAssesment.User();
            rizeUser3.fname = User3.fname;
            rizeUser3.lname = User3.lname;
            rizeUser3.email = User3.email;
            rizeUser3.interests = serializeHandler.HandleSerialize(User3.interests);
            _db.Users.Add(rizeUser3);

            List<string> interests4 = new List<string>();
            interests4.Add("Sleeping");
            interests4.Add("Playing Video Games");
            interests4.Add("Hanging out with friends");
            User User = new User("john", "priem", "jpriemo@gmail.com", interests4);
            RizepointBEAssesment.User rizeUser4 = new RizepointBEAssesment.User();
            rizeUser4.fname = User.fname;
            rizeUser4.lname = User.lname;
            rizeUser4.email = User.email;
            rizeUser4.interests = serializeHandler.HandleSerialize(User.interests);
            _db.Users.Add(rizeUser4);

            RizepointBEAssesment.User foundUser = _db.Users.Local.Where(x => x.fname == "john").First();
            User convertedUser = new User(foundUser.fname, foundUser.lname, foundUser.email, serializeHandler.HandleDeserializer(foundUser.interests));
            Assert.IsTrue(User.fname == convertedUser.fname
                && convertedUser.lname == User.lname
                && User.email == convertedUser.email
                && User.interests.ElementAt(0) == convertedUser.interests.ElementAt(0)
                && User.interests.ElementAt(1) == convertedUser.interests.ElementAt(1)
                && User.interests.ElementAt(2) == convertedUser.interests.ElementAt(2));
        }
    }
}



