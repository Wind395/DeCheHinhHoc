using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyLevel
{
    public int level;
    public int health;
    public int damage;
    public float speed;
}
[CreateAssetMenu(fileName = "EnemyAttribute", menuName = "ScriptableObject/EnemyData")]
public class EnemyScriptable : ScriptableObject
{
    public EnemyLevel[] levels;
}
