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
        //given
        HashSet<Card> cards = new HashSet<Card>();
        //when
        SpanishCardDealer dealer = new SpanishCardDealer();
        dealer.DealCards(CardGame.Currelo,4); 
        //then
        Assert.AreEqual(cards.Count, dealer.DealtCards.Count, $"Expected {cards.Count} but got {dealer.DealtCards.Count}");
    }

    [Test]
    public void AssertAllCardsAreAvailableBeforeDealingTheCards()
    {
        //given
        var cards = Enum.GetValues(typeof(SpanishDeck));
        //when
        SpanishCardDealer dealer = new SpanishCardDealer();
        dealer.InitCards(Deck.Spanish);
        //then
        TestContext.WriteLine($"Expected {cards.Length} but got {dealer.PossibleCards.Count}");
        Assert.AreEqual(cards.Length,dealer.PossibleCards.Count, $"Expected {cards.Length} but got {dealer.PossibleCards.Count}");
    }
    [Test]
    public void AssertAllAvailableCardsAreDifferent()
    {
        //given
        var cards = Enum.GetValues(typeof (SpanishDeck));
        //when
        SpanishCardDealer dealer = new SpanishCardDealer();
        dealer.InitCards(Deck.Spanish);
        HashSet<Card> dealerCards = new HashSet<Card>();
        foreach(Card card in dealer.PossibleCards)
        {
            dealerCards.Add(card);
        }
        //then
        TestContext.WriteLine($"Expected {cards.Length} but got {dealerCards.Count}");
        Assert.AreEqual(cards.Length, dealerCards.Count, $"Expected {cards.Length} but got {dealerCards.Count}");

    }
}

