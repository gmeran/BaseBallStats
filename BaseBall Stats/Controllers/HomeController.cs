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
        private GabeDB2 db = new GabeDB2();
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

        [HttpGet]
        public ActionResult GetStats(int? playerId)
        {
            var connection = db.Database.Connection;
            var exist = db.Database.Exists();
            if(exist && connection !=null)
            {
                if (GetHittingStats(playerId).Any())
                {
                    try
                    {
                        return RedirectToAction("HittingStats", new { playerId = playerId });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
                else if(GetPitchingStats(playerId).Any())
                {
                    try
                    {
                        return RedirectToAction("PitchingStats", new { playerId = playerId });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
                else
                {
                    throw new Exception("Unable to Return Data");
                }
            }
            else
            {
                throw new Exception("Something went wrong when trying to connect to Database");
            }
        }

        [HttpGet]
        public ActionResult HittingStats(int? playerId)
        {
            var connection = db.Database.Connection;
            var exist = db.Database.Exists();
            if (exist && connection != null)
            {
                try
                {
                    List<Hitting_Stats> playerHittingStats = GetHittingStats(playerId);
                    return View(playerHittingStats);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                throw new Exception("Something went wrong when trying to connect to Database");
            }
        }
        [HttpGet]
        public ActionResult PitchingStats(int? playerId)
        {
            var connection = db.Database.Connection;
            var exist = db.Database.Exists();
            if (exist && connection != null)
            {
                try
                {
                    List<Pitching_Stats> pitchingStats = GetPitchingStats(playerId);
                    return View(pitchingStats);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                throw new Exception("Something went wrong when trying to connect to Database");
            }
        }

        private List<Hitting_Stats>GetHittingStats(int? playerid)
        {
            var hittingStats = db.Hitting_Stats.Where(x => x.PlayerId == playerid);
            return hittingStats.ToList();
        }
        private List<Pitching_Stats>GetPitchingStats(int? playerId)
        {
            var pitchingStats = db.Pitching_Stats.Where(x => x.PlayerId == playerId);
            return pitchingStats.ToList();
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