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

                    obj.Id = await testRepo.AddAdventurerPartyAsync(obj);

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

                    obj.Id = await testRepo.AddProgressAsync(obj);
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

                    obj.Id = await testRepo.AddRankAsync(obj);


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

                    obj.Id = await testRepo.AddRankRequirementsAsync(obj);

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

                    dep.Id = await testRepo.AddProgressAsync(dep);

                    //add obj with values
                    var obj = new BLL.Request
                    {
                        //add values
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };

                    obj.Id = await testRepo.AddRequestAsync(obj);

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
        public async Task UpdateAsync_Requests_Progress_Backwards_Throws_Error()
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
                    var dep1 = new BLL.Progress
                    {
                        //assign values
                        Nam = "testProgressName"
                    };
                    dep1.Id = await testRepo.AddProgressAsync(dep1); //will be one

                    var dep2 = new BLL.Progress
                    {
                        //assign values
                        Nam = "testProgressTwo"
                    };
                    dep2.Id = await testRepo.AddProgressAsync(dep2); //will be two

                    //add obj with values
                    var obj = new BLL.Request
                    {
                        //add values
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep1.Id
                    };

                    obj.Id = await testRepo.AddRequestAsync(obj);

                    obj.Descript = "newDescription";
                    obj.Requirements = "newRequirements";
                    obj.ProgressId = dep2.Id;
                    await testRepo.UpdateRequestAsync(obj);

                    obj.ProgressId = dep1.Id;
                    await Assert.ThrowsAsync<ArgumentException>(() => testRepo.UpdateRequestAsync(obj));
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Request.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("newDescription", context.Request.Single().Descript);
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

                    obj.Id = await testRepo.AddRequestingGroupAsync(obj);


                    var customer2 = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast"
                    };
                    customer2.Id = await testRepo.AddUserAsync(customer2);
                    var request2 = new BLL.Request
                    {
                        Descript = "testDescription",
                        Requirements = "testRequirements",
                        ProgressId = dep.Id
                    };
                    request2.Id = await testRepo.AddRequestAsync(request2);

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
                    obj.Id = await testRepo.AddUserAsync(obj);

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


        [Fact]
        public async Task UpdateAsync_User_RankUp_Success_writes_to_database()
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

                    //
                    var dep1 = new BLL.Ranks
                    {
                        Nam = "Rank1",
                        Fee = 1
                    };
                    dep1.Id = await testRepo.AddRankAsync(dep1);

                    var dep2 = new BLL.Ranks
                    {
                        Nam = "Rank2",
                        Fee = 2
                    };
                    dep2.Id = await testRepo.AddRankAsync(dep2);

                    var dep3 = new BLL.RankRequirements
                    {
                        CurrentRankId = dep1.Id,
                        NextRankId = dep2.Id,
                        MinTotalStats = 1,
                        NumberRequests = 0
                    };
                    dep3.Id = await testRepo.AddRankRequirementsAsync(dep3);

                    //add obj with values
                    obj = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast",
                        Charisma = 10,
                        Constitution = 10,
                        Dex = 10,
                        Intelligence = 10,
                        Strength = 10,
                        Wisdom = 10,
                        RankId = dep1.Id
                    };
                    obj.Id = await testRepo.AddUserAsync(obj);

                    obj.FirstName = "newFirst";
                    obj.LastName = "newLast";
                    obj.RankId = dep2.Id;
                    await testRepo.UpdateUserAsync(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.Users.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("newFirst", context.Users.Single().FirstName);
                    Assert.Equal("newLast", context.Users.Single().LastName);
                    Assert.Equal(10, context.Users.Single().Charisma);
                    Assert.Equal(10, context.Users.Single().Constitution);
                    Assert.Equal(10, context.Users.Single().Dex);
                    Assert.Equal(10, context.Users.Single().Intelligence);
                    Assert.Equal(10, context.Users.Single().Strength);
                    Assert.Equal(10, context.Users.Single().Wisdom);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task UpdateAsync_User_RankUp_Throws_Error()
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

                    //
                    var dep1 = new BLL.Ranks
                    {
                        Nam = "Rank1",
                        Fee = 1
                    };
                    dep1.Id = await testRepo.AddRankAsync(dep1);

                    var dep2 = new BLL.Ranks
                    {
                        Nam = "Rank2",
                        Fee = 2
                    };
                    dep2.Id = await testRepo.AddRankAsync(dep2);

                    var dep3 = new BLL.RankRequirements
                    {
                        CurrentRankId = dep1.Id,
                        NextRankId = dep2.Id,
                        MinTotalStats = 1,
                        NumberRequests = 1
                    };
                    dep3.Id = await testRepo.AddRankRequirementsAsync(dep3);

                    //add obj with values
                    obj = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast",
                        Charisma = 10,
                        Constitution = 10,
                        Dex = 10,
                        Intelligence = 10,
                        Strength = 10,
                        Wisdom = 10,
                        RankId = dep1.Id
                    };
                    obj.Id = await testRepo.AddUserAsync(obj);

                    obj.FirstName = "newFirst";
                    obj.LastName = "newLast";
                    obj.RankId = dep2.Id;

                    await Assert.ThrowsAsync<ArgumentException>( () => testRepo.UpdateUserAsync(obj));
                }

            }
            finally
            {
                connection.Close();
            }
        }

    }
}
