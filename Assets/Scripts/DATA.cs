using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATA : MonoBehaviour
{
    [SerializeField]
    PlayerSystem playerSystem;

    //野菜-----------------------------------------
    [SerializeField]
    GameObject carrotPre;

    [SerializeField]
    GameObject eggplantPre;

    [SerializeField]
    GameObject tomatoPre;

    [SerializeField]
    GameObject cornPre;

    [SerializeField]
    GameObject pampkinPre;

    //罠-------------------------------------------
    [SerializeField]
    GameObject feedTrapPre;

    [SerializeField]
    GameObject lightTrapPre;

    [SerializeField]
    GameObject ropeTrapPre;

    [SerializeField]
    GameObject torabasamiTrapPre;

    [SerializeField]
    GameObject densakuTrapPre;


    public void Carrot()
    {
        Debug.Log("Carrot");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().GrowthDay = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(carrotPre, playerSystem.SelectGround.transform.position + new Vector3(0, 3, 0), Quaternion.Euler(0, 90, 25));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.SelectGround.GetComponent<GroundType>().DayCount = 0;        playerSystem.DestroyButton();
    }

    public void Eggplant()
    {
        Debug.Log("Eggplant");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 2;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().GrowthDay = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(eggplantPre, playerSystem.SelectGround.transform.position + new Vector3(-2.5f, 3, 0), Quaternion.Euler(0, 90, 25));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.SelectGround.GetComponent<GroundType>().DayCount = 0;
        playerSystem.DestroyButton();
    }

    public void Tomato()
    {
        Debug.Log("Tomato");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 3;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().GrowthDay = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(tomatoPre, playerSystem.SelectGround.transform.position + new Vector3(-2.5f, 3, 0), Quaternion.Euler(0, 90, 25));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.SelectGround.GetComponent<GroundType>().DayCount = 0;
        playerSystem.DestroyButton();
    }

    public void Corn()
    {
        Debug.Log("Corn");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 4;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().GrowthDay = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(cornPre, playerSystem.SelectGround.transform.position + new Vector3(-1f, 0, 0), Quaternion.Euler(0, 90, 25));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.SelectGround.GetComponent<GroundType>().DayCount = 0;
        playerSystem.DestroyButton();
    }

    public void Pampkin()
    {
        Debug.Log("Pumpkin");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 5;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().GrowthDay = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(pampkinPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.SelectGround.GetComponent<GroundType>().DayCount = 0;
        playerSystem.DestroyButton();
    }

    public void FeedTrap()
    {
        Debug.Log("FeedTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 6;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(feedTrapPre, playerSystem.SelectGround.transform.position + new Vector3(6, 5, 0), Quaternion.Euler(0, 0, 90));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void LightTrap()
    {
        Vector3 offsetRot = new Vector3(0, 0, 0);
        if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 0 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 1 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 5 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 15)
        {
            offsetRot = new Vector3(0, 0, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 3 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 4 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 9 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 19)
        {
            offsetRot = new Vector3(-40, 180, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 7 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 11 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 12 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 13)
        {
            offsetRot = new Vector3(0, 90, 30);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 17 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 21 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 22 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 23)
        {
            offsetRot = new Vector3(0, -90, -30);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 6 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 10)
        {
            offsetRot = new Vector3(0, 45, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 8 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 14)
        {
            offsetRot = new Vector3(-45, 135, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 16 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 20)
        {
            offsetRot = new Vector3(0, -45, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 18 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 24)
        {
            offsetRot = new Vector3(-45, -135, 0);
        }

        Debug.Log("LightTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 7;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(lightTrapPre, playerSystem.SelectGround.transform.position, Quaternion.Euler(offsetRot));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void RopeTrap()
    {
        Debug.Log("RopeTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 8;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 2;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(ropeTrapPre, playerSystem.SelectGround.transform.position, Quaternion.Euler(30, 0, 0));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void TorabasamiTrap()
    {
        Debug.Log("TorabasamiTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 9;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 3;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(torabasamiTrapPre, playerSystem.SelectGround.transform.position + new Vector3(0, 1.5f, 0), Quaternion.Euler(0, 90, 0));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void DensakuTrap()
    {
        Vector3 offsetRot = new Vector3(0, 0, 0);
        if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 0 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 1 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 5 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 15)
        {
            offsetRot = new Vector3(30, 0, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 3 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 4 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 9 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 19)
        {
            offsetRot = new Vector3(30, 0, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 7 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 11 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 12 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 13)
        {
            offsetRot = new Vector3(20, 90, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 17 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 21 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 22 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 23)
        {
            offsetRot = new Vector3(20, -90, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 6 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 10)
        {
            offsetRot = new Vector3(0, 45, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 8 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 14)
        {
            offsetRot = new Vector3(20, -45, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 16 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 20)
        {
            offsetRot = new Vector3(0, -45, 0);
        }
        else if (playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 18 ||
            playerSystem.SelectGround.GetComponent<GroundType>().MyNumber == 24)
        {
            offsetRot = new Vector3(20, 45, 0);
        }

        Debug.Log("DensakuTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 10;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 5;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(densakuTrapPre, playerSystem.SelectGround.transform.position, Quaternion.Euler(offsetRot));
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }
}
