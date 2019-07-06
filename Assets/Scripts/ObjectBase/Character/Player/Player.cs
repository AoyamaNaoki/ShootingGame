using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : Character {

    [Header("[Player]")]
    [Space(5)]
    [SerializeField] private GameObject diceChild;
    [SerializeField] private static int diceNum = 4;
    [SerializeField] private Dictionary<int, Vector3> diceEulerDict = new Dictionary<int, Vector3>() { { 1, new Vector3(90, -90, 0) }, { 2, new Vector3(-90, 0, 0) }, { 3, new Vector3(180, 0, 0) }, { 4, new Vector3(0, 0, 0) }, { 5, new Vector3(90, 0, 0) }, { 6, new Vector3(90, 90, 0) } };
    [SerializeField] private Dictionary<int, float> diceSpeedDict = new Dictionary<int, float>() { { 1, 2 }, { 2, 4 }, { 3, 6 }, { 4, 8 }, { 5, 10 }, { 6, 12 } };
    [SerializeField] private GameObject playerShootActivator;

    public GameObject DiceChild { get => diceChild; set => diceChild = value; }
    public Dictionary<int, Vector3> DiceEuler { get => diceEulerDict; set => diceEulerDict = value; }
    public static int DiceNum { get => diceNum; set => diceNum = value; }
    public Dictionary<int, float> DiceSpeedDict { get => diceSpeedDict; set => diceSpeedDict = value; }
    public GameObject PlayerShootActivator { get => playerShootActivator; set => playerShootActivator = value; }

    public override void Start() {
        base.Start();
        Roll();
    }

    public override void Update() {
        base.Update();
        Move();
    }

    public override void Move() {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(xInput, yInput, 0);
        transform.Translate(direction * Time.deltaTime * Speed);
        if (Input.GetButtonDown("Roll")) Roll();
    }

    public void Roll() {
        DiceNum = Random.Range(1, 7);
        Speed = DiceSpeedDict[DiceNum];
        DiceChild.transform.DORotate(DiceEuler[DiceNum], 1.0f);
        PlayerShootActivator.GetComponent<PlayerShootActivator>().SetDiceMainShoot();
    }
}
