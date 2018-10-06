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
    float destroyTimeBak;
    bool UTurn;
    int sakumotuID;   // あたった作物・トラップ番号
    void Awake()
    {

    }
	// Use this for initialization
	void Start () {

	}

    // 開始位置から対象マスまでの距離 １スタート
    public void SetParam(int Distance, int Sakumotu,bool newUTurn=false)
    {
        destroyTime = DestroySpeed * Distance;
        UTurn = newUTurn;
        destroyTimeBak = destroyTime;
        sakumotuID = Sakumotu;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = gameObject.transform.position;
        pos += gameObject.transform.forward.normalized * MoveSpeed * Time.deltaTime;
        gameObject.transform.position = pos;

        destroyTime -= Time.deltaTime;

        // 時間がきたので削除
        if (destroyTime < 0)
        {
            if (UTurn)
            {
                // 帰りがある場合はここで反転させる
                destroyTime = destroyTimeBak;
                transform.Rotate(new Vector3(0, 1, 0), 180);
                UTurn = false;
                // ここで作物を削除してスコアを加算
            }
            else
            {
                DestroyObject(gameObject);
                // ここでトラップにダメージ処理

            }
        }
//		destroyTime

	}
}
