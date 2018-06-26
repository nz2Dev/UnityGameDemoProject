using System;
using UnityEngine;

namespace Development
{
    public class MirrorMigrator : MonoBehaviour
    {
        [SerializeField] bool checkNames = false;
        [SerializeField] Transform valuesSource = null;

        [ContextMenu("Migrate Loc/Rot/Scale")]
        public void MigrateLocRotScale()
        {
            if (!CheckValuseSource())
                return;

            Travel(valuesSource, transform, (source, self) =>
            {
                self.localPosition = source.localPosition;
                self.localRotation = source.localRotation;
                self.localScale = source.localScale;
            });
        }

        bool CheckValuseSource()
        {
            if (valuesSource == null)
            {
                Debug.LogWarning("valuesSoruce not selected!");
                return false;
            }
            return true;
        }

        void Travel(Transform source, Transform self, Action<Transform, Transform> migration)
        {
            if (checkNames && source.name != self.name)
            {
                Debug.LogError("name are different: from.name = " + source.name + " to.name = " + self.name);
                return;
            }

            migration(source, self);

            if (source.childCount != self.childCount)
            {
                Debug.LogError("childs aren't same for " + source.name + " and " + self.name);
                return;
            }

            if (source.childCount > 0)
            {
                for (int i = 0; i < source.childCount; i++)
                {
                    Travel(source.GetChild(i), self.GetChild(i), migration);
                }
            }
        }
    }
}