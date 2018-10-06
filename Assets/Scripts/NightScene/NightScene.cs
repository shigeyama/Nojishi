using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightScene : MonoBehaviour {

    // メインシーンのライトとカメラ  これだけちょっと交換したいのでほしいです
    [SerializeField]
    Light SceneLight;
    [SerializeField]
    Camera SceneCamera;
    // てきの生成位置
    [SerializeField]
    Transform[] EnmeySpawnPoint;


  public   bool NightMode; // 夜ならtrue 朝ならfalse
  public bool EndWait;
    // Use this for initialization
	void Start () {
//        NightManager.instance.DeleteNightScene();
        NightMode = true;
	}
	
	// Update is called once per frame
	void Update () {
        // 時間変更アニメ
        if( NightMode)
        {
            float step = Time.deltaTime * 20;
            //夜
            SceneLight.transform.rotation = Quaternion.RotateTowards(SceneLight.transform.rotation, Quaternion.Euler(200, -30, 0), step); 
        }
        else
        {
            //朝
            float step = Time.deltaTime * 20;
            if (EndWait)    // 朝待ち
            {
                SceneLight.transform.rotation = Quaternion.RotateTowards(SceneLight.transform.rotation, Quaternion.Euler(10, -30, 0), step);
            }
            else
            {
                SceneLight.transform.rotation = Quaternion.RotateTowards(SceneLight.transform.rotation, Quaternion.Euler(50, -30, 0), step);

            }

        }
		
	}

}
