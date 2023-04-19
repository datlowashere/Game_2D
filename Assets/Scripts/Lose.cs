using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{

    public float looseHight = -100f;
    void Update()
    {
        if (gameObject.transform.position.y < looseHight)
        {
            gameObject.SetActive(false);

            GameController.instance.GameOver();
            Time.timeScale = 0;
        }
    }
}
