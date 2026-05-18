using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Info", menuName = "EnemyInfo", order = 51)]
public class EnemyInfo : ScriptableObject
{
    [SerializeField] private Sprite _image;
    [SerializeField] private float _attackRate;

    private Sprite Image => _image;
    private float AttackRate => _attackRate;
}
