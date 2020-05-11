using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    /* Right now I am in the process of putting all Global scripts into one script called SceneManager
       This is to help keep the amount of scripts in the game low  and everything in one place */

    // GlobalCookies variables
    [Header("Cookie Settings")]
    [SerializeField] private float cookieCount;
    [SerializeField] private GameObject cookieDisplay;

    // GlobalUpgrades variables
    [Header("Upgrade Settings")]
    [SerializeField] private Button bakerButton;
    [SerializeField] private GameObject bakerText;
    [SerializeField] private GameObject bakerStats;
    [SerializeField] private float numOfBakers;
    [SerializeField] private float bakerAutoPerSec;

    // GlobalCash variables
    [Header("Money Settings")]
    [SerializeField] private static float cashCount;
    [SerializeField] private GameObject CashDisplay;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject statusBox;

    [Header("AutoCookie Settings")]
    public bool creatingCookie;
    public float cookieIncrease = 1;
    public float internalIncrease;

    // Cost for inital upgrade variables
    [Header("Inital Upgrade Cost")]
    [SerializeField] private float bakerValue = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // Cookie Display Updates
      cookieDisplay.GetComponent<Text>().text = "Cookies: " + cookieCount;

      // Money Display Updates
      CashDisplay.GetComponent<Text>().text = "Cash: $" + cashCount;

      // Upgrades Display Updates
      bakerStats.GetComponent<Text>().text = "Bakers: " + numOfBakers + " @ " + bakerAutoPerSec +" Per Second";
      bakerText.GetComponent<Text>().text = "Hire New Baker - $" + bakerValue;
      TurnOn(bakerValue, bakerButton);


    }

    public void ClickToMake() // If clicked, you get a cookie
    {
      cookieCount += 1;
    }

    public void ClickToSell() // If clicked, sell your cookies
    {
      if (cookieCount == 0)
      {
        statusBox.GetComponent<Text>().text = "Not enough cookies to sell.";
        statusBox.GetComponent<Animation>().Play("StatusAnim");
      }
      else
      {
        cashCount += cookieCount;
        cookieCount -= cookieCount;
      }

    }

    public void TurnOn(float upgradeValue, Button upgradeButton)
    {
      if (cashCount >= upgradeValue)
      {
        upgradeButton.interactable = true;
      }
      else
      {
        upgradeButton.interactable = false;
      }
    }

    public void StartAutoCookie(float upgradeValue, Button upgradeButton, float upgradePerSec) // this is what starts the auto cookie process
      {
        cashCount -= upgradeValue;
        upgradeValue *= 2;
        upgradeButton.interactable = false;
        upgradePerSec += 0.5F;
        numOfBakers += 1;
        AutoCookie(upgradePerSec);
      }


    public void AutoCookie(float upgradePerSec)
    {
        cookieIncrease = upgradePerSec;
        internalIncrease = cookieIncrease;
        creatingCookie = true;
        StartCoroutine(CreateTheCookie());
    }


    IEnumerator CreateTheCookie()
    {
      cookieCount += internalIncrease;
      yield return new WaitForSeconds(1);
      creatingCookie = false;
      AutoCookie(bakerAutoPerSec);
    }
}
