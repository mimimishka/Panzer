using System.Collections.Generic;
using UnityEngine;

namespace Panzer
{
    [CreateAssetMenu(fileName = "SpawnSet", menuName = "Spawns set")]
    public class SpawPointsSet : ScriptableObject
    {
        [SerializeField]
        List<Transform> points;
        public List<Transform> SpawnPoints { get { return points; } }
    }
}