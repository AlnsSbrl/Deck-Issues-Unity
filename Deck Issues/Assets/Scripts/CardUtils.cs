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
    public static string GetSpriteForSpanishDeckCard(SpanishDeck Card)
    {
        var field_sp = typeof(SpanishDeck).GetField(Card.ToString());
        var attribute_sp = (EnumValueAttribute)Attribute.GetCustomAttribute(field_sp, typeof(EnumValueAttribute));
        return attribute_sp?.Value?? string.Empty;
    }

    public static string GetSpriteForFrenchDeckCard(FrenchDeck Card)
    {
        throw new NotImplementedException();
    }
}
