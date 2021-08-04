using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TakeCoin : MonoBehaviour
{
    
    public GameObject TenPointsMsg;
    public GameObject TwentyFivePointsMsg;
    public GameObject FiftyPointsMsg;
    public GameObject SeventyFivePointsMsg;
    public GameObject OneHundred;
    public int seconds = 1;
    void Start()
    {
        TenPointsMsg.SetActive(false);
        TwentyFivePointsMsg.SetActive(false);
        FiftyPointsMsg.SetActive(false);
        SeventyFivePointsMsg.SetActive(false);
        OneHundred.SetActive(false);
    }
    private float coin = 0;
    public TextMeshProUGUI textCoins;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Coin")
        {
            coin++;
            textCoins.text = coin.ToString();
            Destroy(other.gameObject);
        }
        if (coin == 10)
        {
            TenPointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 25)
        {
            TwentyFivePointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 50)
        {
            FiftyPointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 75)
        {
            SeventyFivePointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 100)
        {
            OneHundred.SetActive(true);
            StartCoroutine(WaitForSec());

        }

        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(1.5f);

            TenPointsMsg.SetActive(false);
            TwentyFivePointsMsg.SetActive(false);
            FiftyPointsMsg.SetActive(false);
            SeventyFivePointsMsg.SetActive(false);
            OneHundred.SetActive(false);
        }
    }
}
