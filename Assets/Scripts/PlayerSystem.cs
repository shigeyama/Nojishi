using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    GameObject trapButtonPrefab;
    [SerializeField]
    GameObject farmButtonPrefab;

    GameObject trapButton;
    GameObject farmButton;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(trapButton);
            Destroy(farmButton);
            Ray();
        }
    }

    void Ray()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<GroundType>() != null)
            {
                ButtonGeneration(hit.collider.gameObject.GetComponent<GroundType>(), hit.collider.transform.position);
            }
        }
    }

    void ButtonGeneration(GroundType type, Vector3 generationPos)
    {
        if (type.IsTrap)
        {
            trapButton = Instantiate(trapButtonPrefab, generationPos + new Vector3(0, 5, 0), Quaternion.Euler(80, 0, 0));
        }
        if (type.IsFarm)
        {
            if (type.IsTrap)
            {
                farmButton = Instantiate(farmButtonPrefab, generationPos + new Vector3(36, 5, 0), Quaternion.Euler(80, 0, 0));
            }
            else
            {
                farmButton = Instantiate(farmButtonPrefab, generationPos + new Vector3(0, 5, 0), Quaternion.Euler(80, 0, 0));
            }
        }
    }
    
}
