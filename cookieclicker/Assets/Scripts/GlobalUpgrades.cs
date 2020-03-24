using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUpgrades : MonoBehaviour
{
    public GameObject fakeButton;
    public GameObject realButton;
    public GameObject fakeText;
    public GameObject realText;
    public int currentCash;
    public static int bakerValue = 10;
    public static bool turnOffButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentCash = GlobalCash.cashCount;
        fakeText.GetComponent<Text>().text = "Hire New Baker - $" + bakerValue;
        realText.GetComponent<Text>().text = "Hire New Baker - $" + bakerValue;
        if (currentCash >= bakerValue)
        {
          fakeButton.SetActive(false);
          realButton.SetActive(true);
        }

        if (turnOffButton == true)
        {
          realButton.SetActive(false);
          fakeButton.SetActive(true);
          turnOffButton = false;
        }

    }
}
