using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedPanda
{
    public class SpawnSoldierArea : BaseArea
    {
        [SerializeField] private List<Resource> _resourceList = new List<Resource>();
        [SerializeField] private GameObject _soldierPrefab;
        [SerializeField] private Vector3 _soldierSpawnPosition;
        [SerializeField] private uint _soldierCount = 0;
        public uint SoldierCount { get => _soldierCount; private set => _soldierCount = value; }

        protected override void Start()
        {
            base.Start();
        }
        protected override void OnTriggerEnter()
        {
            base.OnTriggerEnter();
        }
        protected override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
        }
        protected override void OnTriggerExit()
        {
            base.OnTriggerExit();
        }
        protected override IEnumerator TransferSource()
        {
            _isStart = true;

            yield return new WaitForSeconds(_collectRate);

            int count = 0;

            for (int i = 0; i < _resourceList.Count; i++)
            {
                if (_collect.ResouceIsExit(_resourceList[i].ResourceType))
                {
                    if (_resourceList[i].RequiredAmount >= _resourceList[i].CollectedAmount)
                    {
                        _collect.SpendSource(_resourceList[i].ResourceType);
                        _resourceList[i].CollectedAmount += 1;
                    }
                }

                if (_resourceList[i].RequiredAmount <= _resourceList[i].CollectedAmount)
                {
                    _resourceList[i].CanSpawn = true;
                }

                if (_resourceList[i].CanSpawn)
                {
                    count++;
                }

                if (_resourceList[i].CollectedAmount < _resourceList[i].RequiredAmount)
                {
                    UiManager.Instance.SetTexts(_resourceList[i].ResourceType, (_resourceList[i].RequiredAmount - _resourceList[i].CollectedAmount).ToString());
                }
                else
                {
                    UiManager.Instance.SetTexts(_resourceList[i].ResourceType, 0.ToString());
                }
            }

            if (count >= _resourceList.Count)
            {
                GameObject soldier = Instantiate(_soldierPrefab, transform.position, Quaternion.identity);
                soldier.transform.parent = transform;
                soldier.transform.localPosition = new Vector3(_soldierSpawnPosition.x + SoldierCount, _soldierSpawnPosition.y, _soldierSpawnPosition.z);
                SoldierCount++;

                GameManager.Instance.CheckWinCondition();

                for (int i = 0; i < _resourceList.Count; i++)
                {
                    _resourceList[i].CanSpawn = false;
                    _resourceList[i].CollectedAmount = 0;
                }
            }

            _isStart = false;
        }
    }

    [System.Serializable]
    public class Resource
    {
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private uint _requiredAmount;
        private uint _collectedAmount;
        private bool _canSpawn = false;

        public ResourceType ResourceType { get => _resourceType; }
        public uint RequiredAmount { get => _requiredAmount; }
        public uint CollectedAmount { get => _collectedAmount; set => _collectedAmount = value; }
        public bool CanSpawn { get => _canSpawn; set => _canSpawn = value; }
    }
}
