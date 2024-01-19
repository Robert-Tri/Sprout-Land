using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackgroundAnimation : MonoBehaviour
{
    public Sprite[] frames;
    public float framesPerSecond = 10f;

    private int currentFrame = 0;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        InvokeRepeating("NextFrame", 0, 1 / framesPerSecond);
    }

    void NextFrame()
    {
        image.sprite = frames[currentFrame];
        currentFrame = (currentFrame + 1) % frames.Length;
    }
}
