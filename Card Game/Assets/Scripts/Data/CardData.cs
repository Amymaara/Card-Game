using Unity.Android.Gradle.Manifest;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Card")]
public class CardData : ScriptableObject

{
    [field: SerializeField] public string description { get; private set; }
    [field: SerializeField] public int cardCost { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }
}
