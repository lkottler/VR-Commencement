using System.Collections;
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

            ////////////////////////////////////////////////////
            // TEST 1: spawn player
            ////////////////////////////////////////////////////
            QuickSpawnMock qs = new QuickSpawnMock();
            qs.guestStart();
            qs.OnConnectedToMaster();
            qs.OnJoinRoomFailed("fail");
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
