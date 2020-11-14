using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UserStatsTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void UserStatsTestSimplePasses()
        {
            // Use the Assert class to test conditions
            
            ////////////////////////////////////////////////////
            // TEST 1: get username of default person
            ////////////////////////////////////////////////////
            string defaultName = "Guest";
            string actual = UserStats.getUsername();
            Assert.AreEqual(defaultName, actual);

            ////////////////////////////////////////////////////
            // TEST 2: set "normal" username
            ////////////////////////////////////////////////////
            string user1 = "JoeShmoe";
            UserStats.setUsername(user1);
            actual = UserStats.getUsername();
            Assert.AreEqual(user1, actual);

            ////////////////////////////////////////////////////
            // TEST 3: set username with space and numbers
            ////////////////////////////////////////////////////
            string user2 = "Joe Shmoe99";
            UserStats.setUsername(user2);
            actual = UserStats.getUsername();
            Assert.AreEqual(user2, actual);

            ////////////////////////////////////////////////////
            // TEST 4: set username as zero length string
            ////////////////////////////////////////////////////
            string user3 = "";
            UserStats.setUsername(user3);
            actual = UserStats.getUsername();
            Assert.AreEqual(user3, actual);
            
            //Assert.AreEqual("", "");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator UserStatsTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
