using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SeneChenger : MonoBehaviour {

    public string LoadSeneName;
    public void ChengeGameSene()
    {
        SceneManager.LoadScene(LoadSeneName);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
