using Assets.Scripts;
using Assets.Scripts.Enums;
using Ionic.Zlib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CurreloGameController : MonoBehaviour
{
    public HashSet<SpanishDeck> PossibleCards;
    public HashSet<SpanishDeck> DealtCards;
    public List<Player> Players;
    public bool hasGameStarted;
    public int playerThatDealtTheCards;
    public int nextPlayerToPlay;


    [SerializeField]
    public int NumberOfPlayers;

    public SpanishDeck Triumph;

    void Start()
    {
        InitCards();
        InitPlayerCardDistribution(NumberOfPlayers);
        hasGameStarted=false;
    }

    void Update()
    {
        //the scene must have a card on the center of the screen //TODO- unity editor
        if (!hasGameStarted){
            //check mouse input on card bounds until true, then start game
            //TODO: HOW TO GET THE INPUT EVENT FROM THE OTHER SCRIPT (SPANISHDECKCARD)

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


    public bool DealCards(int numberOfPlayers) 
    {
        InitCards();
        DealCardsGiven_NumberOfPlayersAndNumberOfCardsPerPlayer(numberOfPlayers, 3);  
        return true;    }

    private void DealCardsGiven_NumberOfPlayersAndNumberOfCardsPerPlayer(int numberOfPlayers, int NumberOfCardsPerPlayer)
    {
        
            Players = new List<Player>(); //config this on onStart()
            DealtCards = new HashSet<SpanishDeck>();
            List<SpanishDeck> AuxCards = PossibleCards.ToList();          
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

    public bool isMoveLegal(SpanishDeck selectedCard, SpanishDeck[] availableCards, SpanishDeck currentHandWinningCard, SpanishDeck firstPlayedCard)
    {
        //from available cards, le aplicamos un "filtro": solo quedan las que asisten al palo
        
        List<SpanishDeck> CardsThatFollowTheRule = availableCards.Where(x=>GetSuit(x)==GetSuit(firstPlayedCard)).ToList();

        if(CardsThatFollowTheRule.Count > 0)
        {
            if (GetSuit(firstPlayedCard) == GetSuit(currentHandWinningCard))
            {
                List<SpanishDeck> CardsThatHaveAHigherValue = CardsThatFollowTheRule.Where(x=>GetCardValue(x)>GetCardValue(currentHandWinningCard)).ToList();
                if(CardsThatHaveAHigherValue.Count > 0)
                {
                    //le tienes que subir a la carta más alta
                    return CardsThatHaveAHigherValue.Contains(selectedCard);
                }
                else
                {
                    //no puedes subirle a la carta más alta
                    return CardsThatFollowTheRule.Contains(selectedCard);
                }
            }
            else
            {
                //alguien ha fallado pero sigues teniendo que asistir
                return CardsThatFollowTheRule.Contains(selectedCard);
            }
        }

        List<SpanishDeck> CardsThatAreTriumph = availableCards.Where(x=>GetSuit(x)==GetSuit(Triumph)).ToList();
        
        if(CardsThatAreTriumph.Count > 0)
        {
            if (GetSuit(currentHandWinningCard) == GetSuit(Triumph))
            {
                List<SpanishDeck> CardsThatAreTriumphAndAreBetterThanTheCurrentlyWinningCard = CardsThatAreTriumph.Where(x => GetCardValue(x) > GetCardValue(currentHandWinningCard)).ToList();
                if(CardsThatAreTriumphAndAreBetterThanTheCurrentlyWinningCard.Count > 0)
                {
                    //solo puedes echar un triunfo mayor al que está ganando ahora mismo
                    return CardsThatAreTriumphAndAreBetterThanTheCurrentlyWinningCard.Contains(selectedCard);
                }
                else
                {
                    //si no tienes un triunfo mayor que el que está ganando, no tienes por qué echar triunfo
                    return availableCards.Contains(selectedCard);
                }
            }
            //te permite echar cualquier triunfo
            return CardsThatAreTriumph.Contains(selectedCard);    
        }
        //at this point it doesn't restrict which card you play
        return availableCards.Contains(selectedCard);
    }

    private SpanishSuit GetSuit(SpanishDeck card)
    {
        return EnumExtensions.GetSpanishSuit(card);
    }

    private int GetCardValue(SpanishDeck card)
    {
        return EnumExtensions.GetCardValue(card);
    }

    public void InitCards()
    {
        PossibleCards = new HashSet<SpanishDeck>();
        var CardsInSpanishDeck = Enum.GetValues(typeof(SpanishDeck));
        for (int i = 0; i < CardsInSpanishDeck.Length; i++)
        {          
            PossibleCards.Add((SpanishDeck)i);
        }                       
    }
}
