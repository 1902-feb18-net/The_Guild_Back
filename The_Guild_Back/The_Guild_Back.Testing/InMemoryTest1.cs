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
                    //var testRepo = new 

                    //add obj with values
                    var obj = new AdventurerParty();
                    //assign values


                    //testRepo.Add(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    //Assert.Equal(1, context.AdventurerParty.Count()); //check size of in memory dbset is now one
                    //Assert.Equal(" value ", context.AdventurerParty.Single(). Value ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void Add_LoginInfo_writes_to_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<project2theGuildContext>()
                    //.UseInMemoryDatabase(databaseName: "Add_writes_to_database")
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
                    var obj = new BLL.LoginInfo
                    {
                        //give values
                        Username = "testName",
                        Pass = "testPass"
                    };
                    testRepo.AddLoginInfo(obj);
                    testRepo.Save();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    Assert.Equal(1, context.LoginInfo.Count()); //check size of dbset is now one
                    //check values equal given values
                    Assert.Equal("testName", context.LoginInfo.Single().Username ); 
                    Assert.Equal("testPass", context.LoginInfo.Single().Pass );
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
                    //var testRepo = new

                    //add obj with values
                    var obj = new BLL.RankRequirements();
                    //add values


                    //testRepo.Add(obj);
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

        public void Add_RequestingParty_writes_to_database()
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
                    //var testRepo = new

                    //add obj with values
                    var obj = new BLL.RequestingParty();
                    //assign values


                    //testRepo.Add(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    //Assert.Equal(1, context.RequestingParty.Count()); //check size of dbset is now one
                    //Assert.Equal(" value ", context.RequestingParty.Single(). Value ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

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

                    //create loginfo dependency?
                    var login = new BLL.LoginInfo
                    {
                        Username = "testUsername",
                        Pass = "testPass"
                    };
                    login.Id = testRepo.AddLoginInfo(login);

                    //add obj with values
                    var obj = new BLL.Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast",
                        LoginInfoId = login.Id
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
