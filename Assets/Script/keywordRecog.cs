using System;// Action
using System.Text;// StringBuilder
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.Audio;

public class keywordRecog : MonoBehaviour
{
    public Caption caption;
    public GameObject mermaid;

    [SerializeField]
    private string[] m_Keywords;

    [SerializeField]
    private string str;

    [SerializeField]
    private Text m_uiText;

    [SerializeField]
    private GameObject spirit;
   
    private KeywordRecognizer m_Recognizer;
    private Dictionary<string, Action> m_actionMap = new Dictionary<string, Action>();

    private bool check = false;// spirit only come out once
    public bool flag = false;// check whether player is near treasure

    private Voice voice;
    private Animator ani;
    private bool c = false;// 咒語只能用一次

    private void Start()
    {
        voice = mermaid.GetComponent<Voice>();
        ani = mermaid.GetComponent<Animator>();
        m_actionMap.Add(str, letter);
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //m_Recognizer.Start();
            flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // m_Recognizer.Stop();
        flag = false;
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        var builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        if (str == "Rohan" && !mermaid.activeSelf)
        {
            caption.Play(36);
        }
        if (str == "Shire" && !mermaid.activeSelf)
        {
            caption.Play(37);
        }
        if (str == "Minas" && !mermaid.activeSelf)
        {
            caption.Play(38);
        }
        if (str == "Gondor" && !mermaid.activeSelf)
        {
            caption.Play(39);
        }

        if (str == "Minas" && mermaid.activeSelf && !c) // mermaid，只要有喊就會過，且只能喊一次
        {
            m_actionMap[args.text].Invoke();
        }

        if (flag && !mermaid.activeSelf)
        {
            m_actionMap[args.text].Invoke();
        }
    }

    private void letter()
    {
        if (!check && !mermaid.activeSelf)
        {
            spirit.SetActive(true);
            check = true;
        }

        if((str == "Minas" && mermaid.activeSelf && !c ) || Input.GetKeyDown(KeyCode.J))
        {
            caption.Play(40);
            c = true; // 咒語只能用一次
        }
    }
}