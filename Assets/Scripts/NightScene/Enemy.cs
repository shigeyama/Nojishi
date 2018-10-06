using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // てき　表現的なものなので、開始位置と終了位置と削除だけ
    // 罠にかかった場合は消える
    // 食べられた場合はかえる

    // 生成位置と向きとターゲットを配列にする

    // 移動速度
    [SerializeField]
    float MoveSpeed=1f;
    [SerializeField]
    float DestroySpeed=1f;

    float destroyTime=1000; // いきなり消えないように大きい値

    void Awake()
    {

    }
	// Use this for initialization
	void Start () {

	}

    // 開始位置から対象マスまでの距離 １スタート
    public void SetParam(int Distance)
    {
        destroyTime = DestroySpeed * Distance;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(this.transform.up * DestroySpeed);
        destroyTime -= Time.deltaTime;

        // 時間がきたので削除
        if (destroyTime < 0)
        {
            DestroyObject(gameObject);
            // 移動先のものが削除であればここで行う
        }
//		destroyTime

	}
}
