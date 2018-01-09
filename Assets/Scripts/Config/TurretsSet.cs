using System.Collections.Generic;
using UnityEngine;

namespace Panzer
{
    [CreateAssetMenu(fileName ="Turrets", menuName = "Turrets set")]
    public class TurretsSet : ScriptableObject
    {
        [SerializeField]
        List<TurretView> turrets;
        public TurretView this[int index] { get { return turrets[index]; } }
        public int Count { get { return turrets.Count; } }
    }
}