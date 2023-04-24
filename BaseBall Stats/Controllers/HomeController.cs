using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseBall_Stats.Models;
using System.Data.SqlClient;

namespace BaseBall_Stats.Controllers
{
    
    public class HomeController : Controller
    {
        private Gabe_DB db = new Gabe_DB();
        public ActionResult Index()
        {
            List<Player> players = GetPlayers();
            return View(players);
        }

        private List<Player> GetPlayers()
        {
            var connection = db.Database.Connection;
            var exist = db.Database.Exists();
            if(exist && connection !=null)
            {
                try
                {
                    List<Player> players = db.Players.ToList();
                    return players;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                throw new Exception("Something went wrong when trying to connect to Database");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}