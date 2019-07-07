using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootActivator : Shooter {

    private Dictionary<int, GameObject> childDict = new Dictionary<int, GameObject>();
    private Dictionary<int, List<GameObject>> grandChildListDict = new Dictionary<int, List<GameObject>>();
    private Dictionary<int, int> grandChildListCount = new Dictionary<int, int>();

    public void SetDiceMainShoot() {
        if (childDict.Count == 0 || grandChildListDict[Player.DiceNum].Count == 0) {
            GetChildShooter();
        }
        for (int i = 1; i <= grandChildListDict.Count; i++) {
            grandChildListDict[i].ForEach(grandChild => { grandChild.GetComponent<ParticlePlayer>().enabled = false; });
        }
        grandChildListDict[Player.DiceNum].ForEach(grandChild => { grandChild.GetComponent<ParticlePlayer>().enabled = true; });
    }

    #pragma warning disable 612, 618
    public void GetChildShooter() {
        var childCount = gameObject.transform.GetChildCount();
        for (int i = 1; i <= childCount; i++) {
            childDict[i] = gameObject.transform.GetChild(i - 1).gameObject;
        }
        for (int i = 1; i <= childDict.Count; i++) {
            grandChildListCount[i] = childDict[i].transform.GetChildCount();
        }
        for (int i = 1; i <= childDict.Count; i++) {
            List<GameObject> List1 = new List<GameObject>();
            for (int j = 0; j < grandChildListCount[i]; j++) {
                List1.Add(childDict[i].transform.GetChild(j).gameObject);
            }
            grandChildListDict[i] = List1;
        }
    }
    #pragma warning restore 612, 618
}
