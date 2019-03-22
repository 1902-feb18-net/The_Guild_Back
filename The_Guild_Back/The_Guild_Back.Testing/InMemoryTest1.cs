using System;
using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public void Add_LoginInfo_writes_to_database()
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
                    var obj = new LoginInfo();
                    //give values
                    obj.Username = "testName";
                    obj.Pass = "testPass";                  

                    //testRepo.Add(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    //Assert.Equal(1, context.LoginInfo.Count()); //check size of dbset is now one
                    //Assert.Equal("testName", context.LoginInfo.Single().Username ); //check values equal given values
                    //Assert.Equal("testPass", context.LoginInfo.Single().Pass );
                }
            }
            finally
            {
                connection.Close();
            }
        }

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
                    //var testRepo = new

                    //add obj with values
                    var obj = new Progress();
                    //assign values


                    //testRepo.Add(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    //Assert.Equal(1, context.Progress.Count()); //check size of dbset is now one
                    //Assert.Equal(" value ", context.Progress.Single(). Value ); //check values equal given values
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
                    var obj = new RankRequirements();
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
                    //var testRepo = new

                    //add obj with values
                    var obj = new Request();
                    //add values


                    //testRepo.Add(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    //Assert.Equal(1, context.Request.Count()); //check size of dbset is now one
                    //Assert.Equal(" value ", context.Request.Single(). Value ); //check values equal given values
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
                    var obj = new RequestingParty();
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
                    //var testRepo = new

                    //create loginfo dependency?
                    //LoginInfo login = new LoginInfo
                    //{
                    //    Username = "testUsername",
                    //    Pass = "testPass"
                    //};
                    //add login

                    //add obj with values
                    var obj = new Users
                    {
                        FirstName = "testFirst",
                        LastName = "testLast",
                        //LoginInfoId = 
                    };


                    //testRepo.Add(obj);
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new project2theGuildContext(options))
                {
                    //Assert.Equal(1, context.Users.Count()); //check size of dbset is now one
                    //Assert.Equal(" value ", context.Users.Single(). Value ); //check values equal given values
                }
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
