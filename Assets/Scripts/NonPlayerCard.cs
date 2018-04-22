using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NonPlayerCard : MonoBehaviour, Card.ICard, IJoinAcceptor, IPlayerControllable, IJoiner
{



    public float hitDurationStick = 0.1f;

    private float hitTime = 0.0f;
    private bool isJoined()
    {
        return hitObject != null;
    }


    private Transform hitObject = null;
    private TextMesh textMesh;
    private bool isPlayerControlled = false;
    private readonly List<IJoiner> joiners = new List<IJoiner>();

    public Card.Suit suit = Card.Suit.Spade;
    public Card.Value value = Card.Value.Ace;


    // Use this for initialization
    void Awake ()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        updateCardVisuals();
	}

    void OnValidate()
    {
        if (textMesh == null)
        {
            return;
        }
        updateCardVisuals();
    }


    void updateCardVisuals()
    {
        textMesh.color = Card.getColorForSuit(suit);
        textMesh.text = Card.getStringSymbolForValue(value) + "\n" + Card.getStringSymbolForSuit(suit);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hitObject != null)
        {
            hitTime += Time.deltaTime;
        }

        if (hitTime > hitDurationStick)
        {
            transform.parent = hitObject;
        }
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayerControlled)
        {
            return;
        }

        var joinAcceptor = other.gameObject.GetComponentInChildren<IJoinAcceptor>();

        if (joinAcceptor != null)
        {
            if (joinAcceptor.JoinRequest(this.gameObject))
            {
                hitObject = other.gameObject.transform;
            }
        }
    }

    /*
    void OnTriggerExit2D(Collider2D other)
    {
        var joinAcceptor = other.gameObject.GetComponentInChildren<IJoinAcceptor>();

        if (joinAcceptor != null)
        {
            if (joinAcceptor.JoinRequest(this.gameObject))
            {
                this.transform.parent = other.transform;
            }
        }
    }
    */

    Card.Suit Card.ICard.getCardSuit()
    {
        return suit;
    }

    Card.Value Card.ICard.getCardValue()
    {
        return value;
    }

    void Card.ICard.setCardSuit(Card.Suit s)
    {
        suit = s;
        updateCardVisuals();
    }

    void Card.ICard.setCardValue(Card.Value v)
    {
        value = v;
        updateCardVisuals();
    }

    bool IJoinAcceptor.JoinRequest(GameObject g)
    {
        var otherCard = g.GetComponentInChildren<Card.ICard>();
        var otherJoiner = g.GetComponentInChildren<IJoiner>();
        var otherPc = g.GetComponentInChildren<IPlayerControllable>();

        if (otherCard == null || otherJoiner == null || otherPc == null)
        {
            return false;
        }

        if (!Card.canConnect(this, otherCard))
        {
            return false;
        }

        // Decide parenting in two card non player collision case
        if (isPlayerControlled || Card.isLarger(this, otherCard))
        {
            if (isPlayerControlled)
            {
                otherPc.startControl();
            }
            joiners.Add(otherJoiner);
            return true;
        }

        return false;
    }

    public void startControl()
    {
        isPlayerControlled = true;
    }

    public void stopControl()
    {
        isPlayerControlled = false;
    }

    List<IJoiner> IJoiner.getNextLinks()
    {
        return joiners;
    }
}
