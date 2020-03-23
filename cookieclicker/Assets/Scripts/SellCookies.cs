using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCookies : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
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
      GlobalCookies.cookieCount -= 1;
      GlobalCash.cashCount += 1;
    }
}
