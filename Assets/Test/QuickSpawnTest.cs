﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class QuickSpawnTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void QuickSpawnTestSimplePasses()
        {
            // Use the Assert class to test conditions
            bool pass = true;
            //QuickSpawn.Instance.guestStart();
            //QuickSpawn.Instance.QuickQuit();
            Assert.True(pass);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator QuickSpawnTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
