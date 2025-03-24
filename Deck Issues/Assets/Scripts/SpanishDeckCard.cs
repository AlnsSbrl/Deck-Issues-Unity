using Assets.Scripts;
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

    public int value;
    public SpanishSuit SpanishSuit;
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
            Debug.Log($"Next card value: {this.value} with suit: {this.SpanishSuit}");
        }
    }

    public void ChangeCard(int num)
    {
        if (num >= Deck.Length || num<0)
        {
            return;
        }
        this.value = num;
        _SpriteRenderer.sprite = Deck[num];
        int suit = num / 10;
        Debug.Log(suit);
        this.SpanishSuit = (SpanishSuit)Enum.GetValues(typeof(SpanishSuit)).GetValue(suit);


    }


    private void GetCardValueByGame()
    {

    }
    //TODO metodo para conseguir puntuacion/valor de la carta segun qué juego
    //hay juegos donde el valor de la carta ingame no es el mismo valor que luego se contabiliza postgame, ejemplo: tute
    //en el tute, 7 tiene un valor intrinseco superior a 4, pero al final de la partida, ninguna de las dos cartas posee valor
    //por lo que hay que guardar informacion diferenciada de estos casos y no confundirlos
    
}
