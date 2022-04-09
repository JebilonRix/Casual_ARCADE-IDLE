using UnityEngine;

namespace RedPanda
{
    public class BuildingAreaHandler : MonoBehaviour
    {
        [SerializeField] private BuildArea[] buildAreas;
        [SerializeField] private SpawnSoldierArea spawnSoldierArea;

        public void Check()
        {
            int count = 0;

            for (int i = 0; i < buildAreas.Length; i++)
            {
                if (buildAreas[i].IsDone)
                {
                    count++;
                }
            }

            if (count >= buildAreas.Length)
            {
                spawnSoldierArea.gameObject.SetActive(true);

                foreach (BuildArea item in buildAreas)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }
}
