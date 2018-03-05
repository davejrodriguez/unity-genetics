using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public class MyBaseClass : ScriptableObject {
    [SerializeField]
    protected int m_IntField;

    public void OnEnable() { hideFlags = HideFlags.HideAndDontSave; }

    public virtual void OnGUI() {
        m_IntField = EditorGUILayout.IntSlider("IntField", m_IntField, 0, 10);
    }
}

[Serializable]
public class ChildClass : MyBaseClass {
    [SerializeField]
    private float m_FloatField;

    public override void OnGUI() {
        base.OnGUI();
        m_FloatField = EditorGUILayout.Slider("FloatField", m_FloatField, 0f, 10f);
    }
}

[Serializable]
public class SerializeMe : ScriptableObject {
    [SerializeField]
    private List<MyBaseClass> m_Instances;

    public void OnEnable() {
        if (m_Instances == null)
            m_Instances = new List<MyBaseClass>();

        hideFlags = HideFlags.HideAndDontSave;
    }

    public void OnGUI() {
        foreach (var instance in m_Instances)
            instance.OnGUI();

        if (GUILayout.Button("Add Base"))
            m_Instances.Add(CreateInstance<MyBaseClass>());
        if (GUILayout.Button("Add Child"))
            m_Instances.Add(CreateInstance<ChildClass>());
    }
}