using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCountManager : MonoBehaviour
{
    [SerializeField] List<GameObject> minyons;
    [SerializeField] int minyonCount = 1;
    [SerializeField] int newMinyonCount;
    int minyonMathFactor;
    Vector3 spawnPosition;

    void Update()
    {
        ActiviteMinyon();
        DeActiviteMinyon();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Untagged")
            return;
        spawnPosition= other.transform.position;
        minyonMathFactor = int.Parse(other.name);
        SendMessage(other.tag);
    }
    void ActiviteMinyon()
    {
        foreach (var minyon in minyons)
        {
            if (minyonCount < newMinyonCount && !minyon.activeInHierarchy)
            {
                minyon.SetActive(true);
                minyon.transform.position = spawnPosition;
                minyonCount++;
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
