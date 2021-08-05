using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TakeCoin : MonoBehaviour
{
    public AudioClip CoinTake;
    AudioSource audioSource;

    public AudioClip ReachedGoal;


    public ParticleSystem CoinPickUpEffect;

    public GameObject TenPointsMsg;
    public GameObject TwentyFivePointsMsg;
    public GameObject FiftyPointsMsg;
    public GameObject SeventyFivePointsMsg;
    public GameObject OneHundred;
    public int seconds = 1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();

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

            audioSource.PlayOneShot(CoinTake, 10.0F);
            CoinPickUpEffect.Emit(200);
            coin++;
            textCoins.text = coin.ToString();
            
            Destroy(other.gameObject);
        }
        if(coin == 10)
        {
            audioSource.PlayOneShot(ReachedGoal, 2F);
            TenPointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());
        }
        if (coin == 25)
        {
            audioSource.PlayOneShot(ReachedGoal, 2F);
            TwentyFivePointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 50)
        {
            audioSource.PlayOneShot(ReachedGoal, 2F);
            FiftyPointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 75)
        {
            audioSource.PlayOneShot(ReachedGoal, 2F);
            SeventyFivePointsMsg.SetActive(true);
            StartCoroutine(WaitForSec());

        }
        if (coin == 100)
        {
            audioSource.PlayOneShot(ReachedGoal, 2F);
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
