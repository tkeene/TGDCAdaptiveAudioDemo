using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public Collider myCollider;

    // Dictionary.TryGet() is going to be more performant than GameObject.GetComponent()
    public static Dictionary<Collider, MusicTrigger> activeMusicTriggers = new Dictionary<Collider, MusicTrigger>();

    private void OnEnable()
    {
        activeMusicTriggers[myCollider] = this;
    }

    private void OnDisable()
    {
        activeMusicTriggers.Remove(myCollider);
    }
}
