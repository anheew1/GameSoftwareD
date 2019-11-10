# GameSoftwareD

**We'll make first-person parking game [PC]**

**Unity version - 2019.2.10f1**

**항상 작업 시작하기전에 Github에서 FETCH & PULL 하기!!!!!!**

[이전 회의록](https://github.com/anheew1/GameSoftwareD/wiki/1st-Meeting-Log)

---
### 역할 분담

맵 과 맵 UI 팀 : 세준, 안희운

차량과 차량 UI, 점수 계산 팀: 최현인, 최운호

??: 김혁준 (정해지지 않음)

### Tags
Damage ( 파손도)

ObstacleFix ( 플레이어가 건드려도 움직이지 않는 것 ex) 주차된 자동차 )

ObstacleUnfix ( 플레이어가 건드리면 움직이는 것 ex) 꼬깔 )

PlayTime (플레이 시간)

StarRank (부가사항)

GoalSpot (도착지점)

### Scenes
Scene - 시작화면, Scene명 ex) StartScene (확정x)

Scene - 맵선택,  Scene명 - SelectMap (확정o) 

Scene - 본 게임, Scene명 ex) MainGame (확정x)

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

# 차량 관련 Requirements

* 충돌시 점수 깎이고 Damage(파손도)로 계산 (1~100%)

* Damage가 100%시 게임 오버

* 기어 
P,
R,
D
(이미지 3개면 구현 가능)

* 전진,후진 주차 둘다 가능하되 후진 주차 시 점수를 더 많이 얻음

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

## 그 외 추가로 구현하고 싶은 것
* 미니맵

* 마우스로 화면 돌리는 거

* 점수 기반으로 별 표시 ex) 별 1-3개

## 다음 회의는 11월 11일 월요일 
각 팀에서 구현한 것을 합쳐보는 시간~!


모이기 전에도 상시로 카톡 방에 정보 공유 하기

## Images

![2_CarUI](https://user-images.githubusercontent.com/28583561/67908501-11f36580-fbbf-11e9-99cd-f3977bc94927.jpg)
![2_firstStage](https://user-images.githubusercontent.com/28583561/67908569-4ebf5c80-fbbf-11e9-843c-ab57edeffce5.jpg)
![2_SecondStage](https://user-images.githubusercontent.com/28583561/67908570-4f57f300-fbbf-11e9-956c-e023c8443460.jpg)
![2_ThirdStage](https://user-images.githubusercontent.com/28583561/67908572-4f57f300-fbbf-11e9-9f48-ac6f0472a941.jpg)
![2_SelectMapAndSystem](https://user-images.githubusercontent.com/28583561/67908571-4f57f300-fbbf-11e9-8745-82a47859d529.jpg)
