using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Dubbing
{
    public class Subtitles : MonoBehaviour
    {
        //Variáveis do áudio
        [SerializeField] private AudioSource _audioSource;

        //Variáveis do texto
        [SerializeField] private TextMeshProUGUI _subtitleText;

        //Impede o usuário de iniciar a coroutine até que ela tenha terminado ou parado
        private bool _canPlay = true;

        //Guarda a referência da instância atual da coroutine
        private IEnumerator _currentCoroutine;

        public static Subtitles Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayDialogue(AudioClip[] audioVoice, string[] subtitles)
        {
            if (_canPlay)
            {
                _canPlay = false;
                //Passa a instância atual da coroutine para o coroutineAtual
                _currentCoroutine = PlayLine(audioVoice, subtitles, null);
                //Inicia a coroutine
                StartCoroutine(_currentCoroutine);
            }
        }

        public void PlayDialogue(AudioClip[] audioVoice, string[] subtitles, Action callback)
        {
            if (_canPlay)
            {
                _canPlay = false;
                //Passa a instância atual da coroutine para o coroutineAtual
                _currentCoroutine = PlayLine(audioVoice, subtitles, callback);
                //Inicia a coroutine
                StartCoroutine(_currentCoroutine);
            }
        }

        public void StopDialogue()
        {
            //Para a coroutine
            StopCoroutine(_currentCoroutine);
            //Para o audio
            _audioSource.Stop();
            //Desabilita o texto
            _subtitleText.gameObject.SetActive(false);
            //Permite que a coroutine possa iniciar
            _canPlay = true;
        }

        private IEnumerator PlayLine(AudioClip[] voiceAudio, string[] subtitles, Action callback)
        {
            for (int i = 0; i < voiceAudio.Length; i++)
            {
                //Passa a dublagem atual para o Audio Source e toca
                _audioSource.clip = voiceAudio[i];
                _audioSource.Play();

                //Faz o texto da legenda aparecer e passa a legenda atual para o texto
                _subtitleText.gameObject.SetActive(true);
                _subtitleText.text = subtitles[i];

                //Espera o audio da dublagem atual acabar
                yield return new WaitForSeconds(voiceAudio[i].length);
                //Esconde o texto da dublagem
                _subtitleText.gameObject.SetActive(false);
            }
            //Permite que a coroutine possa iniciar
            _canPlay = true;
            //Se tiver um callback registrado, ele chama a função
            callback?.Invoke();
        }
    }
}