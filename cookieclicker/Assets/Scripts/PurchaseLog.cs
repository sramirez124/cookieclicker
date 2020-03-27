using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseLog : MonoBehaviour
{
    public GameObject AutoCookie;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartAutoCookie()
    {
      AutoCookie.SetActive(true);
      GlobalCash.cashCount -= GlobalUpgrades.bakerValue;
      GlobalUpgrades.bakerValue *= 2;
      GlobalUpgrades.realButton.interactable = false;
      GlobalUpgrades.bakerAutoPerSec += 1;
      GlobalUpgrades.numOfBakers += 1;
    }
}
