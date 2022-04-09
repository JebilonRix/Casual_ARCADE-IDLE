using System.Collections;
using UnityEngine;

namespace RedPanda
{
    public class BuildArea : BaseArea
    {
        [SerializeField] private ResourceType _sourceType;
        [SerializeField] private uint _requiredSource;
        [SerializeField] private bool _isDone = false;

        [SerializeField] private BuildingAreaHandler _areaHandler;
        private uint _collecttedSource;

        public bool IsDone { get => _isDone; private set => _isDone = value; }

        protected override void Start()
        {
            base.Start();
            _collecttedSource = 0;
        }
        protected override void OnTriggerEnter()
        {
            base.OnTriggerEnter();
            UiManager.Instance.SetTexts(_sourceType, (_requiredSource - _collecttedSource).ToString());
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
            if (IsDone)
            {
                _isStart = false;
                yield return null;
            }

            _isStart = true;

            yield return new WaitForSeconds(_collectRate);

            if (_collecttedSource < _requiredSource && _collect.ResouceIsExit(_sourceType))
            {
                _collecttedSource += 1;
                _collect.SpendSource(_sourceType);

                UiManager.Instance.SetTexts(_sourceType, (_requiredSource - _collecttedSource).ToString());
            }
            else if (_collecttedSource >= _requiredSource)
            {
                IsDone = true;
                _areaHandler.Check();
            }

            _isStart = false;
        }
    }
}