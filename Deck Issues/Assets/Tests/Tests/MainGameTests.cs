using System;
using System.Collections;
using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MainGameTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    [Ignore("IEnumerator example")]
    public IEnumerator MainGameTests_ExampleWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [Test]
    public void ReturnSpanishDeckEnumValue_ByNumberOfCardAsParameter()
    {
        //given
        int cardValue = 0;
        //when
        SpanishDeck card = (SpanishDeck)Enum.GetValues(typeof(SpanishDeck)).GetValue(cardValue);
        //then
        Assert.AreEqual(SpanishDeck.AS_DE_OROS, card);
    }



}
