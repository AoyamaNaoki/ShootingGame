using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ObjectBase {
    public override void Start() {
        base.Start();
    }

    protected void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            TriggerByPlayer();
        }else if(col.gameObject.tag == "Enemy") {
            TriggerByEnemy();
        }
        Destroy(gameObject);
    }

    public virtual void TriggerByPlayer() {
        //アイテム獲得のエフェクトプレハブ
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    }

    public virtual void TriggerByEnemy() {
    }
}
