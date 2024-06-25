using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnHelpScript : MonoBehaviour
{
    public GameObject unHelpButton;
    public GameObject helpButton;
    public GameObject helpObject;
    public GameObject helpText;

    public void HelpToggleOff()
    {
        unHelpButton.SetActive(false);
        helpButton.SetActive(true);
        helpObject.SetActive(false);
        helpText.SetActive(false);
    }
}