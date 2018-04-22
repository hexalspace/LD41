using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IPlayerControllable
{
    void startControl();
    void stopControl();
}

public interface IJoinAcceptor
{
    bool JoinRequest(GameObject g);
}

public interface IJoiner
{
    List<IJoiner> getNextLinks();
}

public static class Card
{
    public interface ICard
    {
        Suit getCardSuit();
        Value getCardValue();

        void setCardSuit(Suit s);
        void setCardValue(Value v);
    }

    public enum Suit
    {
        Spade = 0,
        Club = 1,
        Diamond = 2,
        Heart = 3,
    }

    public enum Value
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }

    public static bool isLarger(ICard a, ICard b)
    {
        var aSuitInt = (int)a.getCardSuit();
        var bSuitInt = (int)b.getCardSuit();

        var aValueInt = (int)a.getCardValue();
        var bValueInt = (int)b.getCardValue();

        if (aSuitInt > bSuitInt)
        {
            return true;
        }
        else if (aSuitInt < bSuitInt)
        {
            return false;
        }
        else
        {
            if (aValueInt > bValueInt)
            {
                return true;
            }
            else if (aValueInt < bValueInt)
            {
                return false;
            }
            else
            {
                // defaults to idea that equality is not larger
                return false;
            }
        }
    }

    public static bool canConnect(ICard a, ICard b)
    {
        return areValuesAdjacent(a.getCardValue(), b.getCardValue()) && areOppositeColors(a.getCardSuit(), b.getCardSuit());
    }

    public static bool areValuesAdjacent(Value a, Value b)
    {
        int aInt = (int)a;
        int bInt = (int)b;

        if (a == Value.King && b == Value.Ace)
        {
            return true;
        }
        else if (b == Value.King && a == Value.Ace)
        {
            return true;
        }
        else if ( aInt + 1 == bInt || aInt - 1 == bInt)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool areOppositeColors(Suit a, Suit b)
    {
        var aColor = getColorForSuit(a);
        var bColor = getColorForSuit(b);

        return aColor != bColor;
    }

    public static Color getColorForSuit(Suit s)
    {
        switch (s)
        {
            case Suit.Spade:
            case Suit.Club:
                return Color.black;
            case Suit.Diamond:
            case Suit.Heart:
                return Color.red;
            default:
                throw new Exception("Invalid suit: " + s);
        }
    }

    public static string getStringSymbolForValue(Value v)
    {
        switch (v)
        {
            case Value.Ace:
                return "A";
            case Value.Two:
                return "2";
            case Value.Three:
                return "3";
            case Value.Four:
                return "4";
            case Value.Five:
                return "5";
            case Value.Six:
                return "6";
            case Value.Seven:
                return "7";
            case Value.Eight:
                return "8";
            case Value.Nine:
                return "9";
            case Value.Ten:
                return "10";
            case Value.Jack:
                return "J";
            case Value.Queen:
                return "Q";
            case Value.King:
                return "K";
            default:
                throw new Exception("Invalid value: " + v);
        }
    }

    public static string getStringSymbolForSuit(Suit s)
    {
        switch (s)
        {
            case Suit.Spade:
                return "♠";
            case Suit.Club:
                return "♣";
            case Suit.Diamond:
                return "♦";
            case Suit.Heart:
                return "♠";
            default:
                throw new Exception("Invalid suit: " + s);
        }
    }
}