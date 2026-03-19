# 👻 BlueHeadHorror 2

> **전작의 이야기는 끝나지 않았다. 더 어두워지고, 더 무서워졌다.**  
> 동아리 팀 프로젝트 | BlueHeadHorror 시리즈 2편

<br>

## 🎬 플레이 영상

[![BlueHeadHorror2 플레이 영상](https://img.youtube.com/vi/KaBTeQa7J1k/maxresdefault.jpg)](https://youtu.be/KaBTeQa7J1k)

> 이미지를 클릭하면 유튜브 영상으로 이동합니다.

<br>

## 📌 프로젝트 개요

| 항목 | 내용 |
|------|------|
| 프로젝트명 | BlueHeadHorror 2 |
| 개발 유형 | 팀 프로젝트 (동아리) |
| 개발 기간 | 2025.09.11 ~ 2025.11.25 |
| 장르 | 공포 / 어드벤처 |
| 플랫폼 | PC (Windows) |
| 전작 | BlueHeadHorror 1편과 스토리 연결 |

<br>

## 🎮 게임 소개

동아리 팀 프로젝트로 제작한 **BlueHeadHorror의 2편**입니다.  
전작의 스토리와 이어지는 세계관을 배경으로, 더 정교한 시스템과 향상된 공포 연출을 담았습니다.  
학교 전공 동아리 부스에서 시연했을 때 **플레이어들의 반응이 매우 좋았습니다.**

<br>

## ⚙️ 주요 시스템

| 시스템 | 설명 |
|--------|------|
| 🗺️ WayPoint | 플레이어가 어디로 가야 할지 화면에 방향 아이콘과 거리 표시 |
| 🌐 Localization | Google Sheets 연동, 한국어 / 영어 실시간 전환 |
| 🛤️ Spline | 적의 이동 경로를 Spline 기반으로 제어 |
| 📋 Quest | 현재 목표를 알려주는 퀘스트 진행 시스템 |

<br>

## 🛠️ 담당 기능 상세

### 🌐 1. Google Sheets 기반 Localization 시스템

Google Sheets에 키-언어별 텍스트를 작성하고, CSV 공유 링크를 통해 Unity로 데이터를 불러오는 다국어 지원 시스템입니다.

**동작 흐름:**
```
Google Sheets 작성 → CSV 공유 링크 발급
→ HttpClient로 다운로드 → Resources/Localization.csv 저장
→ 런타임에 키값으로 언어별 텍스트 반환
```

- `HttpClient`로 CSV를 다운로드해 `Resources` 폴더에 자동 저장
- 정규식으로 **셀 내부 쉼표와 구분자 쉼표를 정확히 분리**해 파싱 오류 방지
- `LocalizationManager` 싱글톤으로 전역 관리, 이벤트로 전체 텍스트 즉시 갱신

---

### 📋 2. Quest 시스템

`struct`로 퀘스트 단위 데이터를 정의하고, 배열로 퀘스트 순서를 관리하는 시스템입니다.

- 퀘스트 완료 시 `CompleteQuest()` 호출 → 카운트 체크 후 다음 퀘스트 자동 진행
- `maxCount = -1`이면 카운트 없이 단순 완료 처리
- Localization 연동으로 **언어가 바뀌어도 퀘스트 텍스트 즉시 갱신**

---

### 🗺️ 3. WayPoint UI 시스템

다음 목표 위치의 방향 아이콘과 거리(m)를 화면에 표시하는 시스템입니다.  
퀘스트가 바뀔 때마다 타깃이 자동으로 교체됩니다.

- 타깃이 **카메라 뒤에 있을 때**도 올바른 가장자리 방향으로 표시
- 거리 **5m 미만**이면 아이콘을 50% 크기로 축소 + 반투명 처리 → 시야 방해 최소화

**트러블슈팅:**

| 문제 | 원인 | 해결 |
|------|------|------|
| 타깃이 반대 방향인데 전면에 표시됨 | `screenPos.z < 0` 케이스 미처리 | 카메라 로컬 좌표계로 방향 변환 후 가장자리 위치 재계산 |

<br>

## 💡 성과 및 배운 점

- 학교 전공 동아리 부스 시연 → **플레이어 반응 매우 긍정적**
- Google Sheets ↔ Unity 연동으로 **외부 API 연동 및 CSV 파싱** 경험
- WayPoint 버그 수정 과정에서 **카메라 좌표 변환(World → Screen → Local)** 개념 심화 이해
- Spline 기반 이동으로 **내비게이션 없이도 자연스러운 적 경로 제어** 가능함을 배움

<br>

## 🛠️ 기술 스택

![Unity](https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Google Sheets](https://img.shields.io/badge/Google_Sheets-34A853?style=for-the-badge&logo=googlesheets&logoColor=white)
![ShaderLab](https://img.shields.io/badge/ShaderLab-000000?style=for-the-badge&logo=unity&logoColor=white)

<br>

## 🔗 링크

| 항목 | 링크 |
|------|------|
| 📦 다운로드 | [Releases 페이지](https://github.com/memi1252/BlueHeadHorror2/releases/tag/iinstall) |
| 🎬 플레이 영상 | [YouTube](https://youtu.be/KaBTeQa7J1k) |
| 💻 GitHub | [memi1252/BlueHeadHorror2](https://github.com/memi1252/BlueHeadHorror2) |

<br>

## 👥 팀 구성

| 이름 | 역할 |
|------|------|
| 김도영 | Localization 시스템, Quest 시스템, WayPoint UI 개발 |
| 신주혁 | 몬스터 모델링 및 아이템 모델링 |
| 나은유 | 기획 및 2D아트 |
| 성현원 | 엔딩 및 파티클 시스템 구현 |

<br>

## 📄 라이선스

본 프로젝트는 동아리 팀 프로젝트로 제작된 비상업적 작품입니다.  
별도 라이선스 명시 전까지 무단 배포 및 상업적 이용을 금합니다.
