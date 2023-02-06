using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource explorationMusic;
    public AudioSource combatMusic;
    public float musicAdaptSpeedSeconds = 1.0f;

    public static MusicManager instance;

    private float targetCombatLevel = 0.0f;

    private void Awake()
    {
        instance = this;
        SetCombatLevel(0.0f);
        explorationMusic.volume = 1.0f;
        combatMusic.volume = 0.0f;
    }

    private void Update()
    {
        explorationMusic.volume = Mathf.MoveTowards(explorationMusic.volume, 1.0f - targetCombatLevel, Time.deltaTime / musicAdaptSpeedSeconds);
        combatMusic.volume = Mathf.MoveTowards(combatMusic.volume, targetCombatLevel, Time.deltaTime / musicAdaptSpeedSeconds);
    }

    public void SetCombatLevel(float target)
    {
        targetCombatLevel = target;
    }
}
