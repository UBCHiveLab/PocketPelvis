using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    //This function is for locking the scene switch until the further dev
    public GameObject devlopingNotification;

    public void TempLockScene()
    {
        devlopingNotification.SetActive(true);
        StartCoroutine(EnableNotification(2));
              
    }

    IEnumerator EnableNotification(int sec)
    {
        yield return new WaitForSeconds(sec);
        devlopingNotification.SetActive(false);
    }
}
