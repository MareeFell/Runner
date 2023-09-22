using Models;
using TMPro;
using UnityEngine;

namespace Scenes.Records
{
    public class RecordViewItem : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _name;

        [SerializeField] private TextMeshProUGUI _distance;

        public void UpdateRecord(Record record)
        {
            _name.text = $"Name: {record.Name}";
            _distance.text = $"Distance: {record.Distance}";
        }
    }
}