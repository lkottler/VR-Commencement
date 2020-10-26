using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LoginTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void LoginTestSimplePasses()
        {
            // Use the Assert class to test conditions
            // Ex: Assert.AreEqual("hello", "hello");

            // NOTE: Starts with known user in database,
            // fails if user doesn't already exsist

            ////////////////////////////////////////////////////
            // TEST 1: Login with good username/password combo
            ////////////////////////////////////////////////////

            // Call login method with input
            string user1 = "RegTestUser";
            string pass1 = "RegTestPass";
            bool success = false;
            //success = login(user1, pass1);
            Assert.True(success);

            ////////////////////////////////////////////////////
            // TEST 2: Login with good username, bad password
            ////////////////////////////////////////////////////

            // Call login method with input
            string user2 = "RegTestUser";
            string pass2 = "RegTestPassBad";
            success = true;
            //success = login(user2, pass2);
            Assert.False(success);

            ////////////////////////////////////////////////////
            // TEST 3: Login with good password, bad username
            ////////////////////////////////////////////////////

            // Call login method with input
            string user3 = "RegTestUserBad";
            string pass3 = "RegTestPass";
            success = true;
            //success = login(user3, pass3);
            Assert.False(success);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator LoginTestWithEnumeratorPasses()
        {
            // NOT USED FOR THIS TEST

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
