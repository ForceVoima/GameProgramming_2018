using UnityEngine;

namespace TankGame
{
    public class Weapon : MonoBehaviour
    {
        private Pool<Projectile> _projectiles;
        private Unit _owner;

        [SerializeField] private Projectile _projectilePrefab;

        private GameObject _projectileParent;

        public void Init(Unit owner)
        {
            _owner = owner;

            _projectileParent = new GameObject("Projectiles");
            _projectileParent.transform.SetParent(transform);

            _projectiles = new Pool<Projectile>(4, false, _projectilePrefab, _projectileParent.transform);
        }
    }
}
