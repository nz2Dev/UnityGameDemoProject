using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Development
{
    public class ByNameMigrator : MonoBehaviour
    {
        [SerializeField] Transform valuesSource = null;


        [ContextMenu("Migrate AABB")]
        public void MigrateAABB() {
            if (!CheckValuseSource())
                return;


            DeepForEach(valuesSource, sourceItem => DeepFind(sourceItem, transform, (source, self) =>
            {
                var sourceMeshRenderer = source.GetComponent<SkinnedMeshRenderer>();
                var selfMeshRenderer = self.GetComponent<SkinnedMeshRenderer>();
                if (sourceMeshRenderer && selfMeshRenderer) {
                    selfMeshRenderer.localBounds = sourceMeshRenderer.localBounds;
                }
            }));
        }

        bool CheckValuseSource()
        {
            return valuesSource != null;
        }

        static void DeepForEach(Transform transform, Action<Transform> consumer)
        {
            foreach (Transform child in transform)
            {
                consumer(child);
                if (child.childCount > 0)
                {
                    DeepForEach(child, consumer);
                }
            }
        }

        static bool DeepFind(Transform source, Transform step, Action<Transform, Transform> migration)
        {
            var target = step.Find(source.name);
            if (target)
            {
                migration(source, target);
                return true;
            }

            return step.Cast<Transform>().Any(subStep => DeepFind(source, subStep, migration));
        }
    }
}