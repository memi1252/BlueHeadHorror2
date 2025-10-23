using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Thunder : MonoBehaviour
{
    [SerializeField] private Light mDirLight;
    //private SoundManager mSoundManagerl
    private Coroutine mThunderCoroutine;
    private Color mPrevLightColor;
    private float mPrevLightIntensity;
    private float mPrevFogDensity;

    private float mOriginTimer;
    private float mCurrentTimer;
    private bool mIsAuto = false;
    
    [SerializeField] private float mAutoIntervalMin = 5f;
    [SerializeField] private float mAutoIntervalMax = 15f;

    private void Start()
    {
        //mSoundManager 
        StartAutoThunder(Random.Range(mAutoIntervalMin, mAutoIntervalMax));
    }
    
    public void StartAutoThunder(float timer)
    {
        mOriginTimer = timer;
        mCurrentTimer = mOriginTimer;
        mIsAuto = true;
    }

    public void StopAutoThunder()
    {
        mIsAuto = false;
    }

    private void Update()
    {
        if (!mIsAuto)
        {
            return;
        }
        mCurrentTimer -= Time.deltaTime;
        if (mCurrentTimer < 0)
        {
            float nextInterval = Random.Range(mAutoIntervalMin, mAutoIntervalMax);
            mOriginTimer = nextInterval;
            mCurrentTimer = mOriginTimer;
            RunThunder(Random.Range(2, 4));
        }
    }

    public void RunThunder(float delayTime)
    {
        if (mThunderCoroutine != null)
        {
            mDirLight.color = mPrevLightColor;
            mDirLight.intensity = mPrevLightIntensity;
            RenderSettings.fogDensity = mPrevFogDensity;
            StopCoroutine(mThunderCoroutine);
        }
        
        mPrevLightColor = mDirLight.color;
        mPrevLightIntensity = mDirLight.intensity;
        mPrevFogDensity = RenderSettings.fogDensity;
        
        mThunderCoroutine = StartCoroutine("ThunderCor", delayTime);
    }

    IEnumerator ThunderCor(float delayTime)
    {
        bool isFogActive = RenderSettings.fog;
        Debug.Log("1");
        yield return new WaitForSeconds(delayTime);
        Debug.Log("2");
        mDirLight.color = Color.white;
        mDirLight.intensity = 1;
        if (isFogActive)
        {
            RenderSettings.fogDensity = mPrevFogDensity * 0.5f;
        }

        yield return new WaitForSeconds(0.05f);

        mDirLight.color = mPrevLightColor;
        mDirLight.intensity = mPrevLightIntensity;

        if (isFogActive)
        {
            RenderSettings.fogDensity = mPrevFogDensity;
        }
    }
}
