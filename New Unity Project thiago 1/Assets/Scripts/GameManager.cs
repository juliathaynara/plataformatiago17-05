using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private string guiName; // nome da fase de interfase
    [SerializeField] private string levelName; // nome da fase de jogo
    [SerializeField] private GameObject playerAndCameraPrefab; // referencia pro prefab do jogador
    
    void Start()
    { 
        //impede que o objeto Game Manager entre parenteses seja destruido
        DontDestroyOnLoad(this.gameObject); //referencia pro objeto que contem o Game Manager
        
        //1- carregar cena da interface e do jogo
        SceneManager.LoadScene(guiName);
        //SceneManager.LoadScene(levelName, LoadSceneMode.Additive); // additive carrega uma nova cena
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive).completed += operation =>
        {
            //inicializa a variavel para guardar a cena do level com o valor padrao (default)
                    Scene levelScene = default;
                    
                    // encontrar a cena de level que esta carregando 
                    // for que itera no array as cenas abertas
                    for (int i = 0; i < SceneManager.sceneCount; i++)
                    {
                        if (SceneManager.GetSceneAt(i).name == levelName)
                        {
                            //a
                            levelScene = SceneManager.GetSceneAt(i);
                            break;
                            
                        }
                    }
                    //se variavel tiver um valor diferente do padrao, sig que ela foi alterada
                    // e a cena do level foi encontrada no array, entao faça ela ser a nova cena ativa
                    if (levelScene != default) SceneManager.SetActiveScene(levelScene);
                    
                    
                    //2- precisa instacionar o jogador na cena
                    // instancia o profab do jogador na posicao do player start com rotação zerada
                    Vector3 playerStartPosition = GameObject.Find("PlayerStart").transform.position;
                    Instantiate(playerAndCameraPrefab, playerStartPosition, Quaternion.identity);
                    
        } ;
        
        
        


        //3- começar a partida

    }
    
  
}
