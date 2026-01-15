using UnityEngine;

public class AddScoreOnClick : MonoBehaviour
{

    [SerializeField] Material normalMaterial, highlightMaterial;

    MeshRenderer getRenderer;

    [SerializeField] int scoreToAdd = 5;

    void Start()
    {
        getRenderer = GetComponent<MeshRenderer>();
        getRenderer.material = normalMaterial;
        print($"read score {GameManager.instance.GetScore()}");
    }
    
    void OnMouseEnter()
    {
        getRenderer.material = highlightMaterial;
    }
    void OnMouseExit()
    {
        getRenderer.material = normalMaterial;

    }

    void OnMouseDown()
    {
        GameManager.instance.AddScore(scoreToAdd);
        getRenderer.material = normalMaterial;

    }
    void OnMouseUp()
    {
        getRenderer.material = highlightMaterial;
    }

    }