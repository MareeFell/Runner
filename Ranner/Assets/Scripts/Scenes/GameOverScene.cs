using Models;
using Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI record;
    [SerializeField] private InputField nameField;

    private void Start()
    {
        record.text = $"Рекорд: {Static.Score}";
    }

    public void Exit()
    {
        RecordList.Instance.AddNewRecord(new()
        {
            Name = nameField.text,
            Distance = Static.Score,
        });
        SceneManager.LoadScene("SampleScene");
    }

    public void Restart()
    {
        RecordList.Instance.AddNewRecord(new()
        {
            Name = nameField.text,
            Distance = Static.Score,
        });
        SceneManager.LoadScene("GameScene");
    }
}
