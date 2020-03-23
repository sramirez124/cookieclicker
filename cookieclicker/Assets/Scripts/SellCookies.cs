using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellCookies : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject statusBox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickTheButton()
    {
      if (GlobalCookies.cookieCount == 0)
      {
        statusBox.GetComponent<Text>().text = "Not enough cookies to sell.";
        statusBox.GetComponent<Animation>().Play("StatusAnim");
      }
      else
      {
        GlobalCookies.cookieCount -= 1;
        GlobalCash.cashCount += 1;
      }

    }
}
