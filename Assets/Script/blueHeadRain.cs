// Raw Image를 사용할 경우 스크립트 수정 (예시)
using UnityEngine;
using UnityEngine.UI; // RawImage를 사용하기 위해 필요

public class BlueHeadRain : MonoBehaviour
{
    // RawImage 컴포넌트 참조
    public RawImage rawImage;
    public Vector2 ScrollSpeed = new Vector2(1f, 1f);

    void Start()
    {
        // 컴포넌트 가져오기
        if (rawImage == null)
        {
            rawImage = GetComponent<RawImage>();
        }
    }

    void Update()
    {
        if (rawImage == null) return;

        // 현재 UV Rect (Offset과 Tiling 정보를 담고 있음)
        Rect uvRect = rawImage.uvRect;

        // X, Y 오프셋을 시간에 따라 업데이트
        uvRect.x += ScrollSpeed.x * Time.deltaTime;
        uvRect.y += ScrollSpeed.y * Time.deltaTime;

        // 업데이트된 UV Rect를 다시 적용
        rawImage.uvRect = uvRect;
    }
}