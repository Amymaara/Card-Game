using Unity.Android.Gradle.Manifest;
using UnityEngine;
using System.Collections.Generic;
using SerializeReferenceEditor;
using TMPro;

[CreateAssetMenu(menuName = "Data/Card")]
public class CardData : ScriptableObject

{
    [field: SerializeField] public string description { get; private set; }
    [field: SerializeField] public int cardCost { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }

    [field: SerializeReference, SR] public List<Effect> Effects { get; private set; }

    [field: SerializeField] public CardType CardType { get; private set; }
    [field: SerializeField] public int BaseValue { get; private set; }

    [SerializeField] private TMP_Text cardTypeText;

}
