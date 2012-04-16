using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;

namespace Tests.Raven
{
    public class TestUserSettings
    {
        public bool Dentist { get; set; }
        public bool Hospital { get; set; }
    }

    public class TestUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Addresses { get; set; }
        public TestUserSettings Settings { get; set; }

        public TestUser()
        {
            Addresses = new List<string>();
            Settings = new TestUserSettings();
        }
    }

    [TestFixture]
    public class RandomRavenDBTests
    {
        [Test]
        public void random_raven_tests()
        {
            var user1 = new TestUser {Login = "Zygmunt", Password = "pass"};
            user1.Addresses.Add("Poznań, CWiBT drugie pietro");
            user1.Addresses.Add("Zambia, Black Street 23");
            user1.Addresses.Add("Poland, Warsaw, Nowy Świat 123");
            user1.Settings.Dentist = true;
            user1.Settings.Hospital = false;

            var user2 = new TestUser { Login = "Ania", Password = "haslo123" };


            DatabaseStatistics beginStats;

            // get stats
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    beginStats = session.Advanced.DatabaseCommands.GetStatistics();
                }
            }

            // add first user
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    session.Store(user1);
                    session.Store(user2);
                    session.SaveChanges();
                }
            }

            // check stats
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    var stats = session.Advanced.DatabaseCommands.GetStatistics();
                    Assert.AreEqual(beginStats.CountOfDocuments + 2, stats.CountOfDocuments);
                }
            }

            // modify first user
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    var queriedUser = session.Query<TestUser>().Single(user => user.Login == "Zygmunt");
                    queriedUser.Password = "new_zygmunts_pass";
                    session.Store(queriedUser);
                    session.SaveChanges();
                }
            }

            // remove all
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    var queriedUser = session.Query<TestUser>().ToList();
                    foreach (var testUser in queriedUser)
                    {
                        session.Delete(testUser);
                    }
                    session.SaveChanges();
                }
            }

            // check stats
            using (IDocumentStore documentStore = new DocumentStore() { Url = "http://localhost:8080" })
            {
                documentStore.Initialize();
                using (IDocumentSession session = documentStore.OpenSession())
                {
                    var stats = session.Advanced.DatabaseCommands.GetStatistics();
                    Assert.AreEqual(beginStats.CountOfDocuments, stats.CountOfDocuments);
                }
            }
        }
    }
}