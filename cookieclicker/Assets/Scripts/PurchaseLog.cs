using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
      GlobalUpgrades.turnOffButton = true;
    }
}
