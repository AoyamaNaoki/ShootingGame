using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour {
    [Header("[Object Base]")]
    [Space(5)]
    [SerializeField] private int hp = 1;
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosionPrefab;

    public int Hp { get => hp; set => hp = value; }
    public float Speed { get => speed; set => speed = value; }
    public GameObject ExplosionPrefab { get => explosionPrefab; set => explosionPrefab = value; }

    public virtual void Start() { }
    public virtual void Update() { }
}