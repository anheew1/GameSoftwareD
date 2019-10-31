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
N,
D
(이미지 4개면 구현 가능)

* 전진,후진 주차 둘다 가능하되 후진 주차 시 점수를 더 많이 얻음

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
