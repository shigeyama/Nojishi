using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoonChengeNight : MonoBehaviour {
    float ChengeTime;//昼から夜に切り替わる時間のカウント
    bool noonornight;//今昼か夜か知らせるフラグ。
    public float LimitTime;//昼が終わるまでの時間（falseが昼trueが夜）
    bool NoonorNight
    {
        get { return NoonorNight; }
        set { NoonorNight = value; }
    }

	void Start () {
        ChengeTime = 0;//時間カウントを0にする。
        NoonorNight = false;//昼にする
	}
	
	// Update is called once per frame
	void Update () {
        ChengeTime += Time.deltaTime;
        if (ChengeTime >= LimitTime)
        {
            NoonorNight = true;//夜にする。
        }
	}
}
