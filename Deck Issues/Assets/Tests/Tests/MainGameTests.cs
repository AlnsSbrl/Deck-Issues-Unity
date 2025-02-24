using System;
using System.Collections;
using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MainGameTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void MainGameTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MainGameTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [Test]
    public void ReturnSpriteName_ForSpanishDeckEnumValue()
    {
        //given
        string SpritePath= CardUtils.GetSpriteForSpanishDeckCard(SpanishDeck.AS_DE_OROS);
        //when
        //then
        Assert.AreEqual("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_AS.png", SpritePath);
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
