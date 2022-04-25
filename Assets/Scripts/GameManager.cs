using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isAuto)
        {
            Debug.Log("2 - Spawn ball");
            Instantiate(baseball, spawnPoint.transform.position, baseball.transform.rotation);
            ballCount++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isAuto)
            {
                // WIP - Destroy ball, if exists
                StopCoroutine(AutoSpawnLaunchBall());
            }


            isAuto = true;
            Debug.Log("a - AUTO Spawn/launch ball");
            StartCoroutine(AutoSpawnLaunchBall());
        }
    }

    IEnumerator AutoSpawnLaunchBall()
    {
        while(ballCount < totalBalls)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject ball = Instantiate(baseball, spawnPoint.transform.position, baseball.transform.rotation);

            yield return new WaitForSeconds(2.0f);
            ball.GetComponent<ThrowController>().ToggleShot();
            ballCount++;
            DisplayUI();
        }
    }

    void DisplayUI()
    {
        hitsText.text = $"Hits: {ballsHitCount}";
        totalsText.text = $"Total: {ballCount}/{totalBalls}";
    }
    public void IncrementBallHitCount()
    {
        ballsHitCount++;
        DisplayUI();
    }
}
