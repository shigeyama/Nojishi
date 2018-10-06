using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NightManager : MonoBehaviour {
    

    // 夜朝シーンかどうか
    public enum NightStatus
    {
        None=0, // 昼間
        Exec,   // 夜朝　実行中
        End,    // 夜朝　やること全部おわったので処理を戻していい状態
    };
    NightStatus nowNightStatus; // 昼側で監視してEndならDeleteNightScene呼び出して昼を再開してください

    // 夜朝シーンが存在するかどうか
    bool ExistScene;

    // 討伐数収穫数
    public class Score
    {
        public enum Doubutu
        {
            Inoshishi=0,
            Cnt
        };
        public enum Sakumotu
        {
            Ninjin=0,
            Cnt
        };
        public int[] Dbt  = new int[(int)Doubutu.Cnt];
        public int[] OKSaku = new int[(int)Sakumotu.Cnt];
        public int[] NGSaku = new int[(int)Sakumotu.Cnt];

        // スコアリセット
        public void Reset()
        {
            Dbt  = new int[(int)Doubutu.Cnt];
            OKSaku = new int[(int)Sakumotu.Cnt];
            NGSaku = new int[(int)Sakumotu.Cnt];
        }
        // 週間に１日のスコアを足す処理
        public void AddTotalScore(Score addsc)
        {
            int lp=0;
            for (lp = 0; lp < Dbt.Length; lp++) { Dbt[lp] += addsc.Dbt[lp]; }
            for (lp = 0; lp < OKSaku.Length; lp++) { 
                OKSaku[lp] += addsc.OKSaku[lp]; 
                NGSaku[lp] += addsc.NGSaku[lp]; 
            }
        }
        //１日のスコア加算
        //動物たおした
        public void AddDoubutu(Doubutu kind)
        {
            Dbt[(int)kind]++;
        }
        // 作物収穫
        public void AddOKSaku(Sakumotu kind)
        {
            OKSaku[(int)kind]++;
        }
        // 作物とられた
        public void AddNGSaku(Sakumotu kind)
        {
            NGSaku[(int)kind]++;
        }
    }

    Score TotalScore;   // 合計スコア
    Score OneScore;     // １日スコア
    // メインシーンのライトとカメラ  これだけちょっと交換したいのでほしいです
    [SerializeField]
    Light MainLight;
    [SerializeField]
    Camera MainCamera;

    // どシンプルシングルトン
    static public NightManager instance;
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
//            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    // ゲーム開始時に呼ぶこと
    public void FirstInit()
    {
        TotalScore.Reset();
        OneScore.Reset();
    }

    // シーン追加
    public void StartNightScene()
    {
        if (ExistScene == false)
        {
            nowNightStatus = NightStatus.Exec;
            // メインシーンのカメラとライトをオフ
            ExistScene = true;
            if( MainCamera)MainCamera.gameObject.SetActive(false);
            if (MainLight) MainLight.gameObject.SetActive(false);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/NightScene", LoadSceneMode.Additive);
        }
    }

    public void DeleteNightScene()
    {
        if (ExistScene == true)
        {
            nowNightStatus = NightStatus.None;
            // メインシーンのカメラとライトをオン
            ExistScene = false;
            if (MainCamera) MainCamera.gameObject.SetActive(true);
            if (MainLight) MainLight.gameObject.SetActive(true);
            UnityEngine.SceneManagement.SceneManager.UnloadScene("Scenes/NightScene");
        }
    }

    //
    public NightStatus CheckStatus()  
    {
        return nowNightStatus;
    }

    //
    public void SetStatus(NightStatus newStatus)  
    {
        nowNightStatus=newStatus;
    }

    public void Start()
    {
        StartNightScene();
    }
}
