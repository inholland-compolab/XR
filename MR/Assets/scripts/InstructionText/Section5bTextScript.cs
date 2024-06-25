using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section5bTextScript : MonoBehaviour
{ 
    public GameObject text1;
    public GameObject helpText;

    public GameObject helpButton;
    public GameObject unHelpButton;
    public GameObject switchButton;
    public GameObject unSwitchButton;

    public GameObject helpMatrix;
    public GameObject cubeMatrices;
    public GameObject cubeDegreeMatrices;

    // Start is called before the first frame update
    void Start()
    {
        helpText.SetActive(false);
        unHelpButton.SetActive(false);
        helpMatrix.SetActive(false);
        switchButton.SetActive(false);
        cubeDegreeMatrices.SetActive(false);
    }

    public void Text1ButtonPress()
    {
        text1.SetActive(false);
    }

    public void Section5bHelp()
    {
        helpButton.SetActive(false);
        helpText.SetActive(true);
        unHelpButton.SetActive(true);
        helpMatrix.SetActive(true);
    }

    public void Section5bUnHelp()
    {
        helpText.SetActive(false);
        unHelpButton.SetActive(false);
        helpButton.SetActive(true);
        helpMatrix.SetActive(false);
    }

    public void SwitchButtonPress()
    {
        switchButton.SetActive(false);
        unSwitchButton.SetActive(true);
        cubeMatrices.SetActive(false);
        cubeDegreeMatrices.SetActive(true);
    }

    public void UnSwitchButtonPress()
    {
        unSwitchButton.SetActive(false);
        switchButton.SetActive(true);
        cubeDegreeMatrices.SetActive(false);
        cubeMatrices.SetActive(true);
    }
}
