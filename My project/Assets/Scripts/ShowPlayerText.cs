using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerText : MonoBehaviour
{
    [SerializeField]

    private Text playerText;

    [SerializeField]

    private String animationName = "ShowText";

    private Animator textAnimator;

    private void Start()
    {
        textAnimator = playerText.GetComponent<Animator>();
    }

    public void ShowText(string Text)
    {
        playerText.text = Text;
        textAnimator.Play(animationName);
    }

}
