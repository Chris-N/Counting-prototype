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
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isAuto)
        {
            Debug.Log("1 - Spawn, SHOOT!, Audio: shoot!");
            Instantiate(baseball, spawnPoint.transform.position, baseball.transform.rotation)
                .GetComponent<ThrowController>()
                .ToggleShot();
            ballCount++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isAuto)
            {
                isAuto = false;
                StopCoroutine(AutoSpawnLaunchBall());
                return;
            }


            isAuto = true;
            Debug.Log("A - AUTO Spawn/launch ball");
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
