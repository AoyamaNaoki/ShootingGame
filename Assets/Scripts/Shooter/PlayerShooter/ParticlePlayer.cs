using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour {
    private float count = 0;
    [SerializeField] private float shotRate = 0.25f;
    [SerializeField] private ParticleSystem particleSystem;

    public ParticleSystem ParticleSystem { get => particleSystem; set => particleSystem = value; }
    public float ShotRate { get => shotRate; set => shotRate = value; }

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
}
