using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Color curentColor { get { return _curentColor; } }
    [SerializeField] SO_GameInitData dataDic;

    Rigidbody _rb;
    Material _material;
    bool _changeCollorByCollisionBall;
    Color _curentColor;
    Color _colorToChange;
    float _timer;
    public void Init(SO_GameInitData data)
    {
        dataDic = data;
        _rb = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;

        StartChangeRandomeColor();
    }


    void Update()
    {
        if (_changeCollorByCollisionBall)
        {
            StartCoroutine(ChangeColor());
        }
    }

    public void PushBall(Vector3 dir, float force)
    {
        _rb.AddForce( -dir * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 vel;
        if (collision.collider.GetComponent<Rigidbody>() != null)
        {
            vel = (collision.collider.GetComponent<Rigidbody>().velocity.magnitude > _rb.velocity.magnitude) ? 
                collision.collider.GetComponent<Rigidbody>().velocity : -(_rb.velocity);
        }
        else vel = _rb.velocity;
        if (collision.collider.CompareTag("Wall"))
        {
            ChangeRandomeColor();
            _rb.AddForce(-(vel/2) * 100);
            UI_Game.wallHited?.Invoke();
        }
        if (collision.collider.CompareTag("Ball"))
        {
            SwichCollor(collision.gameObject.GetComponent<Ball>().curentColor);
            _rb.AddForce( -vel * 100);
            UI_Game.ballHited?.Invoke();
        }
    }

    void SwichCollor(Color colorToSwich)
    {
        _changeCollorByCollisionBall = true;
        _colorToChange = colorToSwich;
    }
    public void ChangeRandomeColor() 
    {
        int r = Random.Range(0, dataDic.colorListToUse.Count - 1);
        SwichCollor(dataDic.colorListToUse[r]); 
    }
    void StartChangeRandomeColor()
    {
        int r = Random.Range(0, dataDic.colorListToUse.Count - 1);
        _curentColor = dataDic.colorListToUse[r];
        _material.color = _curentColor;
    }
    IEnumerator ChangeColor()
    {

        if (_material.color != _colorToChange)
        { 
            _timer += Time.deltaTime;
            _material.color = Color.Lerp(curentColor, _colorToChange, _timer); 
        }
        else
        {
            _timer = 0;
            _curentColor = _colorToChange;
            _changeCollorByCollisionBall = false; 
        }
        yield return null;
    }
}
