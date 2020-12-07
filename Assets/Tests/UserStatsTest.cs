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
            // TEST 1: get username of default , changed person
            ////////////////////////////////////////////////////
            string username = "user";
            string curr = UserStatsMock.getUsername();
            Assert.AreEqual(curr, "Guest");

            UserStatsMock.setUsername(username);
            curr = UserStatsMock.getUsername();
            Assert.AreEqual(curr, "user");

            ////////////////////////////////////////////////////
            // TEST 2: get index of default , changed person
            ////////////////////////////////////////////////////
            int index = 2;
            int ind = UserStatsMock.getAvatarIndex();
            Assert.AreEqual(ind, 0);

            UserStatsMock.setAvatarIndex(index);
            ind = UserStatsMock.getAvatarIndex();
            Assert.AreEqual(ind, 2);

            ////////////////////////////////////////////////////
            // TEST 3: get password of default , changed person
            ////////////////////////////////////////////////////
            string password = "userp";
            string currp = UserStatsMock.getPassword();
            Assert.AreEqual(currp, "");

            UserStatsMock.setPassword(password);
            currp = UserStatsMock.getPassword();
            Assert.AreEqual(currp, "userp");

            ////////////////////////////////////////////////////
            // TEST 4: get degree of default , changed person
            ////////////////////////////////////////////////////
            string degree = "CS";
            string currd = UserStatsMock.getDegree();
            Assert.AreEqual(currd, "Bachelor of Science");

            UserStatsMock.setDegree(degree);
            currd = UserStatsMock.getDegree();
            Assert.AreEqual(currd, "CS");

            ////////////////////////////////////////////////////
            // TEST 5: get chat of default , changed person
            ////////////////////////////////////////////////////
            bool chat = true;
            bool currc = UserStatsMock.getChatOn();
            Assert.AreEqual(currc, false);

            UserStatsMock.setChatOn(chat);
            currc = UserStatsMock.getChatOn();
            Assert.AreEqual(currc, true);

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
