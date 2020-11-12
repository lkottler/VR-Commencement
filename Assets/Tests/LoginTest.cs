using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/*
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
            HomePage home = new HomePage();
            
            home.logUser.text = user1;
            home.logPW.text = pass1;
            success = home.CallLogin();

            Assert.True(success);

            ////////////////////////////////////////////////////
            // TEST 2: Login with good username, bad password
            ////////////////////////////////////////////////////

            // Call login method with input
            string user2 = "RegTestUser";
            string pass2 = "RegTestPassBad";
            success = true;
            home = new HomePage();
            home.logUser.text = user2;
            home.logPW.text = pass2;
            success = home.CallLogin();
            Assert.False(success);

            ////////////////////////////////////////////////////
            // TEST 3: Login with good password, bad username
            ////////////////////////////////////////////////////

            // Call login method with input
            string user3 = "RegTestUserBad";
            string pass3 = "RegTestPass";
            success = true;
            home = new HomePage();
            home.logUser.text = user3;
            home.logPW.text = pass3;
            success = home.CallLogin();
            Assert.False(success);

            ////////////////////////////////////////////////////
            // TEST 4: Login with bad password, bad username
            ////////////////////////////////////////////////////

            // Call login method with input
            string user4 = "RegTestUserBad";
            string pass4 = "RegTestPassBad";
            success = true;
            home = new HomePage();
            home.logUser.text = user4;
            home.logPW.text = pass4;
            success = home.CallLogin();
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
*/