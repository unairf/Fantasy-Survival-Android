using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;
using Sirenix.OdinInspector;
using UnityEditor;

public class SurvivalManager : OdinEditorWindow {
    public IntReference maxHealth;
    public int maxHealthInt;

    [MenuItem("Survival/PlayersManager")]
    private static void OpenWindow() {
        GetWindow<SurvivalManager>().Show();

    }
    [PropertyOrder(-10)]
    [HorizontalGroup]
    [Button(ButtonSizes.Large)]
    public void SomeButton1() { }

    [HorizontalGroup]
    [Button(ButtonSizes.Large)]
    public void SomeButton2() { }

    [HorizontalGroup]
    [Button(ButtonSizes.Large)]
    public void SomeButton3() { }

    [HorizontalGroup]
    [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
    public void SomeButton4() { }

    [HorizontalGroup]
    [Button(ButtonSizes.Large), GUIColor(1, 0.5f, 0)]
    public void SomeButton5() { }

    [TableList]
    public List<SomeType> currentPlayers;
}

public class SomeType
{
    [PreviewField()]
    public Sprite image;
    public string playerName;
    [ProgressBar(1, 100)]
    public int health;
    [TableColumnWidth(50)]
    public bool inmune;

    [AssetsOnly]
    public GameObject SomePrefab;
    [VerticalGroup("Mensaje")]
    public string mensaje;
    [VerticalGroup("Mensaje")]
    [Button]
    public void EnviarMensaje() { }

    [TableColumnWidth(160)]
    [HorizontalGroup("Actions")]
    public void Test1() { }

    [HorizontalGroup("Actions")]
    public void Test2() { }
}
