using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    void OnParticleCollision(GameObject c) {
        if(Hp <= 0) {
            GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity) as GameObject;
            explosion.transform.localScale *= CalculateExplosionScaleRate() / 2;
            Destroy(gameObject);
            UIManager.AddScore(Point);
        }
    }
}
