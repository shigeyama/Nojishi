using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NightScene : MonoBehaviour{

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
    [SerializeField]
    GameObject ScoreCanvas;
    [SerializeField]
    Button NextButton;
    
  public   bool NightMode; // 夜ならtrue 朝ならfalse
  public bool EndWait;
  bool KeyInputWait;    // クリックして良い
    // 敵の生成パターン系
  [SerializeField]
  float DayTime_base = 30;   // 1日の夜間の秒数設定値 取り急ぎ30秒
   
  float DayTime;            // この日の残り秒数

  bool LastDay = false;


// 日別の出現テーブル 30秒    データのデリミタに99999タイマー
  int InitPtr;
  int[,] enemyInitArray_Time =
  {
	//１日あたりの登場量を考える	１日目１５、２日目５　３日目７　４日目３　５日目２０	６日目１０　７日目１０
      { 1, 2, 5, 6, 7,10,15,20,25,27,99999,0,0,0,0,0,0,0,0,0,0},    //10
      { 4, 6, 7,10,20,99999,0,0,0,0,0 ,0,0,0,0,0,0,0,0,0,0},    //5
      {10,15,16,17,20,22,24,99999,0,0,0 ,0,0,0,0,0,0,0,0,0,0},    //7
      {5,10,15,99999,0,0,0,0,0,0,0 ,0,0,0,0,0,0,0,0,0,0} ,  //3
      { 1, 4,10,11,12,13,14,15,16,17,   18,19,20,21,22,23,24,25,26,27,99999},   //20
      { 2, 4, 6, 8,10,16,18,20,22,24,99999 ,0,0,0,0,0,0,0,0,0,0},    //10
      {16,17,18,19,20,21,22,23,24,25,99999 ,0,0,0,0,0,0,0,0,0,0},    //10
  };
  NightManager.Doubutu[,] enemyInitArray_Doubutu =  // ステージ５以外は２行目ダミーです
  {// 0                          1                         2                         3                         4                         5                         6                         7                         8                         9
      {NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Bear,NightManager.Doubutu.Boar,NightManager.Doubutu.Bear,NightManager.Doubutu.Boar,NightManager.Doubutu.Bear,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,
       NightManager.Doubutu.Bear,NightManager.Doubutu.Deer,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Wolf,NightManager.Doubutu.Wolf,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear},
      {NightManager.Doubutu.Boar,NightManager.Doubutu.Deer,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,
       NightManager.Doubutu.Bear,NightManager.Doubutu.Deer,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Wolf,NightManager.Doubutu.Wolf,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear},
      {NightManager.Doubutu.Wolf,NightManager.Doubutu.Boar,NightManager.Doubutu.Fox ,NightManager.Doubutu.Fox ,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Wolf,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,
       NightManager.Doubutu.Bear,NightManager.Doubutu.Deer,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Wolf,NightManager.Doubutu.Wolf,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear},
      {NightManager.Doubutu.Squirrel,NightManager.Doubutu.Squirrel,NightManager.Doubutu.Squirrel,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,
       NightManager.Doubutu.Bear,NightManager.Doubutu.Deer,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Wolf,NightManager.Doubutu.Wolf,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear},
      {NightManager.Doubutu.Squirrel,NightManager.Doubutu.Squirrel,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,
       NightManager.Doubutu.Bear,NightManager.Doubutu.Deer,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Wolf,NightManager.Doubutu.Wolf,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear},
      {NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,NightManager.Doubutu.Boar,
       NightManager.Doubutu.Bear,NightManager.Doubutu.Deer,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Wolf,NightManager.Doubutu.Wolf,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear},
      {NightManager.Doubutu.Wolf,NightManager.Doubutu.Bear,NightManager.Doubutu.Wolf,NightManager.Doubutu.Boar,NightManager.Doubutu.Wolf,NightManager.Doubutu.Deer,NightManager.Doubutu.Wolf,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Squirrel,
       NightManager.Doubutu.Bear,NightManager.Doubutu.Deer,NightManager.Doubutu.Fox ,NightManager.Doubutu.Hare,NightManager.Doubutu.Wolf,NightManager.Doubutu.Wolf,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear,NightManager.Doubutu.Bear},
  };
  // ラインごとの参照テーブル
  int[,] IndexTable =
  {
       // 左上縦～右
       {14,13,12,11,10},
       { 9, 8, 7, 6, 5},
       { 4, 3, 2, 1, 0},
       {19,18,17,16,15},
       {24,23,22,24,20},
       //左下縦～右
       {10,11,12,13,14},
       { 5, 6, 7, 8, 9},
       { 0, 1, 2, 3, 4},
       {15,16,17,18,19},
       {20,21,22,23,24},
       //左上横～下
       {14, 9, 4,19,24},
       {13, 8, 3,18,23},
       {12, 7, 2,17,22},
       {11, 6, 1,16,21},
       {10, 5, 0,15,20},
       //右下横～上
       {24,19, 4, 9,14},
       {23,18, 3, 8,13},
       {22,17, 2, 7,12},
       {21,16, 1, 6,11},
       {20,15, 0, 5,10},
  };

  int[,] KaihiTable = //　回避抽選値のテーブル
    {
        // 縦Doubutu 横Sakumotu/Trap
        // 0:dmy 1-5:作物 6-10:トラップ feed/light/rope/tora/densaku   
        {100,   80,55,50,10,30,     60,20,50,30,10     },  //bear
        {100,   60,80,10,40,30,     60,20,30,50,10     },  //boar
        {100,   60,10,80,40,30,     60,20,40,40,10     },  //deer
        {100,   10,55,50,80,30,     60,20,60,60,10     },  //fox
        {100,   70,55,50,40,30,     60,20,50,50,10     },  //hare
        {100,   60,70,50,40,30,     60,20,35,55,10     },  //squirrel
        {100,   60,55,70,40,30,     60,20,55,35,10     },  //wolf

    };

  int[] HarvestDays =   //収穫日数
    {
        9999,
        1,
        2,
        2,
        3,
        4,
    };
  //        NightManager.instance.DeleteNightScene();
  // Use this for initialization
	void Start () {
        // 毎日生成から始まるのでここで各種初期化処理
        FarmManager.Instance.SetNumber();
        NightMode = true;
        DayTime = 0;
        InitPtr = 0;
        LastDay = false;
        if (NightManager.instance.getDay() == 6) LastDay = true;
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
//        Debug.Log("よるかいし");
    }

    // 敵生成　場所
    void EnemyInstantiate(int EnemyId,int PosId, int TargetDist,bool Return,int SakumotuID,int TargetID)
    {
        GameObject obj = Instantiate(EnemyList[EnemyId], EnmeySpawnPoint[PosId].position, EnmeySpawnPoint[PosId].rotation);
        obj.GetComponent<Enemy>().SetParam(TargetDist, SakumotuID, TargetID, EnemyId,Return);
    }
	
	// Update is called once per frame
	void Update () {
        // 時間変更アニメ
        if( NightMode)
        {
            // 敵進行中（昼～夜）
        //    Debug.Log("よる");

            // 夜への表示変更
            float step = Time.deltaTime * 10;
            SceneLight.transform.rotation = Quaternion.RotateTowards(SceneLight.transform.rotation, Quaternion.Euler(200, -30, 0), step); 


            // 
            // 敵生成・制限時間処理
            DayTime += Time.deltaTime;
            // 制限時間終了で切り替え
            if (DayTime >= DayTime_base)
            {
//                Debug.Log("よるおわり");
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
//                Debug.Log("敵出現監視" + NightManager.instance.getDay()+" "+InitPtr+" "+enemyInitArray_Time[NightManager.instance.getDay(),InitPtr]);

                if (enemyInitArray_Time[NightManager.instance.getDay(),InitPtr] <= DayTime)
                {
                    // 出現時間を超えたので参照
                    int EnemyKind = (int)enemyInitArray_Doubutu[NightManager.instance.getDay(),InitPtr];

                    int challenge=0;
                    do
                    {
                        int LineIndex = Random.Range(0, 20);

//                        Debug.Log("ばんご"+EnemyKind);
                        // 回避抽選
                        bool Kaihi=true;
                        int KaihiPer = 100;  // なにもなければ回避率１００％
                        int EndIndex = 0;   // 消すタイミング
                        int SakumotuIndex = 0;    //TargetIndexをもとに昼のデータから中身を取得する
                        int TargetDist = 0;
                        int TargetIndex = 0;
                        // インデックステーブルを参照して配列の中身を見る
                        for (TargetDist = 0; TargetDist < 5; TargetDist++)
                        {
                            TargetIndex = IndexTable[LineIndex,TargetDist];   // 参照する畑
//                            Debug.Log("参照する畑" + TargetIndex + " 配列ながさ" + FarmManager.Instance.typeNumber.Length);
                            SakumotuIndex = FarmManager.Instance.typeNumber[TargetIndex];  // 畑の内容を取得
                            if (SakumotuIndex != 0)
                            {
                                // 最寄りの作物・トラップがあれば回避率で抽選を行う
                                KaihiPer = KaihiTable[(int)EnemyKind,SakumotuIndex];  //縦Doubutu 横Sakumotu/Trap
                                break;
                            }
                        }
//                        Debug.Log("かいひかくりつ" + KaihiPer);
                        // 回避の成否で処理わけ
                        int KaihiRand = Random.Range(0, 100);
                        if (KaihiRand >= KaihiPer) Kaihi = false;   // 乱数値が抽選値より小さければ回避失敗
                        if (Kaihi == false)
                        {
                            bool UTurn = false;
                            if (SakumotuIndex <= 5) UTurn = true;   // １～５が野菜なので５以下なら戻す
//                            Debug.Log("生成" + (int)EnemyKind + " " + LineIndex + " " + (1 + TargetDist) + " " + UTurn + " " + SakumotuIndex + " " + TargetIndex);

                            EnemyInstantiate((int)EnemyKind, LineIndex, 1 + TargetDist, UTurn, SakumotuIndex, TargetIndex);
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


    public void NextDay()
    {
        // 最後結果を戻すときだけクリック有効
        if( KeyInputWait)
        {
            ScoreTextArray[6].text = "";
            NextButton.gameObject.SetActive(false);

            if (LastDay)
            {
                //最終表示したのでタイトルに戻る
                NightManager.instance.FirstInit();
                 UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/TitleSene");
            }
            else
            {
                NightMode = false;  // このシーンの処理を全部終了して結果発表（朝）から昼になるまでの待機開始
                EndWait = false;
                KeyInputWait = false;
                StartCoroutine("EndWaitStart");
            }
        }
    }

    // コルーチンの処理  

    // 昼に戻る処理
    private IEnumerator EndWaitStart()
    {
        foreach (Text text in ScoreTextArray)
        {
            text.text = "";
        }
        ScoreCanvas.SetActive(false);

        yield return new WaitForSeconds(2.0f);
        NightManager.instance.SetStatus(NightManager.NightStatus.End);  // ここで処理終了
    }
    // 夜から朝になるときに呼び出し   結果発表開始　モード切り替えとキー入力受付ウェイト
    private IEnumerator MorningWait()
    {
        //まず最初に収穫処理


        // ここで作物を削除してスコアを加算
        for (int Lp = 0; Lp < FarmManager.Instance.typeNumber.Length; Lp++)
        {
            // 作物判定
            if (FarmManager.Instance.typeNumber[Lp] >= 1 && FarmManager.Instance.typeNumber[Lp] <= 5)
            {
                // 作物ごとの収穫日数を耐えていれば収穫
                if (FarmManager.Instance.dayCounts[Lp] >= FarmManager.Instance.growthDays[Lp])///]HarvestDays[FarmManager.Instance.typeNumber[Lp]])
                {
                    FarmManager.Instance.Damage(Lp, 10);
                    NightManager.instance.OneScore.AddOKSaku((NightManager.Sakumotu)FarmManager.Instance.typeNumber[Lp]);
                }
            }
        }
        // 合計値も加算
        NightManager.instance.TotalScore.AddTotalScore(NightManager.instance.OneScore);
        
        
        //ここから表示処理
        NightManager.instance.OneScore.CalcScore();
        ScoreCanvas.SetActive(true);
        foreach(Text text in ScoreTextArray)
        {
            text.text = "";
        }
        // kekka
        ScoreTextArray[0].text = "	今日の結果";
        yield return new WaitForSeconds(1.0f);
        // toubatu
        ScoreTextArray[1].text = "撃退一覧\n"+
            "熊ｘ" + NightManager.instance.OneScore.Dbt[0] + "＝" + NightManager.instance.OneScore.ScoreNum[0] + "Pt  " + "	猪ｘ" + NightManager.instance.OneScore.Dbt[1] + "＝" + NightManager.instance.OneScore.ScoreNum[1] + "Pt" + "	鹿ｘ"   + NightManager.instance.OneScore.Dbt[2] + "＝" + NightManager.instance.OneScore.ScoreNum[2] + "Pt\n" +
            "狐ｘ" + NightManager.instance.OneScore.Dbt[3] + "＝" + NightManager.instance.OneScore.ScoreNum[3] + "Pt  " + "	兎ｘ" + NightManager.instance.OneScore.Dbt[4] + "＝" + NightManager.instance.OneScore.ScoreNum[4] + "Pt" + "	リスｘ" + NightManager.instance.OneScore.Dbt[5] + "＝" + NightManager.instance.OneScore.ScoreNum[5] + "Pt" + "	狼ｘ" + NightManager.instance.OneScore.Dbt[6] + "＝" + NightManager.instance.OneScore.ScoreNum[6] + "Pt\n";
        yield return new WaitForSeconds(1.0f);
        // NGyasai
        ScoreTextArray[2].text = "	やられた野菜\n" +
            "人参ｘ" + NightManager.instance.OneScore.NGSaku[0] + "＝" + NightManager.instance.OneScore.ScoreNum[7] + "Pt  " + "	茄子ｘ" + NightManager.instance.OneScore.NGSaku[1] + "＝" + NightManager.instance.OneScore.ScoreNum[8] + "Pt\n" +
            "トマトｘ" + NightManager.instance.OneScore.NGSaku[2] + "＝" + NightManager.instance.OneScore.ScoreNum[9] + "Pt  " + "	コーンｘ" + NightManager.instance.OneScore.NGSaku[3] + "＝" + NightManager.instance.OneScore.ScoreNum[10] + "Pt" + "    南瓜ｘ"+NightManager.instance.OneScore.NGSaku[4] + "＝" + NightManager.instance.OneScore.ScoreNum[11] + "Pt\n";
        yield return new WaitForSeconds(1.0f);
        // GetYasai
        ScoreTextArray[2].text = "	収穫した野菜\n"+
            "人参ｘ" + NightManager.instance.OneScore.OKSaku[0] + "＝" + NightManager.instance.OneScore.ScoreNum[7] + "Pt  " + "	茄子ｘ" + NightManager.instance.OneScore.OKSaku[1] + "＝" + NightManager.instance.OneScore.ScoreNum[8] + "Pt\n" +
            "トマトｘ" + NightManager.instance.OneScore.OKSaku[2] + "＝" + NightManager.instance.OneScore.ScoreNum[9] + "Pt  " + "	コーンｘ" + NightManager.instance.OneScore.OKSaku[3] + "＝" + NightManager.instance.OneScore.ScoreNum[10] + "Pt" + "    南瓜ｘ" + NightManager.instance.OneScore.OKSaku[4] + "＝" + NightManager.instance.OneScore.ScoreNum[11] + "Pt\n";
        yield return new WaitForSeconds(1.0f);
        // Score
        ScoreTextArray[3].text = "	スコア　" + NightManager.instance.OneScore.ScoreNum[12] + "Pt";
        yield return new WaitForSeconds(1.0f);
        // Hitokoto
//        ScoreTextArray[4].text = "	ひとこと：";
        yield return new WaitForSeconds(1.0f);


        if (LastDay)
        {
            //最終結果発表 
            foreach (Text text in ScoreTextArray)
            {
                text.text = "";
            }
            // kekka
            ScoreTextArray[0].text = "	最終結果";
            yield return new WaitForSeconds(1.0f);
            // toubatu
            ScoreTextArray[1].text = "撃退一覧\n" +
                "熊ｘ" + NightManager.instance.TotalScore.Dbt[0] + "＝" + NightManager.instance.TotalScore.ScoreNum[0] + "Pt  " + "	猪ｘ" + NightManager.instance.TotalScore.Dbt[1] + "＝" + NightManager.instance.TotalScore.ScoreNum[1] + "Pt" + "	鹿ｘ" + NightManager.instance.TotalScore.Dbt[2] + "＝" + NightManager.instance.TotalScore.ScoreNum[2] + "Pt\n" +
                "狐ｘ" + NightManager.instance.TotalScore.Dbt[3] + "＝" + NightManager.instance.TotalScore.ScoreNum[3] + "Pt  " + "	兎ｘ" + NightManager.instance.TotalScore.Dbt[4] + "＝" + NightManager.instance.TotalScore.ScoreNum[4] + "Pt" + "	リスｘ" + NightManager.instance.TotalScore.Dbt[5] + "＝" + NightManager.instance.TotalScore.ScoreNum[5] + "Pt" + "	狼ｘ" + NightManager.instance.TotalScore.Dbt[6] + "＝" + NightManager.instance.TotalScore.ScoreNum[6] + "Pt\n";
            yield return new WaitForSeconds(1.0f);
            // NGyasai
            ScoreTextArray[2].text = "	やられた野菜\n" +
                "人参ｘ" + NightManager.instance.TotalScore.NGSaku[0] + "＝" + NightManager.instance.TotalScore.ScoreNum[7] + "Pt  " + "	茄子ｘ" + NightManager.instance.TotalScore.NGSaku[1] + "＝" + NightManager.instance.TotalScore.ScoreNum[8] + "Pt\n" +
                "トマトｘ" + NightManager.instance.TotalScore.NGSaku[2] + "＝" + NightManager.instance.TotalScore.ScoreNum[9] + "Pt  " + "	コーンｘ" + NightManager.instance.TotalScore.NGSaku[3] + "＝" + NightManager.instance.TotalScore.ScoreNum[10] + "Pt" + "    南瓜ｘ" + NightManager.instance.TotalScore.NGSaku[4] + "＝" + NightManager.instance.TotalScore.ScoreNum[11] + "Pt\n";
            yield return new WaitForSeconds(1.0f);
            // GetYasai
            ScoreTextArray[3].text = "	収穫した野菜\n" +
                "人参ｘ" + NightManager.instance.TotalScore.OKSaku[0] + "＝" + NightManager.instance.TotalScore.ScoreNum[7] + "Pt  " + "	茄子ｘ" + NightManager.instance.TotalScore.OKSaku[1] + "＝" + NightManager.instance.TotalScore.ScoreNum[8] + "Pt\n" +
                "トマトｘ" + NightManager.instance.TotalScore.OKSaku[2] + "＝" + NightManager.instance.TotalScore.ScoreNum[9] + "Pt  " + "	コーンｘ" + NightManager.instance.TotalScore.OKSaku[3] + "＝" + NightManager.instance.TotalScore.ScoreNum[10] + "Pt" + "    南瓜ｘ" + NightManager.instance.TotalScore.OKSaku[4] + "＝" + NightManager.instance.TotalScore.ScoreNum[11] + "Pt\n";
            yield return new WaitForSeconds(1.0f);
            // Score
            ScoreTextArray[4].text = "	スコア　" + NightManager.instance.TotalScore.ScoreNum[12] + "Pt";
            yield return new WaitForSeconds(1.0f);
            // Hitokoto
            //        ScoreTextArray[4].text = "	ひとこと：";
            yield return new WaitForSeconds(1.0f);
            NextButton.gameObject.SetActive(true);
            ScoreTextArray[6].text = "おわり";
        }
        else
        {
            NextButton.gameObject.SetActive(true);
            ScoreTextArray[6].text = "翌日へ"; 

        }
        // ここで順番に結果発表
        KeyInputWait = true;    // ここから受付開始
    }
}
