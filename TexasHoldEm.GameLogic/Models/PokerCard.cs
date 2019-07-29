using System;
using System.IO;
using TexasHoldEm.GameLogic.Core;

namespace TexasHoldEm.GameLogic.Models
{
    public class PokerCard : IComparable<PokerCard>
    {
        public int Value { get; }
        public PokerCardColor Color { get; }

        public PokerCard(string sourceCardString)
        {
            var valueString = sourceCardString.Substring(0, 1);
            var colorString = sourceCardString.Substring(1, 1);
            if (!int.TryParse(valueString, out var value))
            {
                switch (valueString)
                {
                    case "T":
                        value = 10;
                        break;
                    case "J":
                        value = 11;
                        break;
                    case "Q":
                        value = 12;
                        break;
                    case "K":
                        value = 13;
                        break;
                    case "A":
                        value = 14;
                        break;
                    default:
                        throw new ArgumentException(valueString + " is not a valid value!");
                }
            }
            Value = value;

            if (!Enum.TryParse<PokerCardColor>(colorString, out var color))
            {
                throw new ArgumentException(colorString + " is not a valid color!");
            }
            Color = color;
        }
        
        public int CompareTo(PokerCard other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return Value.CompareTo(other.Value);
        }

        public bool IsSameColor(PokerCard other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return Color.Equals(other.Color);
        }

        public string ToCardValueString()
        {
            if (Value < 10)
            {
                return Value.ToString();
            }

            switch (Value)
            {
                case 10:
                    return "T";
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                case 14:
                    return "Ace";
                default:
                    throw new InvalidDataException();
            }
        }
    }
}