using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControll : MonoBehaviour
{
    public static bool isDead;
    public static bool isWin;
    public GameObject deadImage;
    public GameObject winImage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (isDead)
        {
            deadImage.SetActive(true);
        }
        if (isWin)
        {
            winImage.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) deadImage.SetActive(true);
        else deadImage.SetActive(false);

        if (isWin) winImage.SetActive(true);
        else winImage.SetActive(false);

        if (Input.GetMouseButtonDown(0) && isDead==true)
        {
            isDead = false;
        }
        if (Input.GetMouseButtonDown(0) && isWin == true)
        {
            isWin = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
