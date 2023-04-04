using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public void FadeToLevel(int levelIndex){
        animator.SetTrigger("FadeOut");
        levelToLoad = levelIndex;
    }

    public void OnFadeComplete(){
        SceneManager.LoadScene(levelToLoad);
    }
}
