using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerAttributes))]
public class PlayerAttributesEditor : Editor
{
    private bool showCombat = true;
    private bool showSurvival = true;
    private bool showMovement = true;
    private bool showResource = true;
    private bool showProgress = true;
    private bool showSupport = true;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        showCombat = EditorGUILayout.Foldout(showCombat, "Combate");
        if (showCombat)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Combat"), true);

        showSurvival = EditorGUILayout.Foldout(showSurvival, "Sobrevivência");
        if (showSurvival)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Survival"), true);

        showMovement = EditorGUILayout.Foldout(showMovement, "Movimentação");
        if (showMovement)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Movement"), true);

        showResource = EditorGUILayout.Foldout(showResource, "Recursos");
        if (showResource)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Resource"), true);

        showProgress = EditorGUILayout.Foldout(showProgress, "Progressão");
        if (showProgress)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Progress"), true);

        showSupport = EditorGUILayout.Foldout(showSupport, "Suporte/Utilitários");
        if (showSupport)
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Support"), true);

        serializedObject.ApplyModifiedProperties();
    }
}
