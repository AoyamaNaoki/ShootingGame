using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ObjectBase{
    public virtual void Move() { }

    public float CalculateExplosionScaleRate() {
        var myScale = transform.localScale;
        var maxScale = Mathf.Max(myScale.x, myScale.y);
        var minScale = Mathf.Min(myScale.x, myScale.y);
        var scaleRate = Mathf.Sqrt((maxScale * maxScale) + (minScale * minScale));
        return scaleRate;
    }
}
