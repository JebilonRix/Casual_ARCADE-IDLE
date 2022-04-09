using UnityEngine;

namespace RedPanda
{
    public class CharacterStorage : MonoBehaviour
    {
        [SerializeField] private uint _wood = 0;
        [SerializeField] private uint _gold = 0;
        [SerializeField] private uint _stone = 0;
        [SerializeField] private CharacterStack _stack;

        public uint Wood { get => _wood; private set => _wood = value; }
        public uint Gold { get => _gold; private set => _gold = value; }
        public uint Stone { get => _stone; private set => _stone = value; }

        public bool ResouceIsExit(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Wood:
                    if (Wood > 0)
                    {
                        return true;
                    }
                    break;
                case ResourceType.Gold:
                    if (Gold > 0)
                    {
                        return true;
                    }
                    break;
                case ResourceType.Stone:
                    if (Stone > 0)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
        public void CollectSource(ResourceType type)
        {
            switch (type)
            {
                case ResourceType.Wood:
                    Wood += 1;
                    break;
                case ResourceType.Gold:
                    Gold += 1;
                    break;
                case ResourceType.Stone:
                    Stone += 1;
                    break;
            }

            _stack.AddBox(type);
        }
        public void SpendSource(ResourceType type)
        {
            if (ResouceIsExit(type))
            {
                switch (type)
                {
                    case ResourceType.Wood:
                        Wood -= 1;
                        break;
                    case ResourceType.Gold:
                        Gold -= 1;
                        break;
                    case ResourceType.Stone:
                        Stone -= 1;
                        break;
                }

                _stack.RemoveBox(type);
            }
        }
    }
}