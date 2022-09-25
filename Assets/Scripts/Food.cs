using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    float _rotateSpeed = 100f;
    [SerializeField] GameObject _parentQuiz;
    [SerializeField] RunTimeData _runetimedata;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        transform.Find("Spot Light").gameObject.SetActive(true);
        GameObject FoodMesh = transform.Find("FoodMesh").gameObject;

        _runetimedata.CurrentFoodMouseOver = FoodMesh.transform.GetChild(0).gameObject.name;
    }

    void OnMouseOver()
    {
        transform.Find("FoodMesh").Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    void OnMouseExit()
    {
        transform.Find("Spot Light").gameObject.SetActive(false);
        _runetimedata.CurrentFoodMouseOver = "";
    }

    private void OnMouseDown()
    {
        if(_runetimedata.CurrentGameplayState == GameplayState.FreeWalk)
        {
            StartCoroutine(_parentQuiz.GetComponent<FoodQuiz>().FoodSelected(gameObject));
            _runetimedata.CurrentFoodMouseOver = "";
        }
           
        
    }
}
