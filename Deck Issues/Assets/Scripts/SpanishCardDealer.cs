using Assets.Scripts;
using Ionic.Zlib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SpanishCardDealer : MonoBehaviour
{
    public HashSet<Card> PossibleCards;
    public HashSet<Card> DealtCards;
    public List<Player> Players;
    public Card Triumph;
    public Deck CurrentDeck;
    private bool doesCurrentGameNeedATriumph;

    void Start()
    {
        InitCards(Deck.Spanish);
    }

    void Update()
    {
        
    }

    public bool DealCards(CardGame cardGame, int numberOfPlayers) 
    {
        switch (cardGame)
        {
            case CardGame.Currelo:
                InitCards(Deck.Spanish);
                doesCurrentGameNeedATriumph = true;
                DealCardsGiven_NumberOfPlayersAndNumberOfCardsPerPlayer(numberOfPlayers, 3);
                break;
            case CardGame.Tute:
                break;
            case CardGame.Brisca:
                break;
            case CardGame.Emperador:
                break;
            case CardGame.Poker:
                break;
        }
        return false;
    }

    private void DealCardsGiven_NumberOfPlayersAndNumberOfCardsPerPlayer(int numberOfPlayers, int NumberOfCardsPerPlayer)
    {
        
            Players = new List<Player>();
            DealtCards = new HashSet<Card>();
            List<Card> AuxCards = PossibleCards.ToList();          
            for (int i = 0;i < numberOfPlayers; i++)
            {
                for(int j = 0; j< NumberOfCardsPerPlayer; j++)
                {
                    int RandomValue = UnityEngine.Random.Range(0, AuxCards.Count);                                      
                    DealtCards.Add(AuxCards[RandomValue]);
                    //añadir a player
                    AuxCards.RemoveAt(RandomValue);                                      
                }
            }
        
    }

    public void InitCards(Deck deck)
    {
        PossibleCards = new HashSet<Card>();
        CurrentDeck = deck;

        if(deck == Deck.Spanish)
        {
            var CardsInSpanishDeck = Enum.GetValues(typeof(SpanishDeck));
            for (int i = 0; i < CardsInSpanishDeck.Length; i++)
            {
                Card card = new Card((SpanishDeck)CardsInSpanishDeck.GetValue(i));
                PossibleCards.Add(card);
            }
        }
        if(deck == Deck.French)
        {
            var CardsInFrenchDeck = Enum.GetValues(typeof(FrenchDeck));
            for(int i = 0; i < CardsInFrenchDeck.Length; i++)
            {
                Card card = new Card((FrenchDeck)CardsInFrenchDeck.GetValue(i));
                PossibleCards.Add(card);
            }
        }
        
    }
}
