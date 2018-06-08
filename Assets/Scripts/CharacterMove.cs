using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour {

    //Variaveis de velocidade, direção = pegar um x,y,z e armazenar dentro de um vector 3.
    public float velocidade;
	public float alturaPulo;
    //Vector 3.zero = estou inicializando este vetor 0
    Vector3 direcao = Vector3.zero;
    //Estou pegando o componente characterController e atribuindo um nome
    CharacterController personagemController;
    public GameObject personagemMalha;
    //Tenho que ter uma gravidade para simular um rigidbody
    //LEMBRE-SE NÃO USAMOS RIGID BODY COM CHARACTER CONTROLLER.
    float gravidade = 20.0f;
    Animation anima;
    public static bool reset;

	void Start () {
        //Fazendo a interface, referencia de toda vez que eu usar esta variavel ela pega o character controller de onde esta o script.
        personagemController = GetComponent<CharacterController>();
        anima = personagemMalha.GetComponent<Animation>();
        reset = false;
	}
	
	void Update () {
        Mover();
        ApagarHistorico();
        MudaAnimacao();
    }

    void Mover() {
        //Se o meu character controller, estiver no chão (isGrounded)
        if (personagemController.isGrounded)
        {
            //Pego minha variavel de vector 3 e atribuio os inputs:
            //Horizontal no X
            //Vertical no Z
            //No Y vai agir a gravidade; que colocaremos logo abaixo.
            direcao = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //Meu vetor que ja esta com os X,Y,Z Setados, vou sofrer uma transformação de direção onde passo o meu vector 3
            //transform.TransformDirection(diirecao) e multiplico pela minha velocidade
            direcao = transform.TransformDirection(direcao) * velocidade;

        }

        //Se eu apertar o input de Jump
        if (Input.GetButtonDown("Jump"))
        {
            //Vou pegar meu Y que corressponde ao eixo da gravidade e vou atribuir e acrescentar += minha variavel publica de altura de pulo
            direcao.y += alturaPulo;
        }

        // Como havia falado vou pegar meu vetor novamente, e no eixo Y vou fazer um atribuição de subtração -=
        // Logo se meu personagem está no 10 em Y - ele vai tirar 20 e vai fazer a simulação do rigidBody acontecer.
        //Quando ele bater no chão ele vai colidir e vai ficar no mundo.
        direcao.y -= gravidade * Time.deltaTime;
        //Por último vou mover meu personagem.
        //Vou pegar meu componente characterController usar uma função pré definida pela Unity
        //.MOVE - vou passar meu vector 3 que sofreu diversas alterações e multiplicar pela taxa de frames.
        personagemController.Move(direcao * Time.deltaTime);
    }

    void MudaAnimacao()
    {
        //Se meu input na horizzontal for diferente de 1 e na vertical tb, significa que estou andando logo
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") !=0.0f)
        {
            //Eu pego meu animation, troco a animação para Andar
            anima.CrossFade("Andar");
        }else
        {
            //Se não estou andando eu estou em idle
            anima.CrossFade("Idle");
        }

        //Quando eu apertar espaço eu vou pular e trocar de animação.
        if (Input.GetButtonDown("Jump"))
        {
            anima.CrossFade("Jump");
        }

        // Orientacao eixo X
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            personagemMalha.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        }
        else if (Input.GetAxis("Horizontal") < 0.0f)
        {
            personagemMalha.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
        }

        //Orientação eixo Z
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            personagemMalha.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (Input.GetAxis("Vertical") < 0.0f)
        {
            personagemMalha.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        }
    }

    //Responsável por apagar o Histórico deletando todos os player prefs
    void ApagarHistorico() {
        //Se eu apertar a tecla Q
        if (Input.GetKeyDown(KeyCode.Q)) {
            //Deleto TODOS OS PLAYERSPREFS
            PlayerPrefs.DeleteAll();
            UIFeedback.pontos= 0;
            PlayerPrefs.SetInt("UltimosPontos", 0);
            reset = true;
        }else
        {
            reset = false;
        }
    }

    //Este metodo é usado somente com CharacterController
    //Use visualStudio para chamar ele de forma automática.
    private void OnControllerColliderHit(ControllerColliderHit colisao)
    {
        //Se eu colidir com a tag Sphere1
        if (colisao.collider.CompareTag("Sphere1"))
        {
            //Estou salvando a informação em um Int - 0 ou 1 irei usar
            //Sendo que 0 eu ainda não peguei
            //E 1 eu já peguei.
            PlayerPrefs.SetInt("Sphere1", 1);
            //Destruo um objeto que vou procurar pela sua tag sphere1
            Destroy(GameObject.FindGameObjectWithTag("Sphere1"));
            UIFeedback.pontos++;
        }
        else if (colisao.collider.CompareTag("Sphere2"))
        {
            PlayerPrefs.SetInt("Sphere2", 1);
            Destroy(GameObject.FindGameObjectWithTag("Sphere2"));
            UIFeedback.pontos++;
        }
        else if (colisao.collider.CompareTag("Sphere3"))
        {
            PlayerPrefs.SetInt("Sphere3", 1);
            Destroy(GameObject.FindGameObjectWithTag("Sphere3"));
            UIFeedback.pontos++;
        }
		else if (colisao.collider.CompareTag("Sphere4"))
		{
			PlayerPrefs.SetInt("Sphere4", 1);
			Destroy(GameObject.FindGameObjectWithTag("Sphere4"));
            UIFeedback.pontos++;
        }
		else if (colisao.collider.CompareTag("Sphere5"))
		{
			PlayerPrefs.SetInt("Sphere5", 1);
			Destroy(GameObject.FindGameObjectWithTag("Sphere5"));
            UIFeedback.pontos++;
        }
		else if (colisao.collider.CompareTag("Sphere6"))
		{
			PlayerPrefs.SetInt("Sphere6", 1);
			Destroy(GameObject.FindGameObjectWithTag("Sphere6"));
            UIFeedback.pontos++;
        }
		else if (colisao.collider.CompareTag("Sphere7"))
		{
			PlayerPrefs.SetInt("Sphere7", 1);
			Destroy(GameObject.FindGameObjectWithTag("Sphere7"));
            UIFeedback.pontos++;
        }

		//Troca de cenas pela porta
		if (colisao.collider.CompareTag("Porta1")){
			SceneManager.LoadScene ("02");
		}else if (colisao.collider.CompareTag("Porta2")){
			SceneManager.LoadScene ("01");
		}
    }
}
