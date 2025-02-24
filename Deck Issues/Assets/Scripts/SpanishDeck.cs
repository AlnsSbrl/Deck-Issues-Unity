using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class EnumValueAttribute : Attribute
    {
        public string Value { get; }
        public EnumValueAttribute(string value)
        {
            Value = value;
        }
    }
    public enum SpanishDeck
    {
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_AS.png")]
        AS_DE_OROS = 1,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_DOS.png")]
        DOS_DE_OROS = 2,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_TRES.png")]
        TRES_DE_OROS = 3,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_CUATRO.png")]
        CUATRO_DE_OROS = 4,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_CINCO.png")]
        CINCO_DE_OROS = 5,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_SEIS.png")]
        SEIS_DE_OROS = 6,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_SIETE.png")]
        SIETE_DE_OROS = 7,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_SOTA.png")]
        SOTA_DE_OROS = 8,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_CABALLO.png")]
        CABALLO_DE_OROS = 9,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OROS_REY.png")]
        REY_DE_OROS = 10,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_AS.png")]
        AS_DE_COPAS = 11,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_DOS.png")]
        DOS_DE_COPAS = 12,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\OPAS_TRES.png")]
        TRES_DE_COPAS = 13,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_CUATRO.png")]
        CUATRO_DE_COPAS = 14,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_CINCO.png")]
        CINCO_DE_COPAS = 15,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_SEIS.png")]
        SEIS_DE_COPAS = 16,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_SIETE.png")]
        SIETE_DE_COPAS = 17,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_SOTA.png")]
        SOTA_DE_COPAS = 18,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_CABALLO.png")]
        CABALLO_DE_COPAS = 19,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\COPAS_REY.png")]
        REY_DE_COPAS = 20,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_AS.png")]
        AS_DE_ESPADAS = 21,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_DOS.png")]
        DOS_DE_ESPADAS = 22,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_TRES.png")]
        TRES_DE_ESPADAS = 23,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_CUATRO.png")]
        CUATRO_DE_ESPADAS = 24,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_CINCO.png")]
        CINCO_DE_ESPADAS = 25,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_SEIS.png")]
        SEIS_DE_ESPADAS = 26,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_SIETE.png")]
        SIETE_DE_ESPADAS = 27,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_SOTA.png")]
        SOTA_DE_ESPADAS = 28,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_CABALLO.png")]
        CABALLO_DE_ESPADAS = 29,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\ESPADAS_REY.png")]
        REY_DE_ESPADAS = 30,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_AS.png")]
        AS_DE_BASTOS = 31,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_DOS.png")]
        DOS_DE_BASTOS = 32,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_TRES.png")]
        TRES_DE_BASTOS = 33,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_CUATRO.png")]
        CUATRO_DE_BASTOS = 34,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_CINCO.png")]
        CINCO_DE_BASTOS = 35,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_SEIS.png")]
        SEIS_DE_BASTOS = 36,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_SIETE.png")]
        SIETE_DE_BASTOS = 37,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_SOTA.png")]
        SOTA_DE_BASTOS = 38,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_CABALLO.png")]
        CABALLO_DE_BASTOS = 39,
        [EnumValue("\\Assets\\Sprites\\Cartas\\SpanishDeck\\BASTOS_REY.png")]
        REY_DE_BASTOS = 40
    }
}
