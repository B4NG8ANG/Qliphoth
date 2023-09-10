# Qliphoth
2023 동양미래대학교 3학년 졸업작품

## 프로젝트 소개
Unity C# 모바일 리듬게임입니다.
![asdf](https://github.com/B4NG8ANG/Qliphoth/assets/50348034/3c113e76-ece5-4b13-ae51-d375e137238d)

![zxcvzxcvzxcv](https://github.com/B4NG8ANG/Qliphoth/assets/50348034/3c8fe28d-ab64-439f-889c-312b78d512f7)

## 개발 기간
2023.07.01 ~ 현재

## 개발 멤버
- B4NG8ANG: 메인 기획 및 클라이언트 프로그래밍
- Goongma: 데이터베이스 및 서버 매니저
- Hye-Won-Han: UI 디자인 및 아트 디렉터

## 개발 환경
- `Unity`
- `C#`
- Server Machine: Raspberry Pie 4
- Database: Sqlite3
- Cooperation Tool: Github Desktop

## 주요 기능 및 사용 기술
- 로그인, 회원가입: 구글이 제공하는 Firebase Authentication의 이메일 / 비밀번호를 이용한 사용자 인증기능을 활용하여 구현
- 게임 플레이: 화면에 나타나는 노트를 터치하여 점수를 획득하고, 정확한 타이밍에 터치 할 수록 높은 더 점수를 획득. 100만점 만점
- 플레이 기록 저장: 게임 플레이 종료 후 서버와 통신하여 서버에 구동 중인 데이터베이스에 기록 저장
- 점수 랭킹: 데이터베이스에 저장된 정보를 클라이언트로 받아오기 위해 서버와 HTTP 통신하여 JSON 형식의 유저, 점수 데이터를 받아온 뒤 JsonUtility의 FromJson을 사용하여 클래스로 파싱. 이후 해당 데이터를 클라이언트의 랭킹 창에서 보여줌

