using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUpgrades : MonoBehaviour
{
    public static Button realButton;
    public GameObject realText;
    public int currentCash;
    public static int bakerValue = 1;
    public GameObject bakerStats;
    public static int numOfBakers;
    public static int bakerAutoPerSec;
    // Start is called before the first frame update
    void Start()
    {
      realButton = GetComponent<Button>();
      realText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      currentCash = GlobalCash.cashCount;
      bakerStats.GetComponent<Text>().text = "Bakers: " + numOfBakers + " @ " + bakerAutoPerSec +" Per Second";
      realText.GetComponent<Text>().text = "Hire New Baker - $" + bakerValue;
      TurnOn();
    }

    public void TurnOn()
    {

      if (currentCash >= bakerValue)
      {
        realButton.interactable = true;
      }
      else
      {
        realButton.interactable = false;
      }
    }
}
