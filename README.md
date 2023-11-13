# Qliphoth
2023 동양미래대학교 3학년 졸업작품

## 프로젝트 소개
Unity 및 C#으로 제작한 모바일 2D 리듬게임입니다.

![image](https://github.com/B4NG8ANG/Qliphoth/assets/50348034/37df00bb-e675-43d7-bd5c-8c9008bf4037)

![image](https://github.com/B4NG8ANG/Qliphoth/assets/50348034/906cee59-bae7-405f-892f-000e54b0ec35)

![qwer](https://github.com/B4NG8ANG/Qliphoth/assets/50348034/cddce575-57bd-4a77-8baf-28023b36eeff)

![image](https://github.com/B4NG8ANG/Qliphoth/assets/50348034/a9d0fe70-5cac-4112-9c2d-8f9f2d5180a5)

![image](https://github.com/B4NG8ANG/Qliphoth/assets/50348034/f6905631-454b-4b95-a8a2-3e6317f46f28)



## 개발 기간
2023.06.01 ~ 현재

## 개발 멤버
- B4NG8ANG: 메인 기획 및 클라이언트 프로그래밍
- Goongam: 데이터베이스 및 서버 매니저
- Hye-won-Han: UI 디자인 및 아트 디렉터

## 개발 환경
- `Unity`
- `C#` `JavaScript`
- Editor: VS Code
- Server Machine: Raspberry Pie 4
- Database: Sqlite3
- Cooperation Tool: Git & Github Desktop
- UI & Art Design: Photoshop

## 주요 기능 및 사용 기술
- 로그인, 회원가입: 구글이 제공하는 Firebase Authentication의 이메일 / 비밀번호를 이용한 사용자 인증기능을 활용하여 구현
- 게임 플레이: 화면에 나타나는 노트를 터치하여 점수를 획득하고, 정확한 타이밍에 터치 할 수록 높은 더 점수를 획득. 100만점 만점이며 받은 점수에 따라 S+부터 C까지 다른 랭크를 획득
- 오브젝트 풀링: 노트 오브젝트와 같은 오브젝트를 게임 내에서 반복적으로 생성하고 삭제하면 프레임 드랍과 같은 성능 저하를 유발하기 때문에, 이를 방지하기 위해 오브젝트 풀링 기법을 사용. 씬을 시작할 때 일정한 수의 노트 오브젝트를 미리 생성하고 배열에 넣은 뒤 사용이 필요할 때 순차적으로 활성화시키고, 사용이 끝난 오브젝트를 삭제하는 대신 비활성화시키는 방식으로 최적화 작업을 수행
- 멀티스레드: 게임 플레이 중 노트 오브젝트가 동시에 2개 이상 나타나야 할 때 이를 정확한 타이밍에 실행 될 수 있도록 코루틴을 사용. 그리고 서버와의 HTTP 통신에도 코루틴을 사용
- 플레이 기록 저장: 게임 플레이 종료 후 서버와 통신하여 서버에 구동 중인 데이터베이스에 기록 저장
- 점수 랭킹: 데이터베이스에 저장된 정보를 클라이언트로 받아오기 위해 서버와 HTTP 통신하여 JSON 형식의 유저, 점수 데이터를 받아온 뒤 JsonUtility의 FromJson을 사용하여 클래스로 파싱. 이후 해당 데이터를 클라이언트의 랭킹 창에 표시
- 플레이 기록 로컬 저장:  PlayerPrefs를 사용하여 곡 이름, 난이도 등의 문자열 조합으로 이루어진 키 값에 플레이어가 받은 점수를 문자열로 매칭시킨 뒤, 클라이언트에서 플레이어가 받은 점수를 표시해야 할 부분에 해당 키를 호출하여 값을 표시
- 패턴 에디터: JavaScript를 이용하여 웹페이지 형식의 패턴 에디터 구현. 노래 재생, 노트 생성, 노트 위치 및 시간 변경 등의 기능 수행 가능. 완성된 패턴은 코드로 추출하여 클라이언트에 삽입 가능

