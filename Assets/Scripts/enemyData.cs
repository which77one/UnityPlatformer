using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Data", menuName = "ScriptableObjects/Enemy", order=1)]
public class enemyData : ScriptableObject
{
    public int damage;
    public int speed;
    public int hp;
}
