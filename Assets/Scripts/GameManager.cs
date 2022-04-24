using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject baseball;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int totalBalls;
    [SerializeField] int ballCount = 0;

    bool isAuto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isAuto)
        {
            Debug.Log("2 - Spawn ball");
            Instantiate(baseball, spawnPoint.transform.position, baseball.transform.rotation);
            ballCount++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (isAuto)
            {
                // WIP - Destroy ball, if exists
                StopCoroutine(AutoSpawnLaunchBall());
            }


            isAuto = true;
            Debug.Log("3 - AUTO Spawn/launch ball");
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
        }
    }
}
