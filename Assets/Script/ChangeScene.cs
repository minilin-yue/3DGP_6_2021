using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    private Loading loading;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        loading = GameObject.FindGameObjectWithTag("Loading").GetComponent<Loading>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)// 開始接觸瞬間會呼叫一次
    {
        //audioManager.Stop();
        loading.loadScene(sceneName);
    }
}
