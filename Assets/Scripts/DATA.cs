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
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(carrotPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void Eggplant()
    {
        Debug.Log("Eggplant");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 2;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(eggplantPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void Tomato()
    {
        Debug.Log("Tomato");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 3;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(tomatoPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void Corn()
    {
        Debug.Log("Corn");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 4;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(cornPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void Pampkin()
    {
        Debug.Log("Pumpkin");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 5;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(pampkinPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void FeedTrap()
    {
        Debug.Log("FeedTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 6;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(feedTrapPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void LightTrap()
    {
        Debug.Log("LightTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 7;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 1;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(lightTrapPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void RopeTrap()
    {
        Debug.Log("RopeTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 7;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 2;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(ropeTrapPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void TorabasamiTrap()
    {
        Debug.Log("TorabasamiTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 8;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 3;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(torabasamiTrapPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }

    public void DensakuTrap()
    {
        Debug.Log("DensakuTrap");
        playerSystem.SelectGround.GetComponent<GroundType>().GroundTypeNum = 9;
        playerSystem.SelectGround.GetComponent<GroundType>().Hp = 5;
        playerSystem.SelectGround.GetComponent<GroundType>().Item = Instantiate(densakuTrapPre, playerSystem.SelectGround.transform.position, Quaternion.identity);
        playerSystem.SelectGround.GetComponent<GroundType>().IsItem = true;
        playerSystem.DestroyButton();
    }
}
