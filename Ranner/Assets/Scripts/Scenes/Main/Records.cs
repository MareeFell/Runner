using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Main
{
    public class Records : MonoBehaviour
    {
        public void ShowRecordScene()
        {
            SceneManager.LoadSceneAsync("RecordsScene");
        }
    }
}