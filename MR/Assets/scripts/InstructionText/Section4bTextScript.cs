using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section4bTextScript : MonoBehaviour
{
    public GameObject text2;
    public GameObject text3;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        text3.SetActive(false);
        continueButton.SetActive(false);
    }

    public void Text2ButtonPress()
    {
        text2.SetActive(false);
        text3.SetActive(true);
    }

    public void Text3ButtonPress()
    {
        text3.SetActive(false);
    }
}
