using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject baseball;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int totalBalls;
    [SerializeField] int ballCount = 0;
    [SerializeField] int ballsHitCount = 0;
    [SerializeField] GameObject popup;
    [SerializeField] TextMeshProUGUI hitsText;
    [SerializeField] TextMeshProUGUI totalsText;
    [SerializeField] GameObject gameOn;
    [SerializeField] GameObject gameOff;
    [SerializeField] GameObject practice;

    bool isAuto;

    // Start is called before the first frame update
    void Start()
    {
        DisplayUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            popup.SetActive(!popup.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TurnPractice();
            isAuto = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && practice.activeSelf)
        {
            Debug.Log("1 - Spawn, SHOOT!, Audio: shoot!");
            Instantiate(baseball, spawnPoint.transform.position, baseball.transform.rotation)
                .GetComponent<ThrowController>()
                .ToggleShot();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isAuto)
            {
                TurnGameOff();
                isAuto = false;
                StopCoroutine(AutoSpawnLaunchBall());
                return;
            }

            isAuto = true;
            TurnGameOn();
            StartCoroutine(AutoSpawnLaunchBall());
        }
    }

    IEnumerator AutoSpawnLaunchBall()
    {
        while (ballCount < totalBalls && isAuto)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject ball = Instantiate(baseball, spawnPoint.transform.position, baseball.transform.rotation);

            yield return new WaitForSeconds(2.0f);
            ball.GetComponent<ThrowController>().ToggleShot();
            ballCount++;
            DisplayUI();
        }
        isAuto = false;

        if(!practice.activeSelf)
            TurnGameOff();
    }

    void DisplayUI()
    {
        hitsText.text = $"Hits: {ballsHitCount}";
        totalsText.text = $"Total: {ballCount}/{totalBalls}";
    }
    public void IncrementBallHitCount()
    {
        if (!gameOn.activeSelf)
            return;
        ballsHitCount++;
        DisplayUI();
    }

    void TurnGameOn()
    {
        gameOn.SetActive(true);
        gameOff.SetActive(false);
        practice.SetActive(false);
    }
    void TurnGameOff()
    {
        gameOn.SetActive(false);
        gameOff.SetActive(true);
        practice.SetActive(false);
    }
    void TurnPractice()
    {
        gameOn.SetActive(false);
        gameOff.SetActive(false);
        practice.SetActive(true);
    }
}
