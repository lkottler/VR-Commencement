using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DialogueManagerTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void DialogueManagerTestSimplePasses()
        {
            // Use the Assert class to test conditions

            ////////////////////////////////////////////////////
            // TEST 1: start dialogue
            ////////////////////////////////////////////////////
            DialogueManagerMock dm = new DialogueManagerMock();
            dm.Startd();
            dm.StartDialogue("text");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator DialogueManagerTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
