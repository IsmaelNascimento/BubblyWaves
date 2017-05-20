using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateButtons : MonoBehaviour
{
    public GameObject[]     goPoints;
    public GameObject       goInstantiate;
    private int             iRandom;
    public int              iScore;
    public int              iRightID;
    public int              iLife = 3;
    private float           fTime;
    public Text             txtScore;
    public Text             txtLife;
    public Image            imgButtonRight;
    public Sprite[]         sprButtons;
    public Slider           sliderProgress;
    public float            iTimeInstantiate;
    public float            iTimeID;
    private float           fTimeID;
    public int              iNextGameplay;
    public GameObject       goWin;
    public Text             txtScorePanelWin;
    public GameObject       goGameOver;
    public Text             txtRecord;
    private int             iRecord = 0;
    public Text             txtScoreGameOver;
    public GameObject[]     goStars;
    public AudioSource      asBubble;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        fTime += Time.deltaTime;

        fTimeID += Time.deltaTime;

        if (fTime > iTimeInstantiate)
        {
            Instantiate(goInstantiate, goPoints[Random.Range(0, 5)].transform.position, Quaternion.identity).transform.SetParent(goPoints[Random.Range(0, 5)].transform);

            fTime = 0;
            
            if (sliderProgress.GetComponent<Slider>().value == 100)
            {
                goWin.SetActive(true);
            }
        }

        ChangeID();

        imgButtonRight.GetComponent<Image>().sprite = sprButtons[iRightID];

        txtScore.GetComponent<Text>().text = "Score: " + iScore.ToString();

        txtLife.GetComponent<Text>().text = "Life: " + iLife.ToString();

        txtScoreGameOver.GetComponent<Text>().text = "Score: " + iScore.ToString();

        if(iLife < 1)
        {
            goGameOver.SetActive(true);
        }

        txtScorePanelWin.GetComponent<Text>().text = "Score: " + iScore.ToString();

        //RecordScore();
        Stars();
    }

    private void ChangeID()
    {
        if (fTimeID > iTimeID)
        {
            iRightID = Random.Range(0, 5);
            fTimeID = 0;
        }
    }

    public void NextGameplay(string sNextGameplay)
    {
        SceneManager.LoadScene(sNextGameplay);
    }

    private void RecordScore()
    {
        if(iScore > iRecord)
        {
            iRecord = iScore;

            PlayerPrefs.SetInt("iRecord", iRecord); 

            Debug.Log("Entrou no if = " + iRecord);
        }

        txtRecord.GetComponent<Text>().text = "Record: " + PlayerPrefs.GetInt("iRecord");

        Debug.Log("iRecord = " + PlayerPrefs.GetInt("iRecord"));
    }

    private void Stars()
    {
        switch (iLife)
        {
            case 1:
                goStars[0].SetActive(true);
                goStars[1].SetActive(false);
                goStars[2].SetActive(false);
                break;
            case 2:
                goStars[0].SetActive(true);
                goStars[1].SetActive(true);
                goStars[2].SetActive(false);
                break;
            case 3:
                goStars[0].SetActive(true);
                goStars[1].SetActive(true);
                goStars[2].SetActive(true);
                break;
        }
    }
}
