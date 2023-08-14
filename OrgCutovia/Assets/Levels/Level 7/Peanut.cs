using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Peanut : MonoBehaviour
{
    public GameObject answerSheet, peanutContainer,lev1,lev2;
    public GameObject peanut1, peanut2, peanut3, peanut4, peanut5, peanut6, peanut7, peanut8, peanut9, peanut10, motherBasket,fatherBasket,childBasket;
    public GameObject[] fatherPeanutPos,motherPeanutPos,childPeanutPos;

    Vector3 initialPeanut1Position, initialPeanut2Position, initialPeanut3Position, initialPeanut4Position, initialPeanut5Position, initialPeanut6Position, initialPeanut7Position, initialPeanut8Position, initialPeanut9Position, initialPeanut10Position;
    /*public int targetMCount;
    public int targetFCount;
    public int targetCCount;*/
    int mCount = 0;
    int fCount = 0;
    int cCount = 0;
    bool peanut1Bool, peanut2Bool, peanut3Bool, peanut4Bool, peanut5Bool, peanut6Bool, peanut7Bool, peanut8Bool, peanut9Bool, peanut10Bool = false;
    private void OnEnable()
    {
        Debug.Log(motherPeanutPos.Length);
        mCount = 0;
        fCount = 0;
        cCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        initialPeanut1Position = peanut1.transform.position;
        initialPeanut2Position = peanut2.transform.position;
        initialPeanut3Position = peanut3.transform.position;
        initialPeanut4Position = peanut4.transform.position;
        initialPeanut5Position = peanut5.transform.position;
        initialPeanut6Position = peanut6.transform.position;
        initialPeanut7Position = peanut7.transform.position;
        initialPeanut8Position = peanut8.transform.position;
        initialPeanut9Position = peanut9.transform.position;
        initialPeanut10Position = peanut10.transform.position;

    }
    public void LoadSecondLevel()
    {
        StartCoroutine(DisplayLevel());
    }
    private IEnumerator DisplayLevel()
    {
        yield return new WaitForSeconds(2f);
        lev1.SetActive(false);
        lev2.SetActive(true);
    }

    public void GameCompleted()
    {
        TopGameManager.Instance.button.SetActive(true); //Enabling button
        StartCoroutine(DelayedLogRoutine());
    }
    private IEnumerator DelayedLogRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.UnloadSceneAsync("Level7");
    }
    private void Update()
    {
        if(fatherPeanutPos.Length==fCount && motherPeanutPos.Length==mCount && childPeanutPos.Length==cCount)
        {
            peanutContainer.SetActive(false);
            answerSheet.SetActive(true);
        }
    }
    public void DragPeanut1()
    { 
        peanut1.transform.position = Input.mousePosition;
    }
    public void DropPeanut1()
    {
        float motherDistance = Vector3.Distance(peanut1.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut1.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut1.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount<motherPeanutPos.Length )
        {
            peanut1.transform.position = peanut1.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut1.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut1Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount<fatherPeanutPos.Length)
        {
            peanut1.transform.position = peanut1.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut1.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut1Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut1.transform.position = peanut1.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut1.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut1Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            
            peanut1.transform.position = initialPeanut1Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut2()
    {
        peanut2.transform.position = Input.mousePosition;
    }
    public void DropPeanut2()
    {
        float motherDistance = Vector3.Distance(peanut2.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut2.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut2.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut2.transform.position = peanut2.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut2.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut2Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut2.transform.position = peanut2.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut2.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut2Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut2.transform.position = peanut2.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut2.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut2Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            peanut2.transform.position = initialPeanut2Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut3()
    {
        peanut3.transform.position = Input.mousePosition;
    }
    public void DropPeanut3()
    {
        float motherDistance = Vector3.Distance(peanut3.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut3.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut3.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut3.transform.position = peanut3.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut3.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut3Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut3.transform.position = peanut3.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut3.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut3Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut3.transform.position = peanut3.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut3.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut3Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            peanut3.transform.position = initialPeanut3Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut4()
    {
        peanut4.transform.position = Input.mousePosition;
    }
    public void DropPeanut4()
    {
        float motherDistance = Vector3.Distance(peanut4.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut4.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut4.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut4.transform.position = peanut4.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut4.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut4Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut4.transform.position = peanut4.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut4.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut4Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut4.transform.position = peanut4.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut4.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut4Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            
            peanut4.transform.position = initialPeanut4Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut5()
    {
        peanut5.transform.position = Input.mousePosition;
    }
    public void DropPeanut5()
    {
        float motherDistance = Vector3.Distance(peanut5.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut5.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut5.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut5.transform.position = peanut5.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut5.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut5Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut5.transform.position = peanut5.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut5.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut5Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut5.transform.position = peanut5.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut5.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut5Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            peanut5.transform.position = initialPeanut5Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut6()
    {
        peanut6.transform.position = Input.mousePosition;
    }
    public void DropPeanut6()
    {
        float motherDistance = Vector3.Distance(peanut6.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut6.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut6.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut6.transform.position = peanut6.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut6.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut6Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut6.transform.position = peanut6.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut6.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut6Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut6.transform.position = peanut6.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut6.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut6Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            Debug.Log(mCount + "" + fCount + "" + cCount);
            peanut6.transform.position = initialPeanut6Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut7()
    {
        peanut7.transform.position = Input.mousePosition;
    }
    public void DropPeanut7()
    {
        float motherDistance = Vector3.Distance(peanut7.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut7.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut7.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut7.transform.position = peanut7.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut7.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut7Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut7.transform.position = peanut7.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut7.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut7Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut7.transform.position = peanut7.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut7.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut7Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            Debug.Log(mCount + "" + fCount + "" + cCount);
            peanut7.transform.position = initialPeanut7Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut8()
    {
        peanut8.transform.position = Input.mousePosition;
    }
    public void DropPeanut8()
    {
        float motherDistance = Vector3.Distance(peanut8.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut8.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut8.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut8.transform.position = peanut8.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut8.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut8Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut8.transform.position = peanut8.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut8.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut8Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut8.transform.position = peanut8.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut8.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut8Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            Debug.Log(mCount + "" + fCount + "" + cCount);
            peanut8.transform.position = initialPeanut8Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut9()
    {
        peanut9.transform.position = Input.mousePosition;
    }
    public void DropPeanut9()
    {
        float motherDistance = Vector3.Distance(peanut9.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut9.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut9.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut9.transform.position = peanut9.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut9.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut9Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut9.transform.position = peanut9.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut9.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut9Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut9.transform.position = peanut9.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut9.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut9Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            Debug.Log(mCount + "" + fCount + "" + cCount);
            peanut9.transform.position = initialPeanut9Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }

    public void DragPeanut10()
    {
        peanut10.transform.position = Input.mousePosition;
    }
    public void DropPeanut10()
    {
        float motherDistance = Vector3.Distance(peanut10.transform.position, motherBasket.transform.position);
        float fatherDistance = Vector3.Distance(peanut10.transform.position, fatherBasket.transform.position);
        float childDistance = Vector3.Distance(peanut10.transform.position, childBasket.transform.position);
        if (motherDistance < 300 && mCount < motherPeanutPos.Length)
        {
            peanut10.transform.position = peanut10.transform.position;
            motherPeanutPos[mCount].SetActive(true);
            peanut10.SetActive(false);
            mCount++;
            Score.scoreNumber += 1;
            peanut10Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (fatherDistance < 300 && fCount < fatherPeanutPos.Length)
        {
            peanut10.transform.position = peanut10.transform.position;
            fatherPeanutPos[fCount].SetActive(true);
            peanut10.SetActive(false);
            fCount++;
            Score.scoreNumber += 1;
            peanut10Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else if (childDistance < 300 && cCount < childPeanutPos.Length)
        {
            peanut10.transform.position = peanut10.transform.position;
            childPeanutPos[cCount].SetActive(true);
            peanut10.SetActive(false);
            cCount++;
            Score.scoreNumber += 1;
            peanut10Bool = true;
            /*source.clip = correct[Random.Range(0, correct.Length)];
            source.Play();*/
        }
        else
        {
            Debug.Log(mCount + "" + fCount + "" + cCount);
            peanut10.transform.position = initialPeanut10Position;
            /*source.clip = incorrect;
            source.Play();*/
        }
    }
}
