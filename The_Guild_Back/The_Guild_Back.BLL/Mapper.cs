using System;
using System.Collections.Generic;
using System.Text;

namespace The_Guild_Back.BLL
{
    public static class Mapper
    {
        public static AdventureParty Map(DAL.AdventurerParty party)
        {
            AdventureParty adventureParty = new AdventureParty
            {
                Id = party.Id,
                AdventurerId = party.AdventurerId,
                RequestId = party.RequestId
            };
            try
            {
                adventureParty.Nam = party.Nam;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }
            return adventureParty;
        }

        public static DAL.AdventurerParty Map(AdventureParty party)
        {
            DAL.AdventurerParty adventurerParty = new DAL.AdventurerParty
            {
                Id = party.Id,
                AdventurerId = party.AdventurerId,
                RequestId = party.RequestId,
                Nam = party.Nam
            };

            return adventurerParty;
        }

        public static LoginInfo Map(DAL.LoginInfo info)
        {
            LoginInfo login = new LoginInfo
            {
                Id = info.Id,
            };
            try
            {
                login.Username = info.Username;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }

            try
            {
                login.Pass = info.Pass;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }
            return login;
        }

        public static DAL.LoginInfo Map(LoginInfo info)
        {
            DAL.LoginInfo login = new DAL.LoginInfo
            {
                Id = info.Id,
                Username = info.Username,
                Pass = info.Pass
            };
            return login;
        }


        public static Progress Map(DAL.Progress progress)
        {
            Progress prog = new Progress
            {
                Id = progress.Id
            };
            try
            {
                prog.Nam = progress.Nam;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }
            return prog;
        }

        public static DAL.Progress Map(Progress progress)
        {
            DAL.Progress prog = new DAL.Progress
            {
                Id = progress.Id,
                Nam = progress.Nam
            };
            return prog;
        }

        public static RankRequirements Map(DAL.RankRequirements requirements)
        {
            RankRequirements rankRequirements = new RankRequirements()
            {
                Id = requirements.Id,
                CurrentRankId = requirements.CurrentRankId,
                NextRankId = requirements.NextRankId
            };
            try
            {
                rankRequirements.NumberRequests = requirements.NumberRequests;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                rankRequirements.MinTotalStats = requirements.MinTotalStats;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }
            return rankRequirements;
        }

        public static DAL.RankRequirements Map(RankRequirements requirements)
        {
            DAL.RankRequirements rankRequirements = new DAL.RankRequirements()
            {
                Id = requirements.Id,
                CurrentRankId = requirements.CurrentRankId,
                NextRankId = requirements.NextRankId,
                NumberRequests = requirements.NumberRequests,
                MinTotalStats = requirements.MinTotalStats
            };
            return rankRequirements;
        }

        public static Ranks Map(DAL.Ranks ranks)
        {
            Ranks rank = new Ranks
            {
                Id = ranks.Id,
            };
            try
            {
                rank.Nam = ranks.Nam;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }

            try
            {
                rank.Fee = ranks.Fee;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }
            return rank;
        }

        public static DAL.Ranks Map(Ranks ranks)
        {
            DAL.Ranks rank = new DAL.Ranks
            {
                Id = ranks.Id,
                Nam = ranks.Nam,
                Fee = ranks.Fee
            };
            return rank;
        }

        public static Request Map(DAL.Request request)
        {
            Request req = new Request
            {
                Id = request.Id,
                RankId = request.RankId,
                ProgressId = request.ProgressId
            };
            try
            {
                req.Cost = request.Cost;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                req.Reward = request.Reward;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                req.Descript = request.Descript;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }

            try
            {
                req.Requirements = request.Requirements;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }
            return req;
        }

        public static DAL.Request Map(Request request)
        {
            DAL.Request req = new DAL.Request
            {
                Id = request.Id,
                RankId = request.RankId,
                ProgressId = request.ProgressId,
                Cost = request.Cost,
                Reward = request.Reward,
                Descript = request.Descript,
                Requirements = request.Requirements
            };
            return req;
        }

        public static RequestingParty Map(DAL.RequestingParty requesters)
        {
            RequestingParty party = new RequestingParty
            {
                Id = requesters.Id,
                CustomerId = requesters.CustomerId,
                RequestId = requesters.RequestId
            };
            return party;
        }

        public static DAL.RequestingParty Map(RequestingParty requesters)
        {
            DAL.RequestingParty party = new DAL.RequestingParty
            {
                Id = requesters.Id,
                CustomerId = requesters.CustomerId,
                RequestId = requesters.RequestId
            };
            return party;
        }

        public static Users Map(DAL.Users user)
        {
            Users use = new Users
            {
                Id = user.Id,
                LoginInfoId = user.Id,
                RankId = user.RankId,              
            };
            try
            {
                use.FirstName = user.FirstName;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }

            try
            {
                use.LastName = user.LastName;
            }
            catch (ArgumentNullException)
            {
                //log
                throw;
            }
            catch (ArgumentException)
            {
                //log
                throw;
            }

            try
            {
                use.Strength = user.Strength;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                use.Dex = user.Dex;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                use.Intelligence = user.Intelligence;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                use.Wisdom = user.Wisdom;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                use.Charisma = user.Charisma;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                use.Constitution = user.Constitution;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }

            try
            {
                use.Salary = user.Salary;
            }
            catch (ArgumentOutOfRangeException)
            {
                //log
                throw;
            }
            return use;
        }

        public static DAL.Users Map(Users user)
        {
            DAL.Users use = new DAL.Users
            {
                Id = user.Id,
                LoginInfoId = user.Id,
                RankId = user.RankId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Strength = user.Strength,
                Dex = user.Dex,
                Intelligence = user.Intelligence,
                Wisdom = user.Wisdom,
                Charisma = user.Charisma,
                Constitution = user.Constitution,
                Salary = user.Salary
            };
            return use;
        }
    }
}
