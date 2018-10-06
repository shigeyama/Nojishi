using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : SingletonMonoBehaviour<FarmManager>
{
    [SerializeField, Header("シーン上の畑を持ってくる")]
    GameObject[] groundTypeObject;

    public int[] typeNumber;

    public int[] dayCounts;

    public void SetNumber()
    {
        for(int i = 0; i < groundTypeObject.Length; i++)
        {
            typeNumber[i] = groundTypeObject[i].GetComponent<GroundType>().GroundTypeNum;

            dayCounts[i] = groundTypeObject[i].GetComponent<GroundType>().DayCount;
        }
    }

    public void Damage(int typeNum, int damage)
    {
        groundTypeObject[typeNum].GetComponent<GroundType>().AnimalDamage(damage);
    }
}
