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

            ///////////////////////////////
            // TEST 1: SIMPLE USER
            ///////////////////////////////

            // Call registration method with input 
            string user = "RegTestUser";
            string pass = "RegTestPass";
            //register(user, pass);

            // TODO: Get info from database
            // query database
            string DBuser = "";
            string DBpass = "";
            //DBuser = ;
            //DBpass = ;
            
            // Check information exists
            Assert.True(DBuser != "");
            Assert.True(DBpass != "");
            
            // Check information is correct
            Assert.AreEqual(user, DBuser);
            Assert.AreEqual(pass, DBpass);
 

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
