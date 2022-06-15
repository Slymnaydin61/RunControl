using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCountManager : MonoBehaviour
{
    [SerializeField] List<GameObject> minyons;
    [SerializeField] int minyonCount = 1;
    [SerializeField] int newMinyonCount;
    int minyonMathFactor;
    float minyonSpawnTimer;
    Vector3 spawnPosition;

    void Update()
    {
        ActiviteMinyon();
        DeActiviteMinyon();
        DelayMinionsSpawn();
        FixMinionCount();
    }
    void FixMinionCount()
    {
        if (minyonCount < 1)
            minyonCount = 1;
    }
    void OnTriggerEnter(Collider other)
    {
        minyonSpawnTimer = 0.4f;
        if(other.tag== "Untagged")
            return;
        spawnPosition= other.transform.position;
        minyonMathFactor = int.Parse(other.name);
        SendMessage(other.tag);
    }
    void DelayMinionsSpawn()
    {
        minyonSpawnTimer-=Time.deltaTime;
    }
    void ActiviteMinyon()
    {
        foreach (var minyon in minyons)
        {
            if (minyonCount < newMinyonCount && !minyon.activeInHierarchy&&minyonSpawnTimer<0)
            {
                minyon.SetActive(true);
                minyon.transform.position = spawnPosition;
                minyonCount++;
                minyonSpawnTimer = 0.4f;
            }
        }
    }
    void DeActiviteMinyon()
    {
        foreach (var minyon in minyons)
            if (newMinyonCount < minyonCount && minyon.activeInHierarchy)
            {
                minyon.SetActive(false);
                minyonCount--;
            }
    }
    void MultiplyMinyonCount()
    {

        newMinyonCount = minyonCount * minyonMathFactor;

    }
    void IncraseMinyonCount()
    {


        newMinyonCount = minyonCount + minyonMathFactor;

    }
    void DivedeMinyonCount()
    {

        newMinyonCount = minyonCount / minyonMathFactor;
    }
    void DecreaseMinyonCount()
    {

        newMinyonCount = minyonCount - minyonMathFactor;

    }

}
