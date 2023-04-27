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

        [HttpGet]
        public ActionResult CreatePlayer()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreatePostionPlayer()
        {
            return View();
        }
        [HttpPost]
        [HandleError]
        public ActionResult CreatePostionPlayer(CreatePositionPlayerModel model)
        {
            var connection = db.Database.Connection;
            var exist = db.Database.Exists();
            if (exist && connection != null)
            {
                try
                {
                    Player player = new Player();
                    player.PlayerId = model.PlayerId;
                    player.FirstName = model.FirstName;
                    player.LastName = model.LastName;
                    player.Postion = model.Postion;
                    player.YearStarted = model.YearStarted;
                    player.YearEnded = model.YearEnded;

                    db.Players.Add(player);
                    db.SaveChanges();
                    ModelState.Clear();
                    return Redirect("CreateHittingStats");

                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                throw new Exception("Please Check if database is running properly ");
            }
        }

        [HttpGet]
        public ActionResult CreatePitchingPlayer()
        {
            return View();
        }
        [HttpPost]
        [HandleError]
        public ActionResult CreatePitchingPlayer(CreatePitcherPlayerModel model)
        {
            var connection = db.Database.Connection;
            var exist = db.Database.Exists();
            if (exist && connection != null)
            {
                try
                {
                    Player player = new Player();
                    player.PlayerId = model.PlayerId;
                    player.FirstName = model.FirstName;
                    player.LastName = model.LastName;
                    player.Postion = model.Postion;
                    player.YearStarted = model.YearStarted;
                    player.YearEnded = model.YearEnded;

                    db.Players.Add(player);
                    db.SaveChanges();
                    return Redirect("CreatePitchingStats");

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                throw new Exception("Please Check if database is running properly ");
            }
        }

        [HttpGet]
        public ActionResult CreateHittingStats()
        {
            return View();
        }
        [HttpPost]
        [HandleError]
        public ActionResult CreateHittingStats(CreateHittingStatsModel model)
        {
            var connection = db.Database.Connection;
            var exist = db.Database.Exists();
            if (exist && connection != null)
            {
                try 
                {
                    Hitting_Stats stats = new Hitting_Stats();
                    stats.StatYear = model.StatYear;
                    stats.GamesPlayed = model.GamesPlayed;
                    stats.AB = model.AB;
                    stats.PA = model.PA;
                    stats.Hits = model.Hits;
                    stats.DB = model.DB;
                    stats.TRP = model.TRP;
                    stats.HR = model.HR;
                    stats.RBI = model.RBI;
                    stats.R = model.R;
                    stats.SB = model.SB;
                    stats.CS = model.CS;
                    stats.SO = model.SO;
                    stats.BB = model.BB;
                    stats.BA = model.BA;
                    stats.OPB = model.OPB;
                    stats.SLG = model.SLG;
                    stats.OPS = model.OPS;
                    stats.PlayerId = model.PlayerId;

                    db.Hitting_Stats.Add(stats);
                    db.SaveChanges();
                    return Redirect("Index");

                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                throw new Exception("Please Check if database is running properly ");
            }
        }

        [HttpGet]
        public ActionResult CreatePitchingStats()
        {
            return View();
        }
        [HttpPost]
        [HandleError]
        public ActionResult CreatePitchingStats(CreatePitchingStatsModel model)
        {
            var connection = db.Database.Connection;
            var exist = db.Database.Exists();
            if (exist && connection != null)
            {
                try
                {
                    Pitching_Stats stats = new Pitching_Stats();
                    stats.statYear = model.statYear;
                    stats.G = model.G;
                    stats.W = model.W;
                    stats.L = stats.L;
                    stats.WLPECT = model.WLPECT;
                    stats.ERA = model.ERA;
                    stats.WHIP = model.WHIP;
                    stats.InningsPitched = model.InningsPitched;
                    stats.GS = model.GS;
                    stats.CG = model.CG;
                    stats.SV = model.SV;
                    stats.SHO = model.SHO;
                    stats.H = model.H;
                    stats.HR = model.HR;
                    stats.SO = model.SO;
                    stats.BB = model.BB;
                    stats.IBB = model.IBB;
                    stats.HBP = model.HBP;
                    stats.R = model.R;
                    stats.ER = model.ER;
                    stats.PlayerId = model.PlayerId;

                    db.Pitching_Stats.Add(stats);
                    db.SaveChanges();
                    return Redirect("Index");
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                throw new Exception("Please Check if database is running properly ");
            }
        }

        [HttpGet]
        public ActionResult AddStats(int? playerId)
        {
            var hitQuery = db.Hitting_Stats.Where(a => a.PlayerId == playerId);
            var pitchQuery = db.Pitching_Stats.Where(a => a.PlayerId == playerId);

            if(hitQuery.Any())
            {
                return RedirectToAction("CreateHittingStats");
            }
            else if(pitchQuery.Any())
            {
                return RedirectToAction("CreatePitchingStats");
            }
            else
            {
                throw new Exception("Unable to Add new Stat");
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