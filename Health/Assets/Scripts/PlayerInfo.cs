using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviourPun, IPunObservable
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private string _equipment;
    private float Hitpoints;
    private float MaxPoints = 3;
    private HealthBehavior Healthbar;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_currentHealth);
            stream.SendNext(_equipment);
        }
        else
        {
            _currentHealth = (float)stream.ReceiveNext();
            _equipment = (string)stream.ReceiveNext();
        }
    }

    private void Start()
    {
        Hitpoints = MaxPoints;
        Healthbar.SetHealth(Hitpoints, MaxPoints);
    }
    private void Update()
    {
        if (!photonView.IsMine)
        {

        }
    }
    private void TakeHit(float damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }

    }
}