using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCookies : MonoBehaviour
{

    public static int cookieCount;
    public GameObject cookieDisplay;
    public int internalCookie;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        internalCookie = cookieCount;
        cookieDisplay.GetComponent<Text>().text = "Cookies: " + internalCookie;
    }
}
