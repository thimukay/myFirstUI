using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);

        myTarget.speed = EditorGUILayout.IntField("My Speed", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("My Gear", myTarget.gear);
        myTarget.maxCar = EditorGUILayout.IntField("Maximun Car Number", myTarget.maxCar);

        EditorGUILayout.LabelField("Total Speed", myTarget.TotalSpeed.ToString());

        EditorGUILayout.HelpBox("Calculate car total speed!", MessageType.Info);

        if(myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("Speed limit reached", MessageType.Error);
        }

        GUI.color = Color.green;

        if(GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }

        GUI.color = Color.yellow;

        if (GUILayout.Button("Remove Car"))
        {
            myTarget.RemoveCar();
        }
    }
}
