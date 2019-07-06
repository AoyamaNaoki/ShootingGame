using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour {
    private float count = 0;
    [SerializeField] private float shotRate = 0.25f;
    [SerializeField] private int attackPower = 1;
    [SerializeField] private ParticleSystem particleSystem;

    public float ShotRate { get => shotRate; set => shotRate = value; }
    public int AttackPower { get => attackPower; set => attackPower = value; }
    public ParticleSystem ParticleSystem { get => particleSystem; set => particleSystem = value; }

    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Update() {
        count += Time.deltaTime;
        if (Input.GetButton("Fire1") && ShotRate < count) {
            particleSystem.Play();
            count = 0;
        }
    }

    void OnParticleCollision(GameObject c) {
        c.gameObject.GetComponent<Enemy>().Hp -= attackPower;
        Debug.Log("Attacked by Particle");
    }
}
