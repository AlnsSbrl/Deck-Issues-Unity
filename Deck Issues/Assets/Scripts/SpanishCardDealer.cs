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
    public bool hasGameStarted;
    public int playerThatDealtTheCards;
    public int nextPlayerToPlay;


    [SerializeField]
    public int NumberOfPlayers;

    public Card Triumph;
    public Deck CurrentDeck;
    private bool doesCurrentGameNeedATriumph;

    void Start()
    {
        InitCards(Deck.Spanish);
        InitPlayerCardDistribution(NumberOfPlayers);
        hasGameStarted=false;
    }

    void Update()
    {
        //the scene must have a card on the center of the screen
        if (!hasGameStarted){
            //check mouse input on card bounds until true, then start game
            //the card that is used to start the game becomes invisible and unclicable untill the game finishes      
            //after the click the cards ARE DEALT FOLLOWING AN "ANIMATION" SIMILAR TO COFFEE TALK BREWING
            // the animation is a comic like illustration with 3 "pictures", loading at different times
            // after the animation, the scene has all cards dealt
        }
        else
        {
            //empieza una baza, con el jugador que deberia empezar segun el orden de repartir
            //condicion de si se puede jugar la carta o hay algun proceso esperando siendo ejecutado
            //teniendo en cuenta el turno del next player le tocará al jugador seleccionar un input o la maquina toma la decision
            //se echa la carta y se da un waittime mientras se ejecutan el resto de procesos
            //tras cada lanzamiento de carta se calcula la carta ganadora y se actualiza
            //cuando todos los jugadores hayan echado carta se cierra la baza
            //se repite este bucle mientras los jugadores tengan cartas, empezando el jugador que ganó la baza
            //cuando se acaben todas las bazas, se determina el ganador, se hace otra animacion y se vuelve a la escena original
        }
    }

    private void InitPlayerCardDistribution(int numberOfPlayers)
    {
        //create coordinates for each player to display each of their cards
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
        
            Players = new List<Player>(); //config this on onStart()
            DealtCards = new HashSet<Card>();
            List<Card> AuxCards = PossibleCards.ToList();          
            for (int i = 0;i < numberOfPlayers; i++)
            {
                for(int j = 0; j< NumberOfCardsPerPlayer; j++)
                {
                    int RandomValue = UnityEngine.Random.Range(0, AuxCards.Count);                                      
                    DealtCards.Add(AuxCards[RandomValue]);
                    //añadir a player
                    //move object to plyer cards location
                    AuxCards.RemoveAt(RandomValue);                                      
                }
            }
    }

    public bool isMoveLegal(Card selectedCard, Card[] availableCards, Card currentHandWinningCard, Card firstPlayedCard)
    {
        //it depends on the game
        

        //check if selectedCard suit is the same suit as firstPlayedCard
        //is the only one of the availableCards to fullfill the condition? then allowed

        //there are more than one card that matches the firstPlayedCard's deck? -> second condition
        //second condition: you have to select a card with a value higher than what's already winning
        //if you only have cards that have a lower value: both fullfill the condition
        //(this also happens when someone breaks, playing a trioumph card)
        //if only one card has a higher value: that card must be played
        //if both cards have a higher value, they both can be played as well

        //if the selected card DOESNT match the firstPlayedCard's suit
        //-> check if its a trioumph (and is higher than currentHandWinningCard) and if they have a trioumph on the available cards
        //they dont have a triumph that wins the hand -> any card can be thrown away

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
