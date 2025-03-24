using Assets.Scripts;
using System;
using UnityEngine;

public enum Deck
{
    Spanish,
    French
}
public class CardUtils
{
    [Obsolete]
    public static string GetSpriteForSpanishDeckCard(SpanishDeck Card)
    {
       throw new NotImplementedException();
    }

    [Obsolete]
    public static string GetSpriteForFrenchDeckCard(FrenchDeck Card)
    {
        throw new NotImplementedException();
    }

    public static int GetTuteValueForSpanishDeckCard(SpanishDeck Card)
    {
        var field = typeof(SpanishDeck).GetField(Card.ToString());
        var attribute_sp = (EnumValueAttribute)Attribute.GetCustomAttribute (field, typeof(EnumValueAttribute));
        return attribute_sp?.TuteValue ?? 0;
    }
}
