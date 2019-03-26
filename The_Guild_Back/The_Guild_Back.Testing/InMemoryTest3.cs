using System;
using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using The_Guild_Back.BLL;
using The_Guild_Back.DAL;
using System.Threading.Tasks;

namespace The_Guild_Back.Testing
{
    public class InMemoryTest3
    {
        [Fact]
        public async Task DeleteAsync_AdventurerParty_removes_from_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<project2theGuildContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new project2theGuildContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new project2theGuildContext(options))
                {
                    //create new Repo
                    var testRepo = new Repository(context);

                    //dependencies
                    var adventurer  = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast"
                    };
                    adventurer.Id = testRepo.AddUser(adventurer);

                    var dep = new BLL.Progress
                    {
                        Nam = "testProgressName"
                    };
                    dep.Id = testRepo.AddProgress(dep);
                    var request = new BLL.Request
                    {
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };
                    request.Id = testRepo.AddRequest(request);

                    //add obj with values
                    var obj = new BLL.AdventurerParty
                    {
                        //assign values
                        Nam = "testName",
                        RequestId = request.Id,
                        AdventurerId = adventurer.Id
                    };

                    obj.Id = testRepo.AddAdventurerParty(obj);

                    await testRepo.DeleteAdventurerPartyAsync(obj.Id);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(0, context.AdventurerParty.Count()); //check size of in memory dbset is now zero
                }
            }
            finally
            {
                connection.Close();
            }
        }

        

        [Fact]
        public async Task DeleteAsync_Progress_removes_from_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<project2theGuildContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new project2theGuildContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new project2theGuildContext(options))
                {
                    //create new Repo
                    var testRepo = new Repository(context);

                    //add obj with values
                    var obj = new BLL.Progress
                    {
                        //assign values
                        Nam = "testProgressName"
                    };

                    obj.Id = testRepo.AddProgress(obj);

                    await testRepo.DeleteProgressAsync(obj.Id);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(0, context.Progress.Count()); //check size of dbset is now zero
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task DeleteAsync_Rank_removes_from_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<project2theGuildContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new project2theGuildContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new project2theGuildContext(options))
                {
                    //create new Repo
                    var testRepo = new Repository(context);

                    //add obj with values
                    var obj = new BLL.Ranks
                    {
                        //add values
                        Nam = "testName",
                        Fee = 10
                    };

                    obj.Id = testRepo.AddRank(obj);

                    await testRepo.DeleteRankAsync(obj.Id);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(0, context.Ranks.Count()); //check size of dbset is now zero
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task DeleteAsync_RankRequirements_removes_from_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<project2theGuildContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new project2theGuildContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new project2theGuildContext(options))
                {
                    //create new Repo
                    var testRepo = new Repository(context);

                    //add dependencies
                    var dep1 = new BLL.Ranks
                    {
                        //add values
                        Nam = "r1",
                        Fee = 1
                    };
                    var dep2 = new BLL.Ranks
                    {
                        //add values
                        Nam = "r2",
                        Fee = 2
                    };
                    dep1.Id = testRepo.AddRank(dep1);
                    dep2.Id = testRepo.AddRank(dep2);

                    //add obj with values
                    var obj = new BLL.RankRequirements
                    {
                        //add values
                        CurrentRankId = dep1.Id,
                        NextRankId = dep2.Id,
                        MinTotalStats = 10,
                        NumberRequests = 11
                    };

                    obj.Id = testRepo.AddRankRequirements(obj);

                    await testRepo.DeleteRankRequirementsAsync(obj.Id);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(0, context.RankRequirements.Count()); //check size of dbset is now zero
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task DeleteAsync_Request_removes_from_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<project2theGuildContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new project2theGuildContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new project2theGuildContext(options))
                {
                    //create new Repo
                    var testRepo = new Repository(context);

                    //add dependency
                    var dep = new BLL.Progress
                    {
                        //assign values
                        Nam = "testProgressName"
                    };

                    dep.Id = testRepo.AddProgress(dep);

                    //add obj with values
                    var obj = new BLL.Request
                    {
                        //add values
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };

                    obj.Id = testRepo.AddRequest(obj);

                    await testRepo.DeleteRequestAsync(obj.Id);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(0, context.Request.Count()); //check size of dbset is now zero
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task DeleteAsync_RequestingGroup_removes_from_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<project2theGuildContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new project2theGuildContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new project2theGuildContext(options))
                {
                    //create new Repo
                    var testRepo = new Repository(context);

                    //dependencies
                    var customer = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast"
                    };
                    customer.Id = testRepo.AddUser(customer);

                    var dep = new BLL.Progress
                    {
                        Nam = "testProgressName"
                    };
                    dep.Id = testRepo.AddProgress(dep);
                    var request = new BLL.Request
                    {
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };
                    request.Id = testRepo.AddRequest(request);

                    //add obj with values
                    var obj = new BLL.RequestingGroup
                    {
                        //assign values
                        CustomerId = customer.Id,
                        RequestId = request.Id
                    };

                    obj.Id = testRepo.AddRequestingGroup(obj);

                    await testRepo.DeleteRequestingGroupAsync(obj.Id);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(0, context.RequestingGroup.Count()); //check size of dbset is now zero                  
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task DeleteAsync_User_removes_from_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<project2theGuildContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new project2theGuildContext(options))
                {
                    context.Database.EnsureCreated();
                }
                BLL.Users obj;
                // Run the test against one instance of the context
                using (var context = new project2theGuildContext(options))
                {
                    //create new Repo
                    var testRepo = new Repository(context);

                    //add obj with values
                    obj = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast"
                    };
                    obj.Id = testRepo.AddUser(obj);

                    await testRepo.DeleteUserAsync(obj.Id);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(0, context.Users.Count()); //check size of dbset is now zero
                }
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
