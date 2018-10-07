using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public enum Ch
    {
        BGM=0,
        SE1,
        SE2,
        COUNT
    }
    [SerializeField]
    AudioSource []AS = new AudioSource[(int)Ch.COUNT];

	int SEIndex;
    void Awake()
    {
		SEIndex=0;
    }

    public void PlayBGM(string Name)
    {
        AudioClip clip = null;
        clip = (AudioClip)Resources.Load(Name);
		PlayBGM(clip);

    }
    public void PlayBGM(AudioClip clip)
    {
        if (AS[(int)Ch.BGM].isPlaying)
            AS[(int)Ch.BGM].Stop();

        AS[(int)Ch.BGM].clip = clip;
        if (AS[(int)Ch.BGM].clip!=null)
    		AS[(int)Ch.BGM].Play();

    }
    
    public void PlaySE(string Name)
    {
        AudioClip clip = null;
        clip = (AudioClip)Resources.Load(Name);
		PlaySE(clip);

    }
    public void PlaySE(AudioClip clip)
    {
        if (AS[(int)Ch.SE1+SEIndex].isPlaying)
            AS[(int)Ch.SE1+SEIndex].Stop();

        AS[(int)Ch.SE1+SEIndex].clip = clip;
        if (AS[(int)Ch.SE1+SEIndex].clip!=null)
    		AS[(int)Ch.SE1+SEIndex].Play();

   		SEIndex++;
   		if( SEIndex >= 2)	SEIndex = 0;
    }
    
    public void Stop()
    {
//        Debug.Log("stop " + ch + " " );
		foreach(AudioSource source in AS)
		{
            source.Stop();
	    }
    }
}
