﻿namespace PaydayDecks.Abstracts;

using ModdingUtils.MonoBehaviours;
using ModsPlus;
using System.Collections;
using System.Net.Mime;
using TMPro;
using UnboundLib.GameModes;
using UnityEngine;

public abstract class AbilityEffect : CardEffect
{
    public abstract float cooldown { get; }
    public abstract float duration { get; }
    private float lastUsed;
    private bool canUse = true;
    private bool active = false;

    public bool IsActive() => active;

    private void Update()
    {
        if (!canUse)
            if ((Time.time >= lastUsed + cooldown))
                canUse = true;
        
        if (active)
            if (Time.time > lastUsed + duration)
            {
                active = false;
                EndAbility();
            }
    }

    protected override void OnDestroy()
    {
        Reset();
        base.OnDestroy();
    }

    public override void OnBlock(BlockTrigger.BlockTriggerType blockTriggerType)
    {
        if (blockTriggerType != BlockTrigger.BlockTriggerType.Default)
            return;
        if (active)
            return;
        if (!canUse)
            return;
        lastUsed = Time.time;
        canUse = false;
        active = true;
        
        StartAbility();
    }

    protected virtual void StartAbility()
    { }

    protected virtual void EndAbility()
    { }

    protected virtual void Reset()
    { }

    public override IEnumerator OnBattleStart(IGameModeHandler gameModeHandler)
    {
        canUse = true;
        active = false;
        lastUsed = 0f;
        Reset();
        yield break;
    }
    
    
}