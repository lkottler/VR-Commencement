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
            // Ex: Assert.AreEqual("hello", "hello");

            // TODO: Call registration method
            

            // TODO: Get info from database
            // query database


            // TODO: Check that registration info matches database entry
            // check information exsists
            // check information matches


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
