using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip _tossClip;
    [SerializeField] GameObject _baseball;
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] GameObject _popup;
    [SerializeField] GameObject _gameOn;
    [SerializeField] GameObject _gameOff;
    [SerializeField] GameObject _practice;
    [SerializeField] GameObject _congratsText;
    [SerializeField] TextMeshProUGUI _hitsText;
    [SerializeField] TextMeshProUGUI _totalsText;

    AudioSource _audioPlayer;
    bool _isAuto;
    int _ballCount = 0;
    int _ballsHitCount = 0;
    int _totalBalls = 10;

    // Start is called before the first frame update
    void Start()
    {
        _audioPlayer = GameObject.Find("Global Audio").GetComponent<AudioSource>();
        DisplayUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            _popup.SetActive(!_popup.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Turn_practice();
            _isAuto = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && _practice.activeSelf)
        {
            _audioPlayer.PlayOneShot(_tossClip, 0.3f);
            Instantiate(_baseball, _spawnPoint.transform.position, _baseball.transform.rotation)
                .GetComponent<ThrowController>()
                .ToggleShot();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_isAuto)
            {
                Turn_gameOff();
                _isAuto = false;
                StopCoroutine(AutoSpawnLaunchBall());
                return;
            }

            _isAuto = true;
            Turn_gameOn();
            StartCoroutine(AutoSpawnLaunchBall());
        }
    }

    IEnumerator AutoSpawnLaunchBall()
    {
        while (_ballCount < _totalBalls && _isAuto)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject ball = Instantiate(_baseball, _spawnPoint.transform.position, _baseball.transform.rotation);

            yield return new WaitForSeconds(2.0f);
            _audioPlayer.PlayOneShot(_tossClip, 0.3f);
            ball.GetComponent<ThrowController>().ToggleShot();
            _ballCount++;
            DisplayUI();
        }
        if (_ballCount == _totalBalls && _isAuto)
        {
            yield return new WaitForSeconds(1.5f);
            _congratsText.SetActive(true);
            _congratsText.GetComponent<TextMeshProUGUI>().text = $"Congrats!! <br>{ResultPercent()}% hit accuracy with {DisplayResultHits()}";
            yield return new WaitForSeconds(5.0f);
            _congratsText.SetActive(false);
        }
        _isAuto = false;

        if (!_practice.activeSelf)
            Turn_gameOff();
    }
    string DisplayResultHits()
    {
        if (_ballsHitCount != 1)
            return $"{_ballsHitCount} hits";
        return $"{_ballsHitCount} hit";
    }

    double ResultPercent()
    {
        return Math.Round((double)_ballsHitCount / _totalBalls * 100, 0);
    }
    void DisplayUI()
    {
        _hitsText.text = $"Hits: {_ballsHitCount}";
        _totalsText.text = $"Total: {_ballCount}/{_totalBalls}";
    }
    public void IncrementBallHitCount()
    {
        if (!_gameOn.activeSelf)
            return;
        _ballsHitCount++;
        DisplayUI();
    }

    void Turn_gameOn()
    {
        _gameOn.SetActive(true);
        _gameOff.SetActive(false);
        _practice.SetActive(false);
    }
    void Turn_gameOff()
    {
        _gameOn.SetActive(false);
        _gameOff.SetActive(true);
        _practice.SetActive(false);
    }
    void Turn_practice()
    {
        _gameOn.SetActive(false);
        _gameOff.SetActive(false);
        _practice.SetActive(true);
    }
}
