using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingText : MonoBehaviour
{
    public GameObject uiObject;
    public int seconds = 1;
    void Start()
    {
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            uiObject.SetActive(true);
            StartCoroutine(WaitForSec());
        }
        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(0.4f);
            uiObject.SetActive(false);
        }
    }
}
