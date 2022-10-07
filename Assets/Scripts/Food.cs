using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    float _rotateSpeed = 100f;
    [SerializeField] GameObject _parentQuiz;
    [SerializeField] RunTimeData _runtimedata;
    [SerializeField] GameObject _FoodBulletPrefab;
    [SerializeField] int _basedamage = 5;
    [SerializeField] float _basethrowspeed = 5;
    [SerializeField] int _cost = 5;
    [SerializeField] bool _isBought = false;

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

        _runtimedata.CurrentFoodMouseOver = FoodMesh.transform.GetChild(0).gameObject.name;
        _runtimedata.CurrentFoodViewedisBought = _isBought;
        _runtimedata.CurrentFoodViewedPrice = _cost;
        _runtimedata.CurrentFoodViewed = _FoodBulletPrefab;
        _runtimedata.CurrentFoodViewedDamage = _basedamage;
    }

    void OnMouseOver()
    {
        transform.Find("FoodMesh").Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    void OnMouseExit()
    {
        transform.Find("Spot Light").gameObject.SetActive(false);
        _runtimedata.CurrentFoodMouseOver = "";
    }

    private void OnMouseDown()
    {
        if(_runtimedata.CurrentGameplayState == GameplayState.FreeWalk)
        {
            StartCoroutine(_parentQuiz.GetComponent<FoodQuiz>().FoodSelected(gameObject));
            _runtimedata.CurrentFoodMouseOver = "";
        }
    }

    public void setBought(bool val)
    {
        this._isBought = val;
    }
}
