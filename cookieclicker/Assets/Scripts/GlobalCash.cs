using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCash : MonoBehaviour
{

    public static int cashCount;
    public GameObject CashDisplay;
    public int internalCash;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        internalCash = cashCount;
        CashDisplay.GetComponent<Text>().text = "Cash: $" + internalCash;
    }
}
