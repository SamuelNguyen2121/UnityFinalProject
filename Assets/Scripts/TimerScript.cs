using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    Text score;

    [SerializeField]
    int time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(runTimer());
    }

    IEnumerator runTimer()
    {
        while (true)
        {
            score.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;

            if (time == 0) {
                break;
            }
        }
        LoadGameOver();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

}
