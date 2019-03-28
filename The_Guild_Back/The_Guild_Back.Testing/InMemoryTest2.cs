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
    public class InMemoryTest2
    {
        [Fact]
        public async Task UpdateAsync_AdventurerParty_writes_to_database()
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

                    obj.Nam = "newName";
                    await testRepo.UpdateAdventurerPartyAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.AdventurerParty.Count()); //check size of in memory dbset is now one
                    Assert.Equal("newName", context.AdventurerParty.Single().Nam ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

        

        [Fact]
        public async Task UpdateAsync_Progress_writes_to_database()
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
                    //testRepo.Save();

                    obj.Nam = "newName";
                    await testRepo.UpdateProgressAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Progress.Count()); //check size of dbset is now one
                    Assert.Equal("newName", context.Progress.Single().Nam ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task UpdateAsync_Rank_writes_to_database()
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


                    obj.Nam = "newName";
                    obj.Fee = 100;

                    await testRepo.UpdateRankAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Ranks.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("newName", context.Ranks.Single().Nam ); 
                    Assert.Equal(100, context.Ranks.Single().Fee);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task UpdateAsync_RankRequirements_writes_to_database()
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

                    obj.MinTotalStats = 12;
                    obj.NumberRequests = 13;

                    await testRepo.UpdateRankRequirementsAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.RankRequirements.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal(12, context.RankRequirements.Single().MinTotalStats ); 
                    Assert.Equal(13, context.RankRequirements.Single().NumberRequests);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task UpdateAsync_Request_writes_to_database()
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

                    obj.Descript = "newDescription";
                    obj.Requirements = "newRequirements";
                    await testRepo.UpdateRequestAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Request.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("newDescription", context.Request.Single().Descript );
                    Assert.Equal("newRequirements", context.Request.Single().Requirements);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task UpdateAsync_RequestingGroup_writes_to_database()
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


                    var customer2 = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast"
                    };
                    customer2.Id = testRepo.AddUser(customer2);
                    var request2 = new BLL.Request
                    {
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };
                    request2.Id = testRepo.AddRequest(request2);

                    obj.CustomerId = customer2.Id;
                    obj.RequestId = request2.Id;
                    await testRepo.UpdateRequestingGroupAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.RequestingGroup.Count()); //check size of dbset is now one                   
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task UpdateAsync_User_writes_to_database()
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

                    obj.FirstName = "newFirst";
                    obj.LastName = "newLast";
                    await testRepo.UpdateUserAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Users.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("newFirst", context.Users.Single().FirstName ); 
                    Assert.Equal("newLast", context.Users.Single().LastName);
                }
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
