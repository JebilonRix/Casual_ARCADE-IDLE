#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace RedPanda.CameraFollow
{
#if UNITY_EDITOR
    [CustomEditor(typeof(CameraFollow))]
    public class CameraFollowEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CameraFollow cameraFollow = (CameraFollow)target;

            if (GUILayout.Button("Set Camera Position"))
            {
                cameraFollow.SetPosition();
            }
        }
    }
#endif
}