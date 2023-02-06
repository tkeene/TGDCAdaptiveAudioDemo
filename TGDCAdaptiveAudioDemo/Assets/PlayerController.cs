using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 5.0f;

    Collider[] cachedColliderArray = new Collider[32];
    void Update()
    {
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            input += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector3.right;
        }
        transform.position += input * moveSpeed * Time.deltaTime;

        float currentCombatLevel = 0.0f;
        Physics.queriesHitTriggers = true;
        int numberOfColliders = Physics.OverlapBoxNonAlloc(transform.position, Vector3.one * 0.5f,
            cachedColliderArray);
        for (int i = 0; i < numberOfColliders; i++)
        {
            if (MusicTrigger.activeMusicTriggers.TryGetValue(cachedColliderArray[i], out MusicTrigger musicTrigger))
            {
                currentCombatLevel = 1.0f;
            }
        }
        MusicManager.instance.SetCombatLevel(currentCombatLevel);
    }
}
