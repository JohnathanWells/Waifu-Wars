using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "MapDetails", menuName = "ScriptableObjects/MapDetails")]
public class MapSO : ScriptableObject
{
    [SerializeField] public string mapName;
    [SerializeField] public string sceneName;
    [SerializeField] public Sprite thumbnail;
    [TextArea, SerializeField] public string mapDescription;
    [SerializeField] public GamemodeSO[] validGamemodes; 
}