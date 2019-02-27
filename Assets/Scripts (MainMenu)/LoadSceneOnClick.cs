using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour
{
    public static int currIndex;
   public void LoadByIndex(int sceneIndex)
    {
        currIndex = sceneIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    public static int returnIndex()
    {
        return currIndex;
    }
}
