using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public int              iButtonID;
    public CreateButtons    createButtons;
    private GameObject      goDestroyLimit;
    public int              iVelocity;
    public int              iValueSlider;
    public int              iScore;


    // Use this for initialization
    void Start()
    {
        iButtonID = Random.Range(0, 5);
        createButtons = GameObject.Find("Canvas").GetComponent<CreateButtons>();
        goDestroyLimit = GameObject.Find("goDestroyLimit");
        PlayerPrefs.SetInt("bInstructions", 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, iVelocity, 0); //Moviment

        if (gameObject.transform.position.y >= goDestroyLimit.transform.position.y)
        {
            Destroy(gameObject);
        }

        gameObject.GetComponent<Image>().sprite = createButtons.sprButtons[iButtonID];
    }

    public void Click()
    {
        createButtons.asBubble.Play();

        if (createButtons.iRightID == iButtonID)
        {
            createButtons.iScore += iScore;
            createButtons.sliderProgress.GetComponent<Slider>().value += iValueSlider;
            Debug.Log("Slider = " + iValueSlider);
        }
        else
        {
            createButtons.iLife--;
        }

        Destroy(gameObject);
    }
}
