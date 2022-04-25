using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPopup : MonoBehaviour
{
    public void OpenInfoPopup()
    {
        gameObject.SetActive(true);
    }
    public void CloseInfoPopup()
    {
        gameObject.SetActive(false);
    }
    public void ToggleInfoPopup()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
