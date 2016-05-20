##Realm

####Install

![그림1](http://i.imgur.com/WP8V4A7.png)

PCL 프로젝트에 설치 "패키지" 에서 오른쪽 마우스를 누르면 팝업 메뉴가 노출 되고 거기서 "Add Package..."
를 선택 합니다.

![그림2](http://i.imgur.com/IMRhAKB.png)

입력창에 `Realm` 이라고 입력하고, 체크박스에 체크후에 `Add Package` 버튼을 눌러 설치합니다.

![그림3](http://i.imgur.com/YrODuUK.png)

Fody 와 Realm 이 새로 생겼네요. Fody 는 잠시 살펴봤는데 INPC 바인딩시 사용하는 거 같네요.
일단 넘어가구요. (아직 Realm 은 글 작성 시점에 1.0 이 아닌 0.74.1 입니다.) 

데이타 베이스가 필요 없는 간단한 앱이라서 `PreferenceManager` 를 활용해서 저장 했었는데요. 좋다고 소문난 Realm
이 Xamarin 용으로 나왔으니, 바꿔보려고 합니다.

 