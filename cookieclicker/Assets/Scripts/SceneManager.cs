using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

    [Header("Cookie Settings")]
    [SerializeField] private float cookieCount;
    [SerializeField] private GameObject cookieDisplay;
    [SerializeField] private GameObject upgradeStats;


    [Header("Click Settings")]
    [SerializeField] private Button clickButton;
    [SerializeField] private GameObject clickText;
    [SerializeField] private float numOfClicks;
    [SerializeField] private float cookiesPerClick = 1; // just gives more cookies per click

    [Header("Baker Settings")]
    [SerializeField] private Button bakerButton;
    [SerializeField] private GameObject bakerText;
    [SerializeField] private float numOfBakers;
    [SerializeField] private float bakerAutoPerSec;

    [Header("Oven Settings")]
    [SerializeField] private Button ovenButton;
    [SerializeField] private GameObject ovenText;
    [SerializeField] private float numOfOvens;
    [SerializeField] private float ovenAutoPerSec;

    [Header("Ad Campaign Settings")]
    [SerializeField] private Button adCampaignButton;
    [SerializeField] private GameObject adCampaignText;
    [SerializeField] private float moneyPerSell = 1;
    [SerializeField] private float numOfBakeries = 1;

    [Header("New Bakery Settings")]
    [SerializeField] private Button newBakeryButton;
    [SerializeField] private GameObject newBakeryText;

    [Header("AutoCookie Settings")]
    public bool creatingCookie;
    public float cookieIncrease = 0;

    [Header("Money Settings")] // not working for some reason
    [SerializeField] private static float cashCount;
    [SerializeField] private GameObject CashDisplay;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject statusBox;

    // Cost for inital upgrade variables
    [Header("Inital Upgrade Cost")]
    [SerializeField] private float clickValue = 20;
    [SerializeField] private float bakerValue = 200;
    [SerializeField] private float ovenValue = 500;
    [SerializeField] private float adCampaignValue = 4000;
    [SerializeField] private float newBakeryValue = 10000;
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
      upgradeStats.GetComponent<Text>().text =
      "Cookies per click: " + cookiesPerClick +
      "        Bakers: " + numOfBakers + " @ " + bakerAutoPerSec + " Per Second   " +
      "Ovens: " + numOfOvens + " @ " + ovenAutoPerSec + " Per Second    " +
      "Number of Bakeries: " + numOfBakeries;

      // Upgrade Button Text Updates
      clickText.GetComponent<Text>().text = "Add Cookies Per Click - $" + clickValue;
      bakerText.GetComponent<Text>().text = "Hire New Baker - $" + bakerValue;
      ovenText.GetComponent<Text>().text = "Buy New Oven - $" + ovenValue;
      adCampaignText.GetComponent<Text>().text = "Ad Campaign - $" + adCampaignValue;
      newBakeryText.GetComponent<Text>().text = "New Bakery - $" + newBakeryValue;

      TurnOn(bakerValue, bakerButton);
      TurnOn(ovenValue, ovenButton);
      TurnOn(clickValue, clickButton);
      TurnOn(adCampaignValue, adCampaignButton);
      TurnOn(newBakeryValue, newBakeryButton);


    }

    public void ClickToMake() // If clicked, you get a cookie
    {
      cookieCount += cookiesPerClick;
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
        cashCount += cookieCount * moneyPerSell;
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

    public void StartAutoCookie(string upgradeNumber) // this is what starts the auto cookie process
    {
      switch (upgradeNumber)
      {
        case "1":
        cashCount -= bakerValue;
        bakerValue *= 2f;
        bakerButton.interactable = false;
        bakerAutoPerSec += 0.5f ;
        cookieIncrease += bakerAutoPerSec;
        numOfBakers += 1;
        AutoCookie();
        break;

        case "2":
        cashCount -= ovenValue;
        ovenValue *= 2;
        ovenButton.interactable = false;
        ovenAutoPerSec += 2f;
        cookieIncrease += ovenAutoPerSec;
        numOfOvens += 1;
        AutoCookie();
        break;

        case "3":
        cashCount -= clickValue;
        clickValue *= 4;
        clickButton.interactable = false;
        numOfClicks += 1;
        cookiesPerClick++;
        break;

        case "4":
        cashCount -= adCampaignValue;
        adCampaignValue *= 4;
        adCampaignButton.interactable = false;
        moneyPerSell *= 2;
        break;

        case "5":
        cashCount -= newBakeryValue;
        adCampaignValue *= 10;
        bakerValue *= 10;
        bakerAutoPerSec *= 2f;
        numOfBakers *= 2;
        ovenValue *= 10;
        ovenAutoPerSec *= 2f;
        numOfOvens *= 2;
        adCampaignButton.interactable = false;
        moneyPerSell *= 2;
        newBakeryValue *= 20;
        break;
      }

    }

    public void AutoCookie()
    {
      creatingCookie = true;
      StartCoroutine(CreateTheCookie());
    }

    IEnumerator CreateTheCookie()
    {
      cookieCount += cookieIncrease;
      yield return new WaitForSeconds(1);
      creatingCookie = false;
      AutoCookie();
    }

    /*public void StartAutoCookie(float upgradeNumber) // this is what starts the auto cookie process
    {
      cashCount -= bakerValue;
      bakerValue *= 2;
      bakerButton.interactable = false;
      bakerValue += 0.5F;
      numOfBakers += 1;
      AutoCookie();
    }*/

}
