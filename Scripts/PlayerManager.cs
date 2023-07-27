using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public static int playerHP = 100;
    public TextMeshProUGUI playerHPText;


    public static bool isGameOvr;
    // Start is called before the first frame update
    void Start()
    {
        isGameOvr = false;
        playerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "+" + playerHP;
        if (isGameOvr)
        {
            //display game over screen
            SceneManager.LoadScene("Level_1");

        }
    }
    public static void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;


        if (playerHP <= 0)
            isGameOvr = true;
          
        
    }

}
