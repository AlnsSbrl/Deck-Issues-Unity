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

    [SerializeField]
    public List<CurreloPlayer> Players; //TODO-> tienen una lista de cartas, una booleana para saber si han ganado
    public bool hasGameStarted;
    public int playerThatDealtTheCards;
    public int nextPlayerToPlay;


    [SerializeField]
    public int NumberOfPlayers;

    public SpanishDeck Triumph;
    public SpanishDeck FirstCardPlayed;
    public SpanishDeck? CurrentHandWinningCard;

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
            int winningPlayerIndex = 0;
            //todo cambiar la variable de contador de bucle
            for (int i = 0; i < Players.Count; i++)
            {
                SpanishDeck CardPlayed;
                //check if its players turn
                if (Players[i].isPlayer)           
                {
                    while (true)
                    {
                        if (Input.GetMouseButtonDown(0)) 
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
                            if(hit.collider != null)
                            {
                                Debug.Log(hit.collider.gameObject.name);
                                CardPlayed = (SpanishDeck)int.Parse(hit.collider.gameObject.tag);
                                bool isValidMove=false;
                                // y comprobar si se puede
                                if (isValidMove)
                                {
                                    break;
                                }
                                else
                                {
                                    //perform wrong move sfx, maybe animation or color change
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    if (CurrentHandWinningCard != null)
                    {
                        CardPlayed = Players[i].PerformNextCardMove(FirstCardPlayed,Triumph, CurrentHandWinningCard);
                    }
                    else
                    {
                        CardPlayed = Players[i].PerformNextCardMove(FirstCardPlayed,Triumph);
                    }
                }
                //what if no hay currentHandWinningCard
                if(DoesNewCardBeatOldCard(CardPlayed, CurrentHandWinningCard))
                {
                    CurrentHandWinningCard= CardPlayed;
                    winningPlayerIndex= i;
                }
                if(/* contador es multiplo de numero de jugadores se acaba la baza*/)
                {
                    Players[winningPlayerIndex].hasWon = true;
                    if (Players[winningPlayerIndex].HandCards.Count == 0)
                    {
                        //finalizar baza
                        //clear hand winning and first card played
                        //hacer desaparecer las cartas
                        //volver a activar carta
                        

                    }
                }                
            }
            //condicion de si se puede jugar la carta o hay algun proceso esperando siendo ejecutado
            //teniendo en cuenta el turno del next player le tocará al jugador seleccionar un input o la maquina toma la decision
            //se echa la carta y se da un waittime mientras se ejecutan el resto de procesos
            //tras cada lanzamiento de carta se calcula la carta ganadora y se actualiza
            //cuando todos los jugadores hayan echado carta se cierra la baza
            //se repite este bucle mientras los jugadores tengan cartas, empezando el jugador que ganó la baza
            //cuando se acaben todas las bazas, se determina el ganador, se hace otra animacion y se vuelve a la escena original
        }
    }

    private bool DoesNewCardBeatOldCard(SpanishDeck newPlayedCard, SpanishDeck? currentHandWinningCard = null)
    {
        if (currentHandWinningCard == null) 
        { 
            currentHandWinningCard = newPlayedCard;
            FirstCardPlayed = newPlayedCard;
            return true;
        }
        
        if (GetSuit((SpanishDeck)currentHandWinningCard) == GetSuit(newPlayedCard))
        {
            return GetCardValue(newPlayedCard)> GetCardValue((SpanishDeck)currentHandWinningCard);
        }
        else
        {
            return GetSuit(newPlayedCard)==GetSuit(Triumph);
        }
    }

    private SpanishSuit GetSuit(SpanishDeck card)
    {
        return EnumExtensions.GetSpanishSuit(card);
    }

    private int GetCardValue(SpanishDeck card)
    {
        return EnumExtensions.GetCardValue(card);
    }

    private void InitPlayerCardDistribution(int numberOfPlayers)
    {
        //create coordinates for each player to display each of their cards
    }


    public bool DealCards(int numberOfPlayers) 
    {
        InitCards();
        DealCardsGiven_NumberOfPlayersAndNumberOfCardsPerPlayer(numberOfPlayers, 3);  
        return true;    
    }

    private void DealCardsGiven_NumberOfPlayersAndNumberOfCardsPerPlayer(int numberOfPlayers, int NumberOfCardsPerPlayer)
    {
        
            Players = new List<CurreloPlayer>(); //config this on onStart()
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
