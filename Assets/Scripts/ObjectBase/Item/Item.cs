using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ObjectBase {
    public override void Start() {
        base.Start();
    }

    public void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            CollisionWithPlayer();
        }
    }

    public virtual void CollisionWithPlayer() {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity); // 爆発ではなくアイテム獲得のエフェクトプレハブ
        Destroy(gameObject);
    }
}
