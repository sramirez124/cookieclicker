using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutCookie : MonoBehaviour
{
    public bool creatingCookie;
    public static int cookieIncrease = 1;
    public int internalIncrease;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        internalIncrease = cookieIncrease;
        if ( creatingCookie == false)
        {
          creatingCookie = true;
          StartCoroutine(CreateTheCookie());
        }
    }

    IEnumerator CreateTheCookie()
    {
      GlobalCookies.cookieCount += internalIncrease;
      yield return new WaitForSeconds(1);
      creatingCookie = false;
    }
}
