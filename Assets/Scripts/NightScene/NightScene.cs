using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NightScene : MonoBehaviour, IPointerClickHandler{

    // メインシーンのライトとカメラ  これだけちょっと交換したいのでほしいです
    [SerializeField]
    Light SceneLight;
    [SerializeField]
    Camera SceneCamera;
    // てきの生成位置
    [SerializeField]
    Transform[] EnmeySpawnPoint;

    [SerializeField]
    GameObject[] EnemyList;

    [SerializeField]
    Text[] ScoreTextArray;
    
  public   bool NightMode; // 夜ならtrue 朝ならfalse
  public bool EndWait;
  bool KeyInputWait;    // クリックして良い
    // 敵の生成パターン系
  [SerializeField]
  float DayTime_base = 30;   // 1日の夜間の秒数設定値 取り急ぎ30秒
   
  float DayTime;            // この日の残り秒数



// 日別の出現テーブル    データのデリミタに99999タイマー
  int InitPtr;
  int[,] enemyInitArray_Time =
  {
      {10,20,99999},
      {10,20,99999},
      {10,20,99999},
      {10,20,99999},
      {10,20,99999},
      {10,20,99999},
      {10,20,99999},
  };
  NightManager.Doubutu[,] enemyInitArray_Doubutu =
  {
      {NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi},
      {NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi},
      {NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi},
      {NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi},
      {NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi},
      {NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi},
      {NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi,NightManager.Doubutu.Inoshishi},
  };
  // ラインごとの参照テーブル
  int[,] IndexTable =
  {
       // 左上縦～右
       {20,21,22,23,24},
       {15,16,17,18,19},
       { 0, 1, 2, 3, 4},
       { 5, 6, 7, 8, 9},
       {10,11,12,13,14},
       //左下縦～右
       {24,23,22,24,20},
       {19,18,17,16,15},
       { 4, 3, 2, 1, 0},
       { 9, 8, 7, 6, 5},
       {14,13,12,11,10},
       //左上横～下
       {20,15, 0, 5,10},
       {21,16, 1, 6,11},
       {22,17, 2, 7,12},
       {23,18, 3, 8,13},
       {24,19, 4, 9,14},
       //右下横～上
       {10, 5, 0,15,20},
       {11, 6, 1,16,21},
       {12, 7, 2,17,22},
       {13, 8, 3,18,23},
       {14, 9, 4,19,24},
  };

  int[,] KaihiTable = //　回避値の増減テーブル
    {
        // 縦Doubutu 横Sakumotu/Trap
        {50},

    };
  //        NightManager.instance.DeleteNightScene();
  // Use this for initialization
	void Start () {
        // 毎日生成から始まるのでここで各種初期化処理
        NightMode = true;
        DayTime = DayTime_base;
        InitPtr = 0;
        /* //テストデータ
                // 敵ID　生成位置　消える位置 Uターン
                EnemyInstantiate(0, 0, 1,false);
                EnemyInstantiate(0, 1, 2,false);
                EnemyInstantiate(0, 2, 3,false);
                EnemyInstantiate(0, 3, 4,false);
                EnemyInstantiate(0, 4, 5,false);
                EnemyInstantiate(1, 5, 1,false);
                EnemyInstantiate(1, 6, 2,false);
                EnemyInstantiate(1, 7, 3,false);
                EnemyInstantiate(1, 8, 4,false);
                EnemyInstantiate(1, 9, 5,false);
                EnemyInstantiate(2, 10, 1,false);
                EnemyInstantiate(2, 11, 2,false);
                EnemyInstantiate(2, 12, 3,false);
                EnemyInstantiate(2, 13, 4,false);
                EnemyInstantiate(2, 14, 5,false);
                EnemyInstantiate(3, 15, 1,false);
                EnemyInstantiate(3, 16, 2,false);
                EnemyInstantiate(3, 17, 3,false);
                EnemyInstantiate(3, 18, 4,false);
                EnemyInstantiate(3, 19, 5,false);
         */
    }

    // 敵生成　場所
    void EnemyInstantiate(int EnemyId,int PosId, int TargetDist,bool Return,int SakumotuID)
    {
        GameObject obj = Instantiate(EnemyList[EnemyId], EnmeySpawnPoint[PosId].position, EnmeySpawnPoint[PosId].rotation);
        obj.GetComponent<Enemy>().SetParam(TargetDist, SakumotuID,Return);
    }
	
	// Update is called once per frame
	void Update () {
        // 時間変更アニメ
        if( NightMode)
        {
            // 敵進行中（昼～夜）

            // 夜への表示変更
            float step = Time.deltaTime * 20;
            SceneLight.transform.rotation = Quaternion.RotateTowards(SceneLight.transform.rotation, Quaternion.Euler(200, -30, 0), step); 


            // 
            // 敵生成・制限時間処理
            DayTime += Time.deltaTime;
            // 制限時間終了で切り替え
            if (DayTime >= DayTime_base)
            {
                // 昼夜処理を終了させて夜朝処理へ
                EndWait = true;
                NightMode = false;
                StartCoroutine("MorningWait");  // ここで結果発表表示とキー入力受付開始ウェイトの制御
            }
            else
            {
                // 敵生成処理
/*
 	１日あたりの登場量を考える	１日目１５、２日目５　３日目７　４日目１０　５日目２０	６日目１０　７日目１０
	敵の種類とタイミングと個数は固定
		
	敵の種類はトラップとの相性とHP
	
	罠はHPと回避抽選値へ影響
	
	出現は各ステージきまったタイミングで生成
	生成タイミングにとりあえずランダムで２０個のどれかを選ぶ
	その後、その方向の順番にデータをみていき、回避値（初期値５０）を増減させる　作物がきた時点で終了　ターゲット番号はこの時点でセットするようにし、罠か作物が最初にきた番号を入れる	なにもこなければ回避
	そのあとその抽選値で回避抽選を行い、回避失敗ならそのラインで決定
	成功なら再抽選、３回失敗すれば完全回避

	ライン決定時、一番近いトラップの距離で終了時間をセット	トラップの場所と内容を保存
	終了時間がきたところでフィードバックをメイン側に送りサウンドも鳴らす　スコアにも加算


	罠、敵の２元配列で回避抽選値・罠へのダメージを作成
*/
                if (enemyInitArray_Time[NightManager.instance.getDay(),InitPtr] <= DayTime)
                {
                    // 出現時間を超えたので参照
                    int EnemyKind = (int)enemyInitArray_Doubutu[NightManager.instance.getDay(),InitPtr];

                    int challenge=0;
                    do
                    {
                        int LineIndex = Random.Range(0, 20);

                        // 回避抽選
                        bool Kaihi=false;
                        int KaihiPer = 100;  // なにもなければ回避率１００％
                        int EndIndex = 0;   // 消すタイミング
                        int SakumotuIndex = 0;    //TargetIndexをもとに昼のデータから中身を取得する
                        int TargetDist = 0;
                        // インデックステーブルを参照して配列の中身を見る
                        for (TargetDist = 0; TargetDist < 5; TargetDist++)
                        {
                            int TargetIndex = IndexTable[LineIndex,TargetDist];   // 参照する畑
                            SakumotuIndex = 0;  // 畑の内容をここに保存
                            if (SakumotuIndex != 0)
                            {
                                // 最寄りの作物・トラップがあれば回避率で抽選を行う
                                KaihiPer = KaihiTable[(int)EnemyKind,SakumotuIndex];  //縦Doubutu 横Sakumotu/Trap
                                break;
                            }
                        }
                        // 回避の成否で処理わけ
                        int KaihiRand = Random.Range(0, 100);
                        if (KaihiRand <= KaihiPer) Kaihi = false;   // 乱数値が抽選値より小さければ回避失敗
                        if (Kaihi == false)
                        {
                            bool UTurn = false;
                            if (SakumotuIndex >= 5) UTurn = true;
                            EnemyInstantiate((int)EnemyKind, LineIndex, 1 + TargetDist, UTurn,SakumotuIndex);
                            break;
                        }
                        else
                        {
                            challenge++;
                        }
                    } while (challenge <= 3);       // 3回で完全回避
                    //最後に参照ポインタを進める
                    InitPtr++;
                    
                }
            }
        }
        else
        {
            //
            float step = Time.deltaTime * 20;
            if (EndWait)    // 朝待ち
            {
                // 夜から朝 ここで結果発表
                // ここに入る時点でMorningWaitコルーチンで３秒ウェイトに入るのでその間に空だけ変更　表示はコルーチン内
                SceneLight.transform.rotation = Quaternion.RotateTowards(SceneLight.transform.rotation, Quaternion.Euler(10, -30, 0), step);
            }
            else
            {
                // 結果発表でボタン押したらこっちへ移動　時間経過で昼に（ここはアニメーションのみでフラグ変更はコルーチン呼び出し）
                SceneLight.transform.rotation = Quaternion.RotateTowards(SceneLight.transform.rotation, Quaternion.Euler(50, -30, 0), step);
            }

        }
		
	}


    public void OnPointerClick(PointerEventData data)
    {
        // 最後結果を戻すときだけクリック有効
        if( KeyInputWait)
        {
            NightMode = false;  // このシーンの処理を全部終了して結果発表（朝）から昼になるまでの待機開始
            EndWait = false;
            KeyInputWait = false;
            StartCoroutine("EndWaitStart");  
        }
    }

    // 昼に戻る処理
    private IEnumerator EndWaitStart()
    {
        // コルーチンの処理  
        yield return new WaitForSeconds(2.0f);
        NightManager.instance.SetStatus(NightManager.NightStatus.End);  // ここで処理終了
    }
    // 朝の結果発表開始時に呼び出し　モード切り替えとキー入力受付ウェイト
    private IEnumerator MorningWait()
    {
        // コルーチンの処理  
        // ここで順番に結果発表
        yield return new WaitForSeconds(3.0f);
        KeyInputWait = true;    // ここから受付開始
    }

}
