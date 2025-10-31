using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffSystem : MonoBehaviour, IEffectable
{
    [SerializeField] PlayerHealthSystem health;
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerMeleeAttack meleeAttack;
    Dictionary<BuffDataSO, float> buffs = new();
    List<BuffDataSO> removeBuff = new();


    void Update()
    {
        HandleEffect();
    }

    void HandleEffect()
    {
        if (buffs.Count == 0) return;
        removeBuff.Clear();
        foreach (var it in new List<BuffDataSO>(buffs.Keys))
        {
            buffs[it] += Time.deltaTime;
            if (buffs[it] >= it.LifeTime)
            {
                removeBuff.Add(it);
            }
        }

        foreach (var it in removeBuff)
        {
            RemoveEffect(it);
        }
    }
    public void Add(BuffDataSO buffData)
    {
        if (!buffs.ContainsKey(buffData))
        {
            buffs.Add(buffData, 0);
        }
        else
            buffs[buffData] = 0;
        ApplyEffect(buffData);
    }
    public void ApplyEffect(BuffDataSO buff)
    {
        TypeOfBuff buffType = buff.type;
        switch (buffType)
        {
            case TypeOfBuff.Speed:
                movement.SetSpeedBuff(buff.Value);
                break;
            case TypeOfBuff.Jump:
                movement.SetJumpBuff(buff.Value);
                break;
            case TypeOfBuff.Heal:
                health.Add((int)buff.Value);
                break;
            case TypeOfBuff.Damage:
                meleeAttack.IncreaseDamage((int)buff.Value);
                break;
        }
    }
    public void RemoveEffect(BuffDataSO buffData)
    {
        if (!buffs.ContainsKey(buffData)) return;
        TypeOfBuff buffType = buffData.type;
        switch (buffType)
        {
            case TypeOfBuff.Speed:
                movement.SetSpeedBuff(0);
                break;
            case TypeOfBuff.Jump:
                movement.SetJumpBuff(0);
                break;
        }
        buffs.Remove(buffData);
    }
}
