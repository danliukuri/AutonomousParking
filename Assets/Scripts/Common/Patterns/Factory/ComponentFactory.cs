using UnityEngine;

namespace AutonomousParking.Common.Patterns.Factory
{
    public class ComponentFactory<TComponent> where TComponent : Component
    {
        private readonly Transform objectParent;
        private readonly GameObject prefab;

        public ComponentFactory(GameObject prefab, Transform objectParent)
        {
            this.prefab = prefab;
            this.objectParent = objectParent;
        }

        public TComponent Create() => Object.Instantiate(prefab, objectParent).GetComponent<TComponent>();

        public void OnGetFromPool(TComponent component) => component.gameObject.SetActive(true);

        public void OnReleaseToPool(TComponent component)
        {
            component.gameObject.SetActive(false);
            component.transform.SetParent(objectParent);
        }

        public void DestroyPoolObject(TComponent component) => Object.Destroy(component.gameObject);
    }
}