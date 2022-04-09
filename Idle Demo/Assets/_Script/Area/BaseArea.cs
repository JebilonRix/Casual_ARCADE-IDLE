using System.Collections;
using UnityEngine;

namespace RedPanda
{
    public class BaseArea : MonoBehaviour
    {
        [SerializeField] protected string _playerTag = "Player";
        [SerializeField] protected float _collectRate = 0.01f;

        protected CharacterStorage _collect;
        protected bool _isStart;

        protected virtual void Start()
        {
            _collect = FindObjectOfType<CharacterStorage>();
        }
        protected virtual void OnTriggerEnter()
        {
            UiManager.Instance.Panel.SetActive(true);
        }
        protected virtual void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                if (!_isStart)
                {
                    StartCoroutine(TransferSource());
                }
            }
        }
        protected virtual void OnTriggerExit()
        {
            UiManager.Instance.Panel.SetActive(false);
        }

        protected virtual IEnumerator TransferSource()
        {
            yield return null;
        }
    }
}