using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TakeCoin : MonoBehaviour
{


    public ParticleSystem CoinPickUpEffect;

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
        
        if (other.transform.tag == "Coin")
        {
            FindObjectOfType<SoundManager>().Play("CoinTake");
            CoinPickUpEffect.Emit(200);
            coin++;
            textCoins.text = coin.ToString();
            
            Destroy(other.gameObject);
        }
        if(coin == 10)
        {
            FindObjectOfType<SoundManager>().Play("Raise");
            TenPointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());
        }
        if (coin == 25)
        {
            FindObjectOfType<SoundManager>().Play("Raise");
      
            TwentyFivePointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 50)
        {
            FindObjectOfType<SoundManager>().Play("Raise");
        
            FiftyPointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 75)
        {
            FindObjectOfType<SoundManager>().Play("Raise");
       
            SeventyFivePointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 100)
        {
            FindObjectOfType<SoundManager>().Play("Raise");
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
