using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : Character {

    [Header("[Player]")]
    [Space(5)]
    [SerializeField] private float padding = 0.3f;
    [SerializeField] private const float LEAN_DURATION = 1.25f;
    [SerializeField] private GameObject diceChild;
    [SerializeField] private static int diceNum = 4;
    [SerializeField] private Dictionary<int, Vector3> diceEulerDict = new Dictionary<int, Vector3>() { { 1, new Vector3(90, -90, 0) }, { 2, new Vector3(-90, 0, 0) }, { 3, new Vector3(0, 180, 0) }, { 4, new Vector3(0, 0, 0) }, { 5, new Vector3(90, 0, 0) }, { 6, new Vector3(90, 90, 0) } };
    [SerializeField] private Dictionary<int, float> diceSpeedDict = new Dictionary<int, float>() { { 1, 5f }, { 2, 7.5f }, { 3,9.0f }, { 4, 11f }, { 5, 12.5f }, { 6, 15f } };
    [SerializeField] private GameObject playerShootActivator;

    public float Padding { get => padding; set => padding = value; }
    public GameObject DiceChild { get => diceChild; set => diceChild = value; }
    public static int DiceNum { get => diceNum; set => diceNum = value; }
    public Dictionary<int, Vector3> DiceEulerDict { get => diceEulerDict; set => diceEulerDict = value; }
    public Dictionary<int, float> DiceSpeedDict { get => diceSpeedDict; set => diceSpeedDict = value; }
    public GameObject PlayerShootActivator { get => playerShootActivator; set => playerShootActivator = value; }

    public static float LEAN_DURATION1 => LEAN_DURATION;

    public override void Start() {
        base.Start();
        Roll();
    }

    public override void Update() {
        base.Update();
        Clamp();
        Move();
        if (Input.GetButtonDown("Roll")) Roll();
    }

    public override void Move() {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(xInput, yInput, 0);
        transform.Translate(direction * Time.deltaTime * Speed);
        Lean(xInput, yInput);
    }

    public void Clamp() {
        var minPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        var maxPosd = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, minPos.x + Padding, maxPosd.x - Padding);
        newPos.y = Mathf.Clamp(newPos.y, minPos.y +Padding, maxPosd.y - Padding);
        transform.position = newPos;
    }

    public void Lean(float xInput,float yInput) {
        if(xInput > 0) {
            DiceChild.transform.DORotate(new Vector3(0,-30, 0) + diceEulerDict[DiceNum], LEAN_DURATION1);
        }else if(xInput < 0) {
            DiceChild.transform.DORotate(new Vector3(0, 30, 0) + diceEulerDict[DiceNum], LEAN_DURATION1);
        } else {
            DiceChild.transform.DORotate(diceEulerDict[DiceNum], LEAN_DURATION1/2);
        }
    }

    public void Roll() {
        DiceNum = Random.Range(1, 7);
        Speed = DiceSpeedDict[DiceNum];
        DiceChild.transform.DORotate(DiceEulerDict[DiceNum], 1.0f);
        PlayerShootActivator.GetComponent<PlayerShootActivator>().SetDiceMainShoot();
    }
}
