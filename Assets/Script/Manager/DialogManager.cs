

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace Doublsb.Dialog
{
    public class DialogManager : MonoSingleton<DialogManager>
    {
        [Header("UI")] public GameObject Printer; //대화창 오브젝트 
        public TextMeshProUGUI PrinterText; //출력될 텍스트

        [Header("Audio")] public AudioSource SEAudio; //타이핑 효과음

        [Header("설정")] public float Delay = 0.1f; //글자 간 딜레이
        public bool LookAtCamera = true; //카메라를 바라볼지 여부

        private Coroutine printingRoutine;
        private Coroutine printRoutine;

        private bool isSkipping = false;


        public override void Awake()
        {
            base.Awake();
        }

        //Test_TestMessage_Selection에서 대사 리스트를 받아 출력
        public void Show(List<DialogData> dataList)
        {
            if (printingRoutine != null)
                StopCoroutine(printingRoutine);
            printingRoutine = StartCoroutine(PrintDialogList(dataList));
        }


        //대사 리스트 순서대로 출력
        public virtual IEnumerator PrintDialogList(List<DialogData> dataList)
        {
            Printer.SetActive(true);

            foreach (var data in dataList)
            {
                foreach (var command in data.Commands)
                {
                    if (command.Command == Command.print)
                    {
                        isSkipping = false;
                        Coroutine printCoroutine = StartCoroutine(PrintText(command.Context));


                        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButtonDown(0))
                        {
                            yield return null;
                        }

                        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                        {
                            isSkipping = true;
                        }

                        yield return printCoroutine;
                        yield return WaitForMouseClick();
                    }
                }
            }

            //yield return WaitForMouseClick();
            Printer.SetActive(false);
        }

        private IEnumerator WaitForMouseClick()
        {
            while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButtonDown(0))
            {
                yield return null;
            }

            // 클릭했으면 0.1초 정도 대기 (더블클릭 방지)
            yield return new WaitForSeconds(0.1f);
        }


        // 한 문장을 한 글자씩 출력
        private IEnumerator PrintText(string text)
        {
            PrinterText.text = "";
            string current = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (isSkipping) // 스페이스바로 스킵 시 전체 출력
                {
                    PrinterText.text = text;
                    isSkipping = false;
                    yield break;
                }

                current += text[i];
                PrinterText.text = current;

                if (text[i] != ' ' && SEAudio != null)
                    SEAudio.Play();


                yield return new WaitForSeconds(Delay);
            }
        }

    }
}