using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private CharacterController controlador;

    public float velocidade = 5f;

    public float velocidadeRotacao = 10f;

    public AudioSource playerAudio;
    public AudioClip walkSound;
    public AudioClip coin;

    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }
    void Update()
    {
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoZ = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoX, 0, movimentoZ);

        if (movimento.magnitude > 0)
        {
            Vector3 direcao = new Vector3(movimentoX, 0, movimentoZ).normalized;

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);

            transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, velocidadeRotacao * Time.deltaTime);
        }
        controlador.Move(movimento * velocidade * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W));
        {
            playerAudio.clip = walkSound;
            playerAudio.Play();

        }
        if (Input.GetKeyDown(KeyCode.D)) ;
        {
            playerAudio.clip = coin;
            playerAudio.Play();

        }
    }

}
