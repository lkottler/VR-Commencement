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
