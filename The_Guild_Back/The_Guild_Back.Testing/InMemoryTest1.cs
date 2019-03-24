using System;
using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using The_Guild_Back.BLL;
using The_Guild_Back.DAL;

namespace The_Guild_Back.Testing
{
    public class InMemoryTest1
    {
        [Fact]
        public void Add_AdventurerParty_writes_to_database()
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

                    testRepo.AddAdventurerParty(obj);
                    testRepo.Save();
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
        public void Add_Progress_writes_to_database()
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

                    testRepo.AddProgress(obj);
                    testRepo.Save();
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

        //[Fact]
        public void Add_Rank_writes_to_database()
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

                    //add obj with values
                    var obj = new BLL.Ranks();
                    //add values



                    //testRepo.AddRanks(obj);
                    //testRepo.Save();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    //Assert.Equal(1, context.RankRequirements.Count()); //check size of dbset is now one
                    //Assert.Equal(" value ", context.RankRequirements.Single(). Value ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void Add_RankRequirements_writes_to_database()
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

                    //add obj with values
                    var obj = new BLL.RankRequirements();
                    //add values



                    //testRepo.AddRankRequirements(obj);
                    //testRepo.Save();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    //Assert.Equal(1, context.RankRequirements.Count()); //check size of dbset is now one
                    //Assert.Equal(" value ", context.RankRequirements.Single(). Value ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void Add_Request_writes_to_database()
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

                    testRepo.AddRequest(obj);
                    testRepo.Save();
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

        //[Fact]
        //public void Add_RequestingGroup_writes_to_database()
        //{
        //    // In-memory database only exists while the connection is open
        //    var connection = new SqliteConnection("DataSource=:memory:");
        //    connection.Open();

        //    try
        //    {
        //        var options = new DbContextOptionsBuilder<project2theGuildContext>()
        //            .UseSqlite(connection)
        //            .Options;

        //        // Create the schema in the database
        //        using (var context = new project2theGuildContext(options))
        //        {
        //            context.Database.EnsureCreated();
        //        }

        //        // Run the test against one instance of the context
        //        using (var context = new project2theGuildContext(options))
        //        {
        //            //create new Repo
        //            var testRepo = new Repository(context);

        //            //dependencies
        //            var customer = new BLL.Users
        //            {
        //                FirstName = "testFirst",
        //                LastName = "testLast"
        //            };
        //            customer.Id = testRepo.AddUser(customer);

        //            var dep = new BLL.Progress
        //            {
        //                Nam = "testProgressName"
        //            };
        //            dep.Id = testRepo.AddProgress(dep);
        //            var request = new BLL.Request
        //            {
        //                Descript = "testDescription",
        //                Requirements = "testRequirements",
        //                ProgressId = dep.Id
        //            };
        //            request.Id = testRepo.AddRequest(request);

        //            //add obj with values
        //            var obj = new BLL.RequestingGroup
        //            {
        //                //assign values
        //                CustomerId = customer.Id,
        //                RequestId = request.Id
        //            };

        //            testRepo.AddRequestingGroup(obj);
        //        }

        //        // Use a separate instance of the context to verify correct data was saved to database
        //        using (var context = new project2theGuildContext(options))
        //        {
        //            Assert.Equal(1, context.RequestingGroup.Count()); //check size of dbset is now one                   
        //        }
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        [Fact]
        public void Add_User_writes_to_database()
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
                    testRepo.AddUser(obj);
                    testRepo.Save();
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
