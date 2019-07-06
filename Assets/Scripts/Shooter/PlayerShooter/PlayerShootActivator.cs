using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootActivator : Shooter {

    [SerializeField]private List<GameObject> childShooterList = new List<GameObject>();

    public void Update() {
        if (Input.GetButtonDown("Roll")) {
            SetDiceMainShoot();
        }
    }

    public  void SetDiceMainShoot() {
        if(childShooterList.Count == 0) {
            GetChildShooter();
        }
        childShooterList.ForEach(u => u.GetComponent<ParticlePlayer>().enabled = false);
        childShooterList[Player.DiceNum - 1].GetComponent<ParticlePlayer>().enabled = true;
    }

    public void GetChildShooter() {
        for (int i = 0; i < 6; i++) {
            childShooterList.Add(transform.GetChild(i).gameObject);
        }
    }
}
