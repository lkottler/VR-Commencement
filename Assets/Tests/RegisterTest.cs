using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class RegisterTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void RegisterTestSimplePasses()
        {
            // Use the Assert class to test conditions

            //GameObject gameObj = new GameObject("HomePage");
            //HomePage home = gameObj.AddComponent<HomePage>();

            //////////////////////////////////////////////////
            // TEST 1: create valid new user
            //////////////////////////////////////////////////

            // Call registration method with input 
            string user1 = "RegTestUserNEW";
            string pass1 = "RegTestPassNEW";
            bool success = true;
            HomePage.Instance.regUser.text = user1;
            HomePage.Instance.regPW.text = pass1;
            HomePage.Instance.CallRegister();
            success = HomePage.Instance.regSuccess;
            Assert.True(success);

            /////////////////////////////////////////////////////////
            // TEST 2: create invalid new user, user already exists
            /////////////////////////////////////////////////////////

            // Call registration method with input 
            string user2 = "RegTestUserNEW";
            string pass2 = "RegTestPassNEW";
            success = false;
            HomePage.Instance.regUser.text = user2;
            HomePage.Instance.regPW.text = pass2;
            HomePage.Instance.CallRegister();
            success = HomePage.Instance.regSuccess;
            Assert.False(success);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator RegisterTestWithEnumeratorPasses()
        {
            // NOT USED FOR THIS TEST

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
