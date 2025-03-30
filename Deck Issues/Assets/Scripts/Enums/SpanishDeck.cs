using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets.Scripts
{
    public enum SpanishSuit
    {
        NONE=-1,
        OROS=0,
        COPAS=1,
        ESPADAS=2,
        BASTOS=3,
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EnumValueAttribute : Attribute
    {
        public int CardValueInsideSuit { get; }
        public SpanishSuit SpanishSuit { get; }

       
        public EnumValueAttribute(int CardValueInsideSuit)
        {
            this.CardValueInsideSuit = CardValueInsideSuit;
        }

        public EnumValueAttribute(SpanishSuit SpanishSuit)
        {
            this.SpanishSuit = SpanishSuit;
        }
    }
    public enum SpanishDeck
    {
        [EnumValue(10)]
        [EnumValue(SpanishSuit.OROS)]
        AS_DE_OROS = 0,

        [EnumValue(1)]
        [EnumValue(SpanishSuit.OROS)]
        DOS_DE_OROS = 1,

        [EnumValue(9)]
        [EnumValue(SpanishSuit.OROS)]
        TRES_DE_OROS = 2,

        [EnumValue(2)]
        [EnumValue(SpanishSuit.OROS)]
        CUATRO_DE_OROS = 3,

        [EnumValue(3)]
        [EnumValue(SpanishSuit.OROS)]
        CINCO_DE_OROS = 4,

        [EnumValue(4)]
        [EnumValue(SpanishSuit.OROS)]
        SEIS_DE_OROS = 5,

        [EnumValue(5)]
        [EnumValue(SpanishSuit.OROS)]
        SIETE_DE_OROS = 6,

        [EnumValue(6)]
        [EnumValue(SpanishSuit.OROS)]
        SOTA_DE_OROS = 7,

        [EnumValue(7)] 
        [EnumValue(SpanishSuit.OROS)] 
        CABALLO_DE_OROS = 8,

        [EnumValue(8)] 
        [EnumValue(SpanishSuit.OROS)] 
        REY_DE_OROS = 9,

        [EnumValue(10)]
        [EnumValue(SpanishSuit.COPAS)] 
        AS_DE_COPAS = 10,

        [EnumValue(1)]
        [EnumValue(SpanishSuit.COPAS)]
        DOS_DE_COPAS = 11,
        
        [EnumValue(9)]
        [EnumValue(SpanishSuit.COPAS)]
        TRES_DE_COPAS = 12,

        [EnumValue(2)]
        [EnumValue(SpanishSuit.COPAS)]
        CUATRO_DE_COPAS = 13,

        [EnumValue(3)]
        [EnumValue(SpanishSuit.COPAS)]
        CINCO_DE_COPAS = 14,

        [EnumValue(4)]
        [EnumValue(SpanishSuit.COPAS)]
        SEIS_DE_COPAS = 15,

        [EnumValue(5)]
        [EnumValue(SpanishSuit.COPAS)]
        SIETE_DE_COPAS = 16,

        [EnumValue(6)]
        [EnumValue(SpanishSuit.COPAS)]
        SOTA_DE_COPAS = 17,

        [EnumValue(7)]
        [EnumValue(SpanishSuit.COPAS)]
        CABALLO_DE_COPAS = 18,

        [EnumValue(8)]
        [EnumValue(SpanishSuit.COPAS)]
        REY_DE_COPAS = 19,

        [EnumValue(10)]
        [EnumValue(SpanishSuit.ESPADAS)]
        AS_DE_ESPADAS = 20,

        [EnumValue(1)]
        [EnumValue(SpanishSuit.ESPADAS)]
        DOS_DE_ESPADAS = 21,

        [EnumValue(9)]
        [EnumValue(SpanishSuit.ESPADAS)]
        TRES_DE_ESPADAS = 22,

        [EnumValue(2)]
        [EnumValue(SpanishSuit.ESPADAS)]
        CUATRO_DE_ESPADAS = 23,

        [EnumValue(3)]
        [EnumValue(SpanishSuit.ESPADAS)]
        CINCO_DE_ESPADAS = 24,

        [EnumValue(4)]
        [EnumValue(SpanishSuit.ESPADAS)]
        SEIS_DE_ESPADAS = 25,

        [EnumValue(5)]
        [EnumValue(SpanishSuit.ESPADAS)]
        SIETE_DE_ESPADAS = 26,

        [EnumValue(6)]
        [EnumValue(SpanishSuit.ESPADAS)]
        SOTA_DE_ESPADAS = 27,

        [EnumValue(7)]
        [EnumValue(SpanishSuit.ESPADAS)]
        CABALLO_DE_ESPADAS = 28,

        [EnumValue(8)] 
        [EnumValue(SpanishSuit.ESPADAS)]
        REY_DE_ESPADAS = 29,

        [EnumValue(10)]
        [EnumValue(SpanishSuit.BASTOS)] 
        AS_DE_BASTOS = 30,

        [EnumValue(1)]
        [EnumValue(SpanishSuit.BASTOS)]
        DOS_DE_BASTOS = 31,

        [EnumValue(9)]
        [EnumValue(SpanishSuit.BASTOS)]
        TRES_DE_BASTOS = 32,

        [EnumValue(2)]
        [EnumValue(SpanishSuit.BASTOS)]
        CUATRO_DE_BASTOS = 33,

        [EnumValue(3)]
        [EnumValue(SpanishSuit.BASTOS)]
        CINCO_DE_BASTOS = 34,

        [EnumValue(4)]
        [EnumValue(SpanishSuit.BASTOS)]
        SEIS_DE_BASTOS = 35,

        [EnumValue(5)]
        [EnumValue(SpanishSuit.BASTOS)]
        SIETE_DE_BASTOS = 36,

        [EnumValue(6)]
        [EnumValue(SpanishSuit.BASTOS)]
        SOTA_DE_BASTOS = 37,

        [EnumValue(7)]
        [EnumValue(SpanishSuit.BASTOS)]
        CABALLO_DE_BASTOS = 38,

        [EnumValue(8)]
        [EnumValue(SpanishSuit.BASTOS)]
        REY_DE_BASTOS = 39
    }
}
