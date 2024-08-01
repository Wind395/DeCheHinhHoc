using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public int _level;
    public float _damage;
    public float _atkSpeed;
    public float _range;
    public virtual void SetStats(TowerScriptable tower){
        _level = tower.level;
        _damage = tower.damage;
        _atkSpeed = tower.atkSpeed;
        _range = tower.range * 0.02f;
    }
}
