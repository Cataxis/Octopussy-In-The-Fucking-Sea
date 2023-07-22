using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField] GameObject game;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject tutorial;

    public void Play()
    {
        game.SetActive(true);
        tutorial.SetActive(true);
        Destroy(panel);
    }
}
