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

    int growthDay;

    int hp;

    int myNumber;

    FarmManager farmManager;

    DATA data;

    void Start()
    {
        for (int i = 0; i < transform.root.childCount; i++)
        {
            if (transform.root.GetChild(i).gameObject == gameObject)
            {
                myNumber = i;
                break;
            }
        }
        farmManager = FindObjectOfType<FarmManager>();

        data = FindObjectOfType<DATA>();

    }

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
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(item);
            isItem = false;
            GroundTypeNum = 0;
        }
    }

    public void DayCounter()
    {
        if (groundTypeNum > 0 && groundTypeNum < 6)
        {
            dayCount++;
            if (dayCount >= growthDay)
            {
                Destroy(item);
                switch (groundTypeNum)
                {
                    case 1:
                        data.GrewCarrot(gameObject);
                        break;
                    case 2:
                        data.GrewEggplant(gameObject);
                        break;
                    case 3:
                        data.GrewTomato(gameObject);
                        break;
                    case 4:
                        data.GrewCorn(gameObject);
                        break;
                    case 5:
                        data.GrewPampkin(gameObject);
                        break;
                }
            }
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

    public int GrowthDay
    {
        get { return growthDay; }
        set { growthDay = value; }
    }

    public int DayCount
    {
        get { return dayCount; }
        set { dayCount = value; }
    }

    public int Hp
    {
        set { hp = value; }
    }

    public GameObject Item
    {
        set { item = value; }
    }

    public int MyNumber
    {
        get { return myNumber; }
    }
}
