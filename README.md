# GameSoftwareD

**We'll make first-person parking game [PC]**

**Unity version - 2019.2.10f1**

**항상 작업 시작하기전에 Github에서 FETCH & PULL 하기!!!!!!**

**깃 허브 ReadMe에 업데이트 기록 꾸준히 하면 좋을 듯**

[1차 회의록](https://github.com/anheew1/GameSoftwareD/wiki/1st-Meeting-Log)
[2차 회의록](https://github.com/anheew1/GameSoftwareD/wiki/2nd-Meeting-Log)
[3차 회의록](https://github.com/anheew1/GameSoftwareD/wiki/3rd-Meeting-Log)

---

### Tags
Damage ( 파손도)

ObstacleFix ( 플레이어가 건드려도 움직이지 않는 것 ex) 주차된 자동차 )

ObstacleUnfix ( 플레이어가 건드리면 움직이는 것 ex) 꼬깔 )

PlayTime (플레이 시간)

StarRank (부가사항)

GoalSpot (도착지점)

### 화면 규격
화면 비율 16:9 (확정) 

전 씬에 통일하는 걸로 

# 맵 관련 Requirements
* 맵 디자인

    * 후진만하면 주차할수 있는 맵 (기어변경만 하면 됨)

    * 주차에 컨트롤도 하는 맵 (약간의 컨트롤이 필요)

    * T자 맵 (정교한 컨트롤이 필요)

    * 맵은 클 필요가 없음 (기본 유니티 Plain 3배정도)

    * 맵 바깥을 배경이랑 벽으로 채우기

* 필요한 프리팹 

    * 차(장애물)

    * 꼬깔

    * 주차선

    * 목적지선 

    * 기타 등등

## 스테이지 관련 개선사항

* goalspot 3D 모델이 필요함

* 각 장애물마다 충돌 모델이 필요함

# 차량 관련 Requirements

* 충돌시 점수 깎이고 Damage(파손도)로 계산 (1~100%)

* Damage가 100%시 게임 오버

* 기어 
P,
R,
D
(이미지 3개면 구현 가능)

* 전진,후진 주차 둘다 가능하되 후진 주차 시 점수를 더 많이 얻음

## 차량관련 개선사항

* 차 파손도 관련으로 정밀한 조정이 필요함

* 원하는 구역이 아닐 때 P로 주차했을 때 실패뜨는 것은 수정이 필요함

* 핸들이 너무 빠르게 움직임

* 핸들을 놨을 때 바퀴가 정위치로 돌아가는 것이 필요함

* 차 속도를 전체적으로 줄이는 것이 필요함

### 다음주까지 스테이지에 차 적용 (차량팀 담당)

* 스테이지에서 장애물 관련으로 obstacleFix 와 obstacleUnfix 태그를 구분함

### 씬 연결 - (스테이지팀 담당)
* 월요일 밤까지 끝낼 예정

* Home버튼 과 Next 버튼 씬 연결이 필요하다

* Home 버튼은 메뉴로 가고 Next 버튼은 다음 스테이지로 가게끔

## 11월 4일 차량팀 개발 사항
* CarDamage(차량 손상 제어)
   * void Die() : 차량 다 파손 됐을 경우 종료
   * void  OnTriggerEnter(Collider other) : 차량 충돌 제어

* CarUIManager(차량 화면 UI)
   * Damage : 차량 손상도
   * void OnGUI() : 차량 손상도 표시

* GameManager(게임 로직 구현) 

## 11월 5일 차량팀 개발 사항
* GearManager(기어 구동 제어)
   * GearStatus(기어 상태)

* CarUIManager(차량 화면 관리)
   * Canvas, Gear, Stick 오브젝트 추가
   * 기어 상태에 따라 Stick위치 변경 구현
   * 현재 스테이지 정보 표시
   * Start UI 구현
   * End UI 구현(실패시)
   * Pass UI 구현(성공시)
   
* WheelDrive(바퀴 작동)
   * GearManager에서 GearStatus를 가져와서 토크 결정  

* CarDamage(차량 손상 제어)
   * 도착지점에 닿으면 스테이지 종료
 
* GameManager(게임 로직 구현) 
   * Scene index 생성
   * 차량 파손으로 인한 종료 이벤트 생성
   * 도착지점에 의한 종료 이벤트

## 11월 7일 차량팀 개발 사항
* GearManager(기어 구동 제어)
   * 재시작시 기어 변경 안해도 출발하는 오류 수정

* CarDamage(차량 손상 제어)
   * 도착지점에 닿으면 스테이지 종료
 
* ScoreManager(점수 제어)
   * 랭크로 점수 설정
   * Score[] - 길이가 3인 배열로 맵 별 도전과제 클리어 확인
   * 최대 점수 3점
   * getRank() - Score 배열에서 클리어 개수 리턴

* CarUIManager
   * 게임 시작 후 우측 상단 타이머 표시
   * 게임 종료 후 타이머 숨김
   * 게임 성공 후 중앙에 노란색 별로 랭크 표시

* TimeManager
   * 타이머 변수 생성
   * 게임 진행 상태에선 타이머 증가
   * 게임 준비 상태에선 타이머 초기화

## 11월 10일 차량팀 개발 사항

* CarUIManager
   * 파손도 UI 생성, 장애물에 닿을 경우에 파손도가 5씩 깎임  
   * 파손도 0 ~ 100, 0이하로 떨어지면 게임 종료

* FrontCheck
   * 차량 앞 부분이 주차 구역에 들어가 있는지 판별

* BackCheck
   * 차량 뒷 부분이 주차 구역에 들어가 있는지 판별
   * 후진 주차 여부 판별

* GearManager
   * P 누르면 게임 종료


## 그 외 추가로 구현하고 싶은 것
* 미니맵

* 마우스로 화면 돌리는 거

* 점수 기반으로 별 표시 ex) 별 1-3개

* 별 개수 기록 데이터를 저장!

## 다음 일정은 2019-11-18 9:30 AM
실제로 파일 합쳐서 구현이 필요하는 시간

## Images

![2_CarUI](https://user-images.githubusercontent.com/28583561/67908501-11f36580-fbbf-11e9-99cd-f3977bc94927.jpg)
![2_firstStage](https://user-images.githubusercontent.com/28583561/67908569-4ebf5c80-fbbf-11e9-843c-ab57edeffce5.jpg)
![2_SecondStage](https://user-images.githubusercontent.com/28583561/67908570-4f57f300-fbbf-11e9-956c-e023c8443460.jpg)
![2_ThirdStage](https://user-images.githubusercontent.com/28583561/67908572-4f57f300-fbbf-11e9-9f48-ac6f0472a941.jpg)
![2_SelectMapAndSystem](https://user-images.githubusercontent.com/28583561/67908571-4f57f300-fbbf-11e9-8745-82a47859d529.jpg)
