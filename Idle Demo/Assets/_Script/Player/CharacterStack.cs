using System.Collections.Generic;
using UnityEngine;

namespace RedPanda
{
    public class CharacterStack : MonoBehaviour
    {
        [SerializeField] private GameObject _boxPrefab;
        [SerializeField] private Transform _collectedPoint;
        [SerializeField] private float _posOffset;
        [SerializeField] private int _maxBoxCount = 100;

        [SerializeField] private Material _woodMaterial;
        [SerializeField] private Material _goldMaterial;
        [SerializeField] private Material _stoneMaterial;

        private List<GameObject> _boxes = new List<GameObject>();
        private int _collectedBoxCount = 0;

        int _woodBox;
        int _goldBox;
        int _stoneBox;

        private void Start()
        {
            for (int i = 0; i < _maxBoxCount; i++)
            {
                GameObject obj = Instantiate(_boxPrefab, _collectedPoint.position, Quaternion.identity);

                obj.transform.SetParent(_collectedPoint.transform);
                obj.transform.localPosition = new Vector3(0, obj.transform.localPosition.y + (i * _posOffset), 0);
                obj.SetActive(false);

                _boxes.Add(obj);
            }
        }
        public void AddBox(ResourceType type)
        {
            if (_maxBoxCount > _collectedBoxCount)
            {
                GameObject box = _boxes[_collectedBoxCount];
                box.SetActive(true);
                SetColor(type, box, 1);

                _collectedBoxCount++;
            }
        }

        public void RemoveBox(ResourceType type)
        {
            if (_collectedBoxCount < 0)
            {
                _collectedBoxCount = 0;
                return;
            }

            GameObject obj = null;

            if (_collectedBoxCount > 0)
            {
                obj = _boxes[_collectedBoxCount - 1];
                obj.SetActive(false);
                _collectedBoxCount--;
            }

            SetColor(type, obj, -1);
        }
        private void SetColor(ResourceType type, GameObject box, int change)
        {
            MeshRenderer render = box.GetComponent<MeshRenderer>();

            switch (type)
            {
                case ResourceType.Wood:
                    render.material = _woodMaterial;
                    _woodBox += change;
                    break;
                case ResourceType.Gold:
                    render.material = _goldMaterial;
                    _goldBox += change;
                    break;
                case ResourceType.Stone:
                    render.material = _stoneMaterial;
                    _stoneBox += change;
                    break;
            }
        }
    }
}