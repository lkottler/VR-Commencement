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
            // NOTE: Starts with known user in database,
            // fails if user doesn't already exsist

            ////////////////////////////////////////////////////
            // TEST 1: Login with good username/password combo
            ////////////////////////////////////////////////////

            // Call login method with input
            string user1 = "RegTestUser";
            string pass1 = "RegTestPass";
            
            HomePage.Instance.CallLogin();
            bool success = HomePageMock.CallLogin(user1, pass1);
            Assert.True(success);

            ////////////////////////////////////////////////////
            // TEST 2: Login with good username, bad password
            ////////////////////////////////////////////////////

            // Call login method with input
            user1 = "RegTestUser";
            pass1 = "RegTestPassBad";

            HomePage.Instance.CallLogin();
            success = HomePageMock.CallLogin(user1, pass1);
            Assert.False(success);

            ////////////////////////////////////////////////////
            // TEST 3: Login with good password, bad username
            ////////////////////////////////////////////////////

            // Call login method with input
            user1 = "RegTestUserBad";
            pass1 = "RegTestPass";

            HomePage.Instance.CallLogin();
            success = HomePageMock.CallLogin(user1, pass1);
            Assert.False(success);

            ////////////////////////////////////////////////////
            // TEST 4: Login with bad password, bad username
            ////////////////////////////////////////////////////

            // Call login method with input
            user1 = "RegTestUserBad";
            pass1 = "RegTestPassBad";

            HomePage.Instance.CallLogin();
            success = HomePageMock.CallLogin(user1, pass1);
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
