using UnityEngine;

namespace Panzer
{
    [CreateAssetMenu(fileName = "PanzerConfig", menuName = "Panzer config")]
    public class PanzerConfig : ScriptableObject
    {
        [SerializeField]
        float health;
        [SerializeField]
        float protection;

        public float Health { get { return health; } }
        public float Protection { get { return protection; } }
    }
}