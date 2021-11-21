using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWritingEffect : MonoBehaviour
{
    [SerializeField] private TextWriter textwriter;

    private Text messageText;

    void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
    }

    private void Start()
    {
        messageText.text = "我將繼續引導迷途的旅人、抵達各自的終點\n悲傷的靈魂啊、讓我帶領你回到最初的歸宿";
        textwriter.AddWriter(messageText, "我將繼續引導迷途的旅人、抵達各自的終點\n悲傷的靈魂啊、讓我帶領你回到最初的歸宿", 0.1f);
    }
}
