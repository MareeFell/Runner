
using Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.Records
{
    public class ListRecordsView : MonoBehaviour
    {
        [SerializeField] private RecordViewItem _item;

        void Start()
        {
            VerticalLayoutGroup layoutGroup = GetComponent<VerticalLayoutGroup>();
            foreach (var record in RecordList.Instance.Records)
            {
                RecordViewItem item = Instantiate(_item, layoutGroup.transform);
                item.UpdateRecord(record);
            }
        }

        public void HideScene()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}