using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject background;
    public GameObject percentage;
    public GameObject all;
    public GameObject mCamera;

    private Animation fade;
    private Text percent;
    private string scene;
    private bool isLoading = false;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Loading");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        fade = background.GetComponent<Animation>();
        percent = percentage.GetComponent<Text>();

    }

    void Update()
    {
        
        if(isLoading && !fade.isPlaying)
        {
            isLoading = false;
            all.SetActive(true);
            mCamera.SetActive(true);
            AudioSource[] l = GameObject.FindObjectsOfType<AudioSource>();
            for(int i = 0; i < l.Length; i++)
            {
                l[i].Stop();
            }
            var sc = SceneManager.GetActiveScene();
            GameObject[] g = sc.GetRootGameObjects();
            for (int i = 0; i < g.Length; i++)
            {
                if (!g[i].CompareTag("Player") && !g[i].CompareTag("Loading")) Destroy(g[i]);
            }
            UnityEditor.EditorUtility.UnloadUnusedAssetsImmediate();
            StartCoroutine(StartLoading(scene));
        }
    }
    private void SetLoadingPercentage(int p)
    {
        percent.text = p.ToString();
    }
    private IEnumerator StartLoading(string name)
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(name);//Application.LoadLevelAsync(1);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        all.SetActive(false);
        mCamera.SetActive(false);
        op.allowSceneActivation = true;
        fade.Play("fadeOut");
    }
    public void loadScene(string name)
    {
        fade.Play("fadeIn");
        scene = name;
        isLoading = true;
    }
}
