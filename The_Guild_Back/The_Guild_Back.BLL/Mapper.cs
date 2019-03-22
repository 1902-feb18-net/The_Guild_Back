using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Guild_Back.BLL
{
    public static class Mapper
    {
        static ILogger logger = LogManager.GetCurrentClassLogger();

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
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null name to AdventurerParty");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace name to AdventurerParty");
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
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null username to LoginInfo");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace username to LoginInfo");
                throw;
            }

            try
            {
                login.Pass = info.Pass;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null password to LoginInfo");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace password to LoginInfo");
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
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null name to Progress");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace name to Progress");
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
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Number of Requests to Rank Requirements");
                throw;
            }

            try
            {
                rankRequirements.MinTotalStats = requirements.MinTotalStats;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Minimum Stats to Rank Requirements");
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
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null name to Rank");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace name to Rank");
                throw;
            }

            try
            {
                rank.Fee = ranks.Fee;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Fee to Rank");
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
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Cost to Request");
                throw;
            }

            try
            {
                req.Reward = request.Reward;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Reward to Request");
                throw;
            }

            try
            {
                req.Descript = request.Descript;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null Description to Request");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace Description to Request");
                throw;
            }

            try
            {
                req.Requirements = request.Requirements;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null Requirements to Request");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace Requirements to Request");
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
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null First Name to User");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace First Name to User");
                throw;
            }

            try
            {
                use.LastName = user.LastName;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e, "Mapping null Last Name to User");
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e, "Mapping empty or whitespace Last Name to User");
                throw;
            }

            try
            {
                use.Strength = user.Strength;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Strength to User");
                throw;
            }

            try
            {
                use.Dex = user.Dex;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Dex to User");
                throw;
            }

            try
            {
                use.Intelligence = user.Intelligence;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Intelligence to User");
                throw;
            }

            try
            {
                use.Wisdom = user.Wisdom;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Wisdom to User");
                throw;
            }

            try
            {
                use.Charisma = user.Charisma;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Charisma to User");
                throw;
            }

            try
            {
                use.Constitution = user.Constitution;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Constitution to User");
                throw;
            }

            try
            {
                use.Salary = user.Salary;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e, "Mapping negative Salary to User");
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

        public static IEnumerable<AdventureParty> Map(IEnumerable<DAL.AdventurerParty> parties) => parties.Select(x => Map(x));
        public static IEnumerable<DAL.AdventurerParty> Map(IEnumerable<AdventureParty> parties) => parties.Select(x => Map(x));

        public static IEnumerable<LoginInfo> Map(IEnumerable<DAL.LoginInfo> logins) => logins.Select(x => Map(x));
        public static IEnumerable<DAL.LoginInfo> Map(IEnumerable<LoginInfo> logins) => logins.Select(x => Map(x));

        public static IEnumerable<Progress> Map(IEnumerable<DAL.Progress> progresses) => progresses.Select(x => Map(x));
        public static IEnumerable<DAL.Progress> Map(IEnumerable<Progress> progresses) => progresses.Select(x => Map(x));

        public static IEnumerable<RankRequirements> Map(IEnumerable<DAL.RankRequirements> requirements) => requirements.Select(x => Map(x));
        public static IEnumerable<DAL.RankRequirements> Map(IEnumerable<RankRequirements> requirements) => requirements.Select(x => Map(x));

        public static IEnumerable<Ranks> Map(IEnumerable<DAL.Ranks> ranks) => ranks.Select(x => Map(x));
        public static IEnumerable<DAL.Ranks> Map(IEnumerable<Ranks> ranks) => ranks.Select(x => Map(x));

        public static IEnumerable<Request> Map(IEnumerable<DAL.Request> requests) => requests.Select(x => Map(x));
        public static IEnumerable<DAL.Request> Map(IEnumerable<Request> requests) => requests.Select(x => Map(x));

        public static IEnumerable<RequestingParty> Map(IEnumerable<DAL.RequestingParty> requesters) => requesters.Select(x => Map(x));
        public static IEnumerable<DAL.RequestingParty> Map(IEnumerable<RequestingParty> requesters) => requesters.Select(x => Map(x));

        public static IEnumerable<Users> Map(IEnumerable<DAL.Users> users) => users.Select(x => Map(x));
        public static IEnumerable<DAL.Users> Map(IEnumerable<Users> users) => users.Select(x => Map(x));

    }
}
