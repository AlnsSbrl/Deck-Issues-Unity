using Assets.Scripts;
using System;
using UnityEngine;

public class Card
{
    public int CardValue;

    public Card(SpanishDeck cardValue)
    {
        CardValue = (int)cardValue;
    }
    public Card(FrenchDeck cardValue)
    {
        CardValue = (int)cardValue;
    }

    public string GetCardSpritePath()
    {
        throw new NotImplementedException();
    }
    
}
