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
    [SerializeField] private int cookieCount;
    [SerializeField] private GameObject cookieDisplay;

    // GlobalUpgrades variables
    [Header("Upgrade Settings")]
    [SerializeField] private Button bakerButton;
    [SerializeField] private GameObject bakerText;
    [SerializeField] private GameObject bakerStats;
    [SerializeField] private int numOfBakers;
    [SerializeField] private int bakerAutoPerSec;

    // GlobalCash variables
    [Header("Money Settings")]
    [SerializeField] private int cashCount;
    [SerializeField] private GameObject CashDisplay;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject statusBox;

    [Header("AutoCookie Settings")]
    public bool creatingCookie;
    public int cookieIncrease = 1;
    public int internalIncrease; // figure out what this does

    // Cost for inital upgrade variables
    [Header("Inital Upgrade Cost")]
    [SerializeField] private int bakerValue = 1;
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
      TurnOn();


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

    public void TurnOn() // used to activate the baker upgrade. Needs to be made to work with out
    {

      if (cashCount >= bakerValue)
      {
        bakerButton.interactable = true;
      }
      else
      {
        bakerButton.interactable = false;
      }
    }

    public void AutoCookie() // I have no clue what internalIncrease does but it works for now
    {
        cookieIncrease = bakerAutoPerSec;
        internalIncrease = cookieIncrease;
        creatingCookie = true;
        StartCoroutine(CreateTheCookie());
    }

    public void StartAutoCookie()
    {
      cashCount -= bakerValue;
      bakerValue *= 2;
      bakerButton.interactable = false;
      bakerAutoPerSec += 1;
      numOfBakers += 1;
      AutoCookie();
    }

    IEnumerator CreateTheCookie()
    {
      cookieCount += internalIncrease;
      yield return new WaitForSeconds(1);
      creatingCookie = false;
      AutoCookie();
    }
}
