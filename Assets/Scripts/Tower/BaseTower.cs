using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public int _level;
    public float _damage;
    public float _atkSpeed;
    public float _range;
    public virtual void SetStats(TowerScriptable tower, int level){
        TowerLevelData levelData = tower.GetLevelData(level);
        if(levelData != null){
            _level = levelData.level;
            _damage = levelData.damage;
            _atkSpeed = levelData.atkSpeed;
            _range = levelData.range * 0.02f;
        }
    }
}
