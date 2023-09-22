using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Main
{
    public class Play: MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}