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
    public class InMemoryTest1
    {
        [Fact]
        public async Task Add_AdventurerPartyAsync_writes_to_database()
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
                    adventurer.Id = await testRepo.AddUserAsync(adventurer);

                    var dep = new BLL.Progress
                    {
                        Nam = "testProgressName"
                    };
                    dep.Id = await testRepo.AddProgressAsync(dep);
                    var request = new BLL.Request
                    {
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };
                    request.Id = await testRepo.AddRequestAsync(request);

                    //add obj with values
                    var obj = new BLL.AdventurerParty
                    {
                        //assign values
                        Nam = "testName",
                        RequestId = request.Id,
                        AdventurerId = adventurer.Id
                    };

                    await testRepo.AddAdventurerPartyAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.AdventurerParty.Count()); //check size of in memory dbset is now one
                    Assert.Equal("testName", context.AdventurerParty.Single().Nam ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

        

        [Fact]
        public async Task Add_ProgressAsync_writes_to_database()
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

                    await testRepo.AddProgressAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Progress.Count()); //check size of dbset is now one
                    Assert.Equal("testProgressName", context.Progress.Single().Nam ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task Add_RankAsync_writes_to_database()
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

                    await testRepo.AddRankAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Ranks.Count()); //check size of dbset is now one
                    Assert.Equal("testName", context.Ranks.Single().Nam ); //check values equal given values
                    Assert.Equal(10, context.Ranks.Single().Fee);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task Add_RankRequirementsAsync_writes_to_database()
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
                    dep1.Id = await testRepo.AddRankAsync(dep1);
                    dep2.Id = await testRepo.AddRankAsync(dep2);

                    //add obj with values
                    var obj = new BLL.RankRequirements
                    {
                        //add values
                        CurrentRankId = dep1.Id,
                        NextRankId = dep2.Id,
                        MinTotalStats = 10,
                        NumberRequests = 11
                    };

                    await testRepo.AddRankRequirementsAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.RankRequirements.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal(10, context.RankRequirements.Single().MinTotalStats ); 
                    Assert.Equal(11, context.RankRequirements.Single().NumberRequests);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task Add_RankRequirementsAsync_Throws_Error()
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
                    dep1.Id = await testRepo.AddRankAsync(dep1);
                    dep2.Id = await testRepo.AddRankAsync(dep2);

                    var dep3 = new BLL.Ranks
                    {
                        //add values
                        Nam = "r3",
                        Fee = 3
                    };
                    dep3.Id = await testRepo.AddRankAsync(dep3);

                    var dep4 = new BLL.RankRequirements
                    {
                        CurrentRankId = dep1.Id,
                        NextRankId = dep2.Id,
                        MinTotalStats = 10,
                        NumberRequests = 11
                    };
                    await testRepo.AddRankRequirementsAsync(dep4);

                    var obj = new BLL.RankRequirements
                    {
                        //add values
                        CurrentRankId = dep1.Id,
                        NextRankId = dep3.Id,
                        MinTotalStats = 12,
                        NumberRequests = 13
                    };
                    await Assert.ThrowsAsync<ArgumentException>( () => testRepo.AddRankRequirementsAsync(obj));

                }

            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task Add_RequestAsync_writes_to_database()
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

                    dep.Id = await testRepo.AddProgressAsync(dep);

                    //add obj with values
                    var obj = new BLL.Request
                    {
                        //add values
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };

                    await testRepo.AddRequestAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Request.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("testDescription", context.Request.Single().Descript );
                    Assert.Equal("testRequirements", context.Request.Single().Requirements);
                }
            }
            finally
            {
                connection.Close();
            }
        }


        [Fact]
        public async Task Add_RequestAsync_With_Rank_Sets_Cost()
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
                    dep.Id = await testRepo.AddProgressAsync(dep);

                    var dep2 = new BLL.Ranks
                    {
                        Nam = "testName",
                        Fee = 2
                    };
                    dep2.Id = await testRepo.AddRankAsync(dep2);

                    //add obj with values
                    var obj = new BLL.Request
                    {
                        //add values
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id,
                        RankId = dep2.Id
                    };

                    await testRepo.AddRequestAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Request.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("testDescription", context.Request.Single().Descript);
                    Assert.Equal("testRequirements", context.Request.Single().Requirements);
                    Assert.Equal(2, context.Request.Single().Cost);
                }
            }
            finally
            {
                connection.Close();
            }
        }
        [Fact]
        public async Task Add_RequestingGroupAsync_writes_to_database()
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
                    customer.Id = await testRepo.AddUserAsync(customer);

                    var dep = new BLL.Progress
                    {
                        Nam = "testProgressName"
                    };
                    dep.Id = await testRepo.AddProgressAsync(dep);
                    var request = new BLL.Request
                    {
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };
                    request.Id = await testRepo.AddRequestAsync(request);

                    //add obj with values
                    var obj = new BLL.RequestingGroup
                    {
                        //assign values
                        CustomerId = customer.Id,
                        RequestId = request.Id
                    };

                    await testRepo.AddRequestingGroupAsync(obj);
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
        public async Task Add_UserAsync_writes_to_database()
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
                    var obj = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast"
                    };
                    await testRepo.AddUserAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Users.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("testFirst", context.Users.Single().FirstName ); 
                    Assert.Equal("testLast", context.Users.Single().LastName);
                }
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
