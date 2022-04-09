using System.Collections;
using UnityEngine;

namespace RedPanda
{
    public class CollectArea : BaseArea
    {
        [SerializeField] protected ResourceType _resourceType;

        protected override void OnTriggerEnter()
        {

        }
        protected override void OnTriggerStay(Collider other)
        {
            base.OnTriggerStay(other);
        }
        protected override void OnTriggerExit()
        {

        }
        protected override IEnumerator TransferSource()
        {
            _isStart = true;

            yield return new WaitForSeconds(_collectRate);

            _collect.CollectSource(_resourceType);

            _isStart = false;
        }
    }
}