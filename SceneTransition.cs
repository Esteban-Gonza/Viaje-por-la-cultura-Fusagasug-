using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour{

    [SerializeField] float transitionTime = 1f;
    [SerializeField] GameObject mainCanvas;
    Animator transitionAnim;

    void Start(){

        transitionAnim = GetComponent<Animator>();
        StartCoroutine(WaitForTransition());
    }

    public void QuitApp(){

        Application.Quit();
    }

    public void LoadElectionMenu(){

        StartCoroutine(MenuElectionLoad());
        mainCanvas.SetActive(false);
    }
    
    public void LoadMainMenu(){

        StartCoroutine(MainMenuLoad());
        mainCanvas.SetActive(false);
    }
    
    public void LoadBoard1() {

        StartCoroutine(SceneLoad1());
        mainCanvas.SetActive(false);
    }

    public void LoadBoard2(){

        StartCoroutine(SceneLoad2());
        mainCanvas.SetActive(false);
    }

    public void LoadBoard3(){

        StartCoroutine(SceneLoad3());
        mainCanvas.SetActive(false);
    }

    public void redirectToVideo(string link){

        Application.OpenURL(link);
    }

    public IEnumerator SceneLoad1(){

        transitionAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Board1");
    }

    public IEnumerator SceneLoad2(){

        transitionAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Board2");
    }

    public IEnumerator SceneLoad3(){

        transitionAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Board3");
    }
    
    public IEnumerator MenuElectionLoad(){

        transitionAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("ElectionMenu");
    }

    public IEnumerator MainMenuLoad(){

        transitionAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator WaitForTransition(){

        mainCanvas.SetActive(false);
        yield return new WaitForSeconds(transitionTime);
        mainCanvas.SetActive(true);
    }
}