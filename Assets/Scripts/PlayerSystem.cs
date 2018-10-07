using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    GameObject trapButtonPrefab;
    [SerializeField]
    GameObject farmButtonPrefab;

    GameObject trapButton;
    GameObject farmButton;

    GameObject selectGround;

    DATA data;

    int powerPoint;

    // Use this for initialization
    void Start()
    {
        data = FindObjectOfType<DATA>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
                DestroyButton();
                if (!hit.collider.gameObject.GetComponent<GroundType>().IsItem)
                {
                    ButtonGeneration(hit.collider.gameObject.GetComponent<GroundType>(), hit.collider.transform.position);
                    selectGround = hit.collider.gameObject;
                }
            }
            else if (hit.collider.gameObject.tag != "Button")
            {
                DestroyButton();
            }
        }
    }

    void ButtonGeneration(GroundType type, Vector3 generationPos)
    {
        if (type.IsTrap)
        {
            trapButton = Instantiate(trapButtonPrefab, generationPos + new Vector3(0, 13, 0), Quaternion.Euler(80, 0, 0));
            trapButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(data.FeedTrap);
            trapButton.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(data.LightTrap);
            trapButton.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(data.RopeTrap);
            trapButton.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(data.TorabasamiTrap);
            trapButton.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(data.DensakuTrap);
        }
        if (type.IsFarm)
        {
            if (type.IsTrap)
            {
                farmButton = Instantiate(farmButtonPrefab, generationPos + new Vector3(36, 13, 0), Quaternion.Euler(80, 0, 0));
            }
            else
            {
                farmButton = Instantiate(farmButtonPrefab, generationPos + new Vector3(0, 13, 0), Quaternion.Euler(80, 0, 0));
            }
            farmButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(data.Carrot);
            farmButton.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(data.Eggplant);
            farmButton.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(data.Tomato);
            farmButton.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(data.Corn);
            farmButton.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(data.Pampkin);
        }
    }

    public GameObject SelectGround
    {
        get { return selectGround; }
    }

    public void DestroyButton()
    {
        Destroy(trapButton);
        Destroy(farmButton);
    }
    
}
