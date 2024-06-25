using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public GameObject unHelpButton;
    public GameObject helpButton;
    public GameObject helpObject;
    public GameObject helpText;

    // Start is called bedore the first frame update
    void Start()
    {
        unHelpButton.SetActive(false);
        helpObject.SetActive(false);
        helpText.SetActive(false);
    }

    public void HelpToggleOn()
    {
        unHelpButton.SetActive(true);
        helpButton.SetActive(false);
        helpObject.SetActive(true);
        helpText.SetActive(true);
    }
}