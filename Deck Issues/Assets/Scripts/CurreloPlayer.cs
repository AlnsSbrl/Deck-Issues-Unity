using Assets.Scripts;
using Assets.Scripts.Enums;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurreloPlayer : MonoBehaviour
{
    
    public List<SpanishDeck> HandCards;
    public List<SpanishDeck> HandCardsAllowedToPlayNextMove;
    public bool isPlayer;
    public bool hasWon;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SpanishDeck PerformNextCardMove(SpanishDeck firstCardPlayed, SpanishDeck triumph, SpanishDeck? currentHandWinningCard=null)
    {
        CalculateLegalMoves(firstCardPlayed, triumph, currentHandWinningCard);
        int randomCard = Random.Range(0, HandCardsAllowedToPlayNextMove.Count);//se podria mejorar la toma de decision but whatever
        SpanishDeck selectedCard = HandCardsAllowedToPlayNextMove[randomCard];
        HandCards.Remove(selectedCard);
        return selectedCard;      
    }

            public void CalculateLegalMoves(SpanishDeck firstPlayedCard, SpanishDeck Triumph, SpanishDeck? currentHandWinningCard = null)
            {
                //from available cards, le aplicamos un "filtro": solo quedan las que asisten al palo
                if (currentHandWinningCard == null)
                {
                    this.HandCardsAllowedToPlayNextMove = this.HandCards;
                    return;
                }

                List<SpanishDeck> CardsThatFollowTheRule = HandCards.Where(x => GetSuit(x) == GetSuit(firstPlayedCard)).ToList();

                if (CardsThatFollowTheRule.Count > 0)
                {
                    if (GetSuit(firstPlayedCard) == GetSuit((SpanishDeck)currentHandWinningCard))
                    {
                        List<SpanishDeck> CardsThatHaveAHigherValue = CardsThatFollowTheRule.Where(x => GetCardValue(x) > GetCardValue((SpanishDeck)currentHandWinningCard)).ToList();
                        if (CardsThatHaveAHigherValue.Count > 0)
                        {
                            //le tienes que subir a la carta más alta
                            this.HandCardsAllowedToPlayNextMove = CardsThatHaveAHigherValue;
                            return;
                        }
                        else
                        {
                            //no puedes subirle a la carta más alta
                            this.HandCardsAllowedToPlayNextMove = CardsThatFollowTheRule;
                            return;
                        }
                    }
                    else
                    {
                        //alguien ha fallado pero sigues teniendo que asistir
                        this.HandCardsAllowedToPlayNextMove = CardsThatFollowTheRule;
                        return;
                    }
                }

                List<SpanishDeck> CardsThatAreTriumph = HandCards.Where(x => GetSuit(x) == GetSuit(Triumph)).ToList();

                if (CardsThatAreTriumph.Count > 0)
                {
                    if (GetSuit((SpanishDeck)currentHandWinningCard) == GetSuit(Triumph))
                    {
                        List<SpanishDeck> CardsThatAreTriumphAndAreBetterThanTheCurrentlyWinningCard = CardsThatAreTriumph.Where(x => GetCardValue(x) > GetCardValue((SpanishDeck)currentHandWinningCard)).ToList();
                        if (CardsThatAreTriumphAndAreBetterThanTheCurrentlyWinningCard.Count > 0)
                        {
                            //solo puedes echar un triunfo mayor al que está ganando ahora mismo
                            this.HandCardsAllowedToPlayNextMove = CardsThatAreTriumphAndAreBetterThanTheCurrentlyWinningCard;
                            return;
                        }
                        else
                        {
                            //si no tienes un triunfo mayor que el que está ganando, no tienes por qué echar triunfo
                            this.HandCardsAllowedToPlayNextMove = this.HandCards;
                            return;
                        }
                    }
                    //te permite echar cualquier triunfo
                    this.HandCardsAllowedToPlayNextMove = CardsThatAreTriumph;
                    return;
                }
                //at this point it doesn't restrict which card you play
                this.HandCardsAllowedToPlayNextMove = this.HandCards;
                return;
            }


    private SpanishSuit GetSuit(SpanishDeck card)
    {
        return EnumExtensions.GetSpanishSuit(card);
    }

    private int GetCardValue(SpanishDeck card)
    {
        return EnumExtensions.GetCardValue(card);
    }
}
