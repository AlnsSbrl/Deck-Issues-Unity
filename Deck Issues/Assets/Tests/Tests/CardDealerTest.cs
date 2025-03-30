using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class CardDealerTest
{
    [Test]
    public void AssertAllDealtCardsAreDifferent()
    {
        
    }

    [Test]
    public void AssertAllCardsAreAvailableBeforeDealingTheCards()
    {
        //given
        var cards = Enum.GetValues(typeof(SpanishDeck));
        //when
        CurreloGameController dealer = new CurreloGameController();
        dealer.InitCards(Deck.Spanish);
        //then
        TestContext.WriteLine($"Expected {cards.Length} but got {dealer.PossibleCards.Count}");
        Assert.AreEqual(cards.Length,dealer.PossibleCards.Count, $"Expected {cards.Length} but got {dealer.PossibleCards.Count}");
    }
    [Test]
    public void AssertAllAvailableCardsAreDifferent()
    {


    }
}

