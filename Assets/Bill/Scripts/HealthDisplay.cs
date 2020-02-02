using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public Image[] images;
    public Sprite emptyHeart;
    public Sprite fullHeart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<images.Length; i++)
        {
            if (i <= health - 1)
            {
                images[i].sprite = fullHeart;
            }
            else
            {
                images[i].sprite = emptyHeart;
            }
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
            gameObject.SetActive(false);
        }
    }
}
