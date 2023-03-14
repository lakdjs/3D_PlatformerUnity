using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour
{
    [SerializeField] Button _buttonPlay;
    [SerializeField] Button _buttonChose;
    [SerializeField] Button _buttonSettings;
    public void SceneManage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
