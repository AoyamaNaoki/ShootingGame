using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ObjectBase {

    void OnParticleCollision(GameObject c) {
        if(Hp <= 0) {
            Debug.Log("Enemy hit bullet");
            Destroy(gameObject);
        }
    }
}
