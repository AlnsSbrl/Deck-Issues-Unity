using System.Collections;
using System.Runtime.Remoting.Messaging;
using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpanishSuitCardTests
{

    [TestCase(39,SpanishSuit.BASTOS)]
    [TestCase(0,SpanishSuit.OROS)]
    [TestCase(10,SpanishSuit.COPAS)]
    public void EnsureChangingCardValue_UpdatesCardSuit(int CardValue, SpanishSuit expectedSuit)
    {
        //given
        SpanishDeckCard card = new GameObject().AddComponent<SpanishDeckCard>();
        Sprite[] sprArr = Resources.LoadAll<Sprite>("Sprites/Cards/SpanishDeck");
        TestContext.WriteLine($"Loaded {sprArr.Length} sprites");
        card.Deck = sprArr;
        //when
        card.ChangeCard(CardValue);
        //then
        Assert.AreEqual(expectedSuit, card.SpanishSuit);
    }
}
