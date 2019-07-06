using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootActivator : Shooter {

    [SerializeField] private List<GameObject> childShooterList = new List<GameObject>();
    [SerializeField] private List<List<GameObject>> grandChildShooterList = new List<List<GameObject>>();

    public List<GameObject> ChildShooterList { get => childShooterList; set => childShooterList = value; }
    public List<List<GameObject>> GrandChildShooterList { get => grandChildShooterList; set => grandChildShooterList = value; }

    public void SetDiceMainShoot() {
        if (ChildShooterList.Count == 0) {
            GetChildShooter();
            GetGrandChildShooterList();
        }
        GrandChildShooterList.ForEach(GrandChildShooterList2 => {
            GrandChildShooterList2.ForEach(grandChildShooter => { grandChildShooter.GetComponent<ParticlePlayer>().enabled = false; });
        });
        GrandChildShooterList[Player.DiceNum].ForEach(grandChildShooter => { grandChildShooter.GetComponent<ParticlePlayer>().enabled = true; });

        GetComponent<ParticlePlayer>().enabled = true;
        //ChildShooterList.ForEach(u => u.GetComponent<ParticlePlayer>().enabled = false);
        //ChildShooterList[Player.DiceNum - 1].GetComponent<ParticlePlayer>().enabled = true;
    }

    public void GetChildShooter() {
        for (int i = 0; i < 6; i++) {
            ChildShooterList.Add(transform.GetChild(i).gameObject);
        }
    }

    public void GetGrandChildShooterList() {
        for (int i = 0; i < ChildShooterList.Count; i++) {
            ChildShooterList.ForEach(childShooter => { GrandChildShooterList[i].Add(childShooter); });
        }
    }
}
