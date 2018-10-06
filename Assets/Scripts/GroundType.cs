using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundType : MonoBehaviour
{

    [SerializeField, Header("畑スペース")]
    bool isFarm;

    [SerializeField, Header("罠スペース")]
    bool isTrap;

    public bool IsFarm
    {
        get { return isFarm; }
    }

    public bool IsTrap
    {
        get { return isTrap; }
    }
}
