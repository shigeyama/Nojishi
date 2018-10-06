using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundType : MonoBehaviour
{
    [SerializeField, Header("畑スペース")]
    bool isFarm;

    [SerializeField, Header("罠スペース")]
    bool isTrap;

    bool isItem;

    GameObject item;

    int groundTypeNum;

    int dayCount;

    int hp;

    public bool IsFarm
    {
        get { return isFarm; }
    }

    public bool IsTrap
    {
        get { return isTrap; }
    }

    public void AnimalDamage(int damage)
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(item);
            isItem = false;
        }
    }

    public bool IsItem
    {
        get { return isItem; }
        set { isItem = value; }
    }

    public int GroundTypeNum
    {
        get { return groundTypeNum; }
        set { groundTypeNum = value; }
    }

    void DayCounter()
    {
        dayCount++;
    }

    public int DayCount
    {
        get { return dayCount; }
    }

    public int Hp
    {
        set { hp = value; }
    }

    public GameObject Item
    {
        set { item = value; }
    }
}
