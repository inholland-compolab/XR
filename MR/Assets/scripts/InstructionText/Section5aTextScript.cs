using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section5aTextScript : MonoBehaviour
{
    public GameObject text1;
    public GameObject helpText;

    public GameObject helpButton;
    public GameObject unHelpButton;

    public GameObject helpMatrix;

    // Start is called before the first frame update
    void Start()
    {
        helpText.SetActive(false);
        unHelpButton.SetActive(false);
        helpMatrix.SetActive(false);
    }

    public void Text1ButtonPress()
    {
        text1.SetActive(false);
    }

    public void Section5aHelp()
    {
        helpButton.SetActive(false);
        helpText.SetActive(true);
        unHelpButton.SetActive(true);
        helpMatrix.SetActive(true);
    }

    public void Section5aUnHelp()
    {
        helpText.SetActive(false);
        unHelpButton.SetActive(false);
        helpButton.SetActive(true);
        helpMatrix.SetActive(false);
    }
}
