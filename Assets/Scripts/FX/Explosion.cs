using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    [SerializeField] private float lifeTime;

    public float LifeTime { get => lifeTime; set => lifeTime = value; }

    void Start() {
        Destroy(gameObject, lifeTime);
    }
}
