using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class UsersController : Controller
    {
        private UserContext db = new UserContext();
        // GET: Users
       
        public ActionResult Register() 
        {
            return View();  
        }
        public ActionResult Index()
        {
            Session["loginSession"] = null;
            return View();
        }



        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            User l = new User();
            l.EmailID = fc["username"];
            l.Password = fc["password"];

            if (Session["loginSession"] == null)
            {
                Session["loginSession"] = l.EmailID;
            }



            SqlConnection con = null;
            SqlDataReader dr = null;
            try
            {
                string connectionString = GetConnectionString();



                con = new SqlConnection(connectionString);

                con.Open();
                string str = $"select * from User where EmailID = " + $" '{l.EmailID}' and Password = '{l.Password}'";
                SqlCommand cmd = new SqlCommand(str, con);



                dr = cmd.ExecuteReader();



                if (ModelState.IsValid)
                {
                    if (dr.HasRows)
                    {
                        TempData["message"] = "Login Successful";
                        TempData.Keep("message");
                        return RedirectToAction("LoggedIn", l);
                    }
                    else
                    {
                        ViewBag.attempt = "Login Failed. Please try again or if you are new then please Register";
                    }
                }



            }
            finally
            {
                // close reader
                if (dr != null)
                {
                    dr.Close();
                }
                // close connection
                if (con != null)
                {
                    con.Close();
                }
            }



            return View();
        }
        protected string GetConnectionString()
        {
            var datasource = @"Saloni";//your server
            var database = "OnlineBanking"; //your database name
            var username = "Saloni/SaloniShahi"; //username of server to connect
            var password = true; //password
                                        //your connection string
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;



            return connString;
        }





        [HttpPost]
        public ActionResult Register(User usr)
        {
            if(ModelState.IsValid)
            {
              db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured!");

            }
            return View(usr);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User users)
        {
         if (ModelState.IsValid)
            {
                using(UserContext db = new UserContext())
                {
                    var obj = db.Users.Where(u=>u.EmailID.Equals(users.EmailID)&& u.Password.Equals(users.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["RegistrationId"] = obj.RegistrationId.ToString();
                        Session["EmailID"] = obj.EmailID.ToString();

                        return RedirectToAction("About");
                    }
                }
            }
         return View(users);
        }
        
        public ActionResult LoggedIn()
        {
            if (Session["RegestrationId"]!= null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }

    }
}