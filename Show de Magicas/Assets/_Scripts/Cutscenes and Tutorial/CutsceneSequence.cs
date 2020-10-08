using UnityEngine;
using Dubbing;
using System.Collections;
using UnityEngine.Events;

public class CutsceneSequence : MonoBehaviour
{
    //Variáveis da imagem
    [SerializeField] private GameObject[] _storyScene;
    private int index;

    //Variável da dublagem e legendas
    [SerializeField] private CutsceneVoiceActing[] _voiceActing;

    [Space]

    //Variável da animação de transição da imagem
    [SerializeField] private Animator _transitionAnimation;
    [SerializeField] private string _enterAnimationName;
    [SerializeField] private string _exitAnimationName;

    //Variável do IEnumerator
    private WaitForSeconds waitTransition;

    //Variável da ação pós cutscene
    [SerializeField] private UnityEvent _postCutsceneActions;

    private void Start()
    {
        waitTransition = new WaitForSeconds(0.75f);
        PlayCutscene();
    }

    private void PlayCutscene()
    {
        StartCoroutine(Cutscene());
    }

    private void EndCutscene()
    {
        StartCoroutine(FinishCutscene());
    }

    private IEnumerator Cutscene()
    {
        //Se não for a primeira tela
        if(index != 0)
        {
            //Toca a animação de escurecer a tela
            _transitionAnimation.Play(_enterAnimationName);
            //Espera a animação terminar
            yield return waitTransition;
            //Desativa a tela anterior
            _storyScene[index - 1].SetActive(false);
            //Ativa a tela atual
            _storyScene[index].SetActive(true);
            //Toca a animação da tela aparecer
            _transitionAnimation.Play(_exitAnimationName);
        }        
        //Espera a animação terminar
        yield return waitTransition;

        //Vai para o próximo index
        index++;

        //Se não for a última tela
        if (index < _storyScene.Length)
        {
            //Toca a cutscene 
            Subtitles.Instance.PlayDialogue(_voiceActing[index - 1].voiceAudios, _voiceActing[index - 1].subtitles, PlayCutscene);
        }
        //Se for a última tela
        else
        {
            Subtitles.Instance.PlayDialogue(_voiceActing[index - 1].voiceAudios, _voiceActing[index - 1].subtitles, EndCutscene);
        }
    }

    private IEnumerator FinishCutscene()
    {
        //Toca a animação de escurecer a tela
        _transitionAnimation.Play(_enterAnimationName);
        //Espera a animação terminar
        yield return waitTransition;

        //Executa as ações pós cutscene
        _postCutsceneActions.Invoke();
    }
}  

[System.Serializable]
public class CutsceneVoiceActing
{
    public AudioClip[] voiceAudios;
    [TextArea]
    public string[] subtitles;
}