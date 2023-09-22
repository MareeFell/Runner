using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class RecordList
    {
        private static string SaveKey = "recoradsaaa";
        
        [SerializeField]
        private List<Record> _records;
        
        [CanBeNull] private static RecordList _instanse;

        public static RecordList Instance
        {
            get
            {
                if (_instanse == null)
                {
                    _instanse = LoadSaves();
                }

                return _instanse;
            }
        }
        
        public void AddNewRecord(Record record)
        {
            _records.Add(record);
            SaveChanges(this);
        }

        public IEnumerable<Record> Records => _records;
        
        private static RecordList LoadSaves()
        {
            string json = PlayerPrefs.GetString(SaveKey);
            if (string.IsNullOrEmpty(json))
            {
                return new RecordList
                {
                    _records = new List<Record>()
                };
            }
            return JsonUtility.FromJson<RecordList>(json);
        }

        private static void SaveChanges(RecordList recordList)
        {
            Debug.Log(recordList.Records.Count());
            string jsoned = JsonUtility.ToJson(recordList);
            PlayerPrefs.SetString(SaveKey, jsoned);
        }
    }
}