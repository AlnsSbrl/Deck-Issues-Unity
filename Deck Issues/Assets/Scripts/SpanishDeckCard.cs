using Assets.Scripts;
using Assets.Scripts.Enums;
using System;
using UnityEngine;

public class SpanishDeckCard : MonoBehaviour
{

    [SerializeField]
    public Sprite[] Deck;
    [SerializeField]
    public Sprite[] CardsBack;
    [SerializeField]
    public int CardsBackIndexUsed;

    public bool IsFromPlayer;
    public SpanishDeck SpanishDeck;
    private SpriteRenderer _SpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();  
        _SpriteRenderer.sprite = CardsBack[CardsBackIndexUsed]; //enseña el dorso
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            int nextCard = UnityEngine.Random.Range(0, Deck.Length);
            ChangeCard(nextCard);
            Debug.Log($"Next card value: {EnumExtensions.GetCardValue(SpanishDeck)} with suit: {EnumExtensions.GetSpanishSuit(SpanishDeck)}");
        }
    }

    public void ChangeCard(int num)
    {
        if (num >= Deck.Length || num<0)
        {
            return;
        }
        SpanishDeck = (SpanishDeck)num;
        _SpriteRenderer.sprite = Deck[num];       
    }

    private void MoveCardToCenterOfTheScreenAfterBeeingUsed()
    {
        //TODO
        //this happens after an OnClick action on the card
        //but doesnt happen when the card is not from a player OR the move is not allowed
        //it flips and throws the card into the closest point of an inner circle on the center of the screen
        //TODO: DEFINE SAID CIRCLE, invisible, surrounding the space where the card to deal cards (and triumphs) are displayed

    }

    private void GetCardValueByGame()
    {

    }
    //TODO metodo para conseguir puntuacion/valor de la carta segun qué juego
    //hay juegos donde el valor de la carta ingame no es el mismo valor que luego se contabiliza postgame, ejemplo: tute
    //en el tute, 7 tiene un valor intrinseco superior a 4, pero al final de la partida, ninguna de las dos cartas posee valor
    //por lo que hay que guardar informacion diferenciada de estos casos y no confundirlos
    
}
