using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : SingletonMonoBehaviour<FarmManager>
{
    [SerializeField]
    PlayerSystem playerSystem;

    [SerializeField, Header("シーン上の畑を持ってくる")]
    GameObject[] groundTypeObject;

    public int[] typeNumber;

    public int[] dayCounts;

    public int[] growthDays;

    bool dayCheck = true;

    public void SetNumber()
    {
        dayCheck = false;

        typeNumber = new int[groundTypeObject.Length];
        dayCounts = new int[groundTypeObject.Length];
        growthDays = new int[groundTypeObject.Length];

        for (int i = 0; i < groundTypeObject.Length; i++)
        {
            typeNumber[i] = groundTypeObject[i].GetComponent<GroundType>().GroundTypeNum;

            dayCounts[i] = groundTypeObject[i].GetComponent<GroundType>().DayCount;

            growthDays[i] = groundTypeObject[i].GetComponent<GroundType>().GrowthDay;
        }
    }

    public void Damage(int typeNum, int damage)
    {
        groundTypeObject[typeNum].GetComponent<GroundType>().AnimalDamage(damage);
    }

    void Update()
    {
        if (!dayCheck && NightManager.instance.CheckStatus() == NightManager.NightStatus.End)
        {
            for (int i = 0; i < groundTypeObject.Length; i++)
            {
                groundTypeObject[i].GetComponent<GroundType>().DayCounter();
            }
            playerSystem.PowerReset();
            dayCheck = true;
            NightManager.instance.DeleteNightScene();
        }
    }
}
