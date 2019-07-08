using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : Item {
    public enum CardMarkEnum : byte {
        Spade = 1,
        Heart = 2,
        Diamond = 3,
        Club = 4,
        Joker = 5,
    }
    public enum CardNumberEnum : byte {
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
        Joker = 14,
    }

    [Header("[Card]")]
    [Space(5)]
    [SerializeField] private CardMarkEnum cardMark;
    [SerializeField] private CardNumberEnum cardNumber;


    public CardMarkEnum CardMark { get => cardMark; set => cardMark = value; }
    public CardNumberEnum CardNumber { get => cardNumber; set => cardNumber = value; }

    public override void Start() {
        base.Start();
    }

    public override void TriggerByPlayer() {
        GameMode.AddCardToSlot(gameObject);
        base.TriggerByPlayer();
    }

    public override void TriggerByEnemy() {
        base.TriggerByEnemy();
    }
}
