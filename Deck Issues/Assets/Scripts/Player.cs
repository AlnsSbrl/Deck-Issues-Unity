using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    
    public List<Card> HandCards;
    public List<Card> HandCardsAllowedToPlayNextMove;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateAllowedNextMove()
    {
        throw new System.NotImplementedException();
    }

    public void PlayCardFromAllowed()
    {
        throw new System.NotImplementedException();
    }
}
