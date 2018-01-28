## [생각없이 앱 개발하기] 개요 & Splash Screen

안녕하세요.<br/>
NJHouse 입니다. Xamarin.Forms PCL vs Shared 논쟁이 많이 있는데요. 저도 그 부분에 대한 명확한 구분이 없어 작은 
앱을 개발해 보면서 알아보려고 합니다. `생각없이 앱 개발하기` 를 붙인 이유는 말 그대로 미리 기획된게 아닌 그때 그때 필요한
기능을 붙이며 개발해 보려고 합니다. 주제만 정해봤습니다. 병원 및 약국 조회(이미 많은 앱들이 나와 았죠.)
전 맥이 없는 관계로 Android, `VS2015 Community` 기준으로 개발해 보겠습니다.

#### 앱 타이틀(가제)
제목은 짓고 가야겠죠. 이거 참 어려운 일인데요. 그래서 가제로 일단 짓고 좋은 타이틀이 생각나면 바꿔보죠.
`어디?병원약국` 으로 하고 진행해 보겠습니다. 그리고 패키지명은 `kr.njhouse.forhealth`로
하겠습니다.

#### 프로젝트생성
![그림1](http://i.imgur.com/JjN771N.png)
Visual Studio 2015 를 열고 `새 프로젝트 > 템플릿 > Visual C# > Cross-Platform > Blank App (Xamarin.Forms Shared)`
를 선택하고 이름을 `ForHealthFormsSahred` 로 하고 경로를 지정 후 (Git 으로 버전 관리를 하려면 `새 Git 리포지토리 만들기` 체크 박스에 체크를 합니다`) 
확인을 클릭 합니다.

![그림2](http://i.imgur.com/4ZQSsfS.png)<br/>
약간의 시간이 흐르고 나면 위 그림과 같이 5개의 프로젝트가 생성됩니다. (여기서 잠깐 카페 회워님중 `
lightdoll`님께서 알려주신 팁인데요. 사용하지 않는 프로젝트는 필요없는 로드를 제한 할 수 있습니다.)

한번 빌드를 해볼까요? 전 에뮬레이터가 아닌 갤럭시 S3를 USB로 연결해 결과를 확인해 보겠습니다.<br/>
에러(크래시)가 발생합니다.

![그림3](http://i.imgur.com/rXqsZi1.gif)

> Error 내용

```
Android application is debugging.
Cannot start debugging: Unhandled exception while trying to connect to 127.0.0.1:8979
메서드를 찾을 수 없습니다. 'System.IAsyncResult Mono.Debugger.Soft.VirtualMachineManager.BeginConnect(System.Net.IPEndPoint, System.Net.IPEndPoint, System.AsyncCallback, System.IO.TextWriter)'
```

![그림4](https://s9.postimg.org/8kw8apw9b/forhealth_splashscreen003.png)

솔루션 탐색기로 갑니다. 안드로이드 프로젝트에서 오른쪽 마우스 클릭 후 속성으로 들어갑니다. 

![그림5](https://s10.postimg.org/5m2ztq7op/forhealth_splashscreen004.png)

Application 영역 `Target Android version:` 을 선택을 안했네요. 타겟을 선택하고 다시한번 빌드 해보겠습니다.

![그림6](https://s9.postimg.org/n9huwz4ov/forhealth_splashscreen6.gif)

이제 잘 되는걸 확인할 수 있습니다.

#### AndroidManifest.xml 설정
매니페스트는 앱에 대한 정보를 기술하는 명세서로 생각하면 될거 같습니다. 그 안에는 어플리케이션 이름 패키지명 버전정보
그리고 권한 설정등을 할 수 있습니다.<br/>
`솔루션 탐색기`내에 안드로이드 프로젝트(전 `ForHealthFormsShared.Droid`입니다.)에서 오른쪽 마우스 클릭후 `속성`을
선택 합니다. 

![그림7](https://s4.postimg.org/g93zhbxz1/forhealth_splashscreen001_04.png)

- Application name: 에는 `어디?병원약국`
- Package name: 에는 `kr.njhouse.forhealth`
- Version number: 에는 `1`

나머지는 다음에 할때 설정하고 지금은 이 세가지만 입력 후 저장하고 닫습니다.

#### Splash Screen 만들기
![그림8](https://s4.postimg.org/6ilv69ptp/forhealth_splashscreen001_05.png)

페이지 구성은 위 그림과 같습니다. 2:1:7 비율이고 중간 영역에 타이틀을 하단영역 중간에 프로그래스바(링)을 넣고 
3초 후 메인 페이지로 네비게이션 하겠습니다.

`ForHealthFormsShared.Droid` 프로젝트에서 오른쪽 마우스 클릭 `추가` > `새항목` 을 선택합니다.

![그림9](https://s3.postimg.org/xu258awgj/forhealth_splashscreen001_07.png)

`Android` > `Activity` 선택하고 나서 `SplashScreen.cs` 입력하고 `추가`버튼을 클릭합니다.

> SplashScreen.cs 생성

```CSharp
using Android.App;
using Android.OS;

namespace ForHealthFormsShared.Droid
{
    // 1. MainLauncher 설정으로 시작 액티비티 선언, (MainActivity.cs 의 MainLauncher 는 제거함)
    // 2. Icon 설정
    // 3. NoHistory 설정으로 백버튼시 액티비티가 열리지 않도록 함
    [Activity(MainLauncher = true, Icon = "@drawable/icon", NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreen);
        }
    }
}
```
아직 `SplashScreen` 라는 레이아웃이 만들어지진 않았지만, 미리 View로 연결 코드를 입력합니다.

그리고 나서 SplashScreen.axml 파일을 만들고 다음과 같이 입력합니다.

> Resource > layout > SplashScreen.axml 생성

```Xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">

    <LinearLayout
        android:orientation="vertical"
        android:layout_width="match_parent"
        android:layout_height="0dp"
        android:layout_weight="2"
        android:background="#C379C5" >		
    </LinearLayout>

    <LinearLayout
        android:orientation="vertical"
        android:layout_width="match_parent"
        android:layout_height="0dp"
        android:layout_weight="1"
        android:gravity="center"
        android:background="#B7693B" >

        <TextView
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:textSize="25sp"
            android:textStyle="bold"
            android:text="어디있니? 병원 약국"/>

    </LinearLayout>

    <LinearLayout
        android:orientation="vertical"
        android:layout_width="match_parent"
        android:layout_height="0dp"
        android:layout_weight="7"
        android:gravity="center"
        android:background="#AEAEAE" >

        <ProgressBar
            android:id="@+id/progress_bar"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:layout_centerInParent="true"
            android:visibility="visible"
            style="@android:style/Widget.ProgressBar.Large.Inverse" />

    </LinearLayout>

</LinearLayout>
```

2:1:7 로 나눈 비율이 제대로 되었는지 확인하기 위해 배경색을 입혔습니다.<br/> 
중간에 타이틀은 25sp, bold 를 줬고, 하단 영역에는 프로그래스바를 입력해 넣고, 큰 링 스타일로 설정했습니다.

![그림10](https://s4.postimg.org/rdvnt1z3x/forhealth_splashscreen001_08.png)

실행해 보면 위 그림과 같이 나타납니다. 눈대중으로 봐도... 2:1:7 인거 같습니다.

실행해 보니 어색한 부분이 좀 있는거 같습니다. 실행할때 상단에 타이틀바가 크게 나타나는 부분과 SplashScreen.cs
액티비티로 넘어갈때 배경색이 하얀색에서 `SplashScreen`으로 페이지변경되는 부분입니다. 이 부분을 좀 수정해 보겠습니다.

`styles.xml` 파일을 통해 해결해 보죠.

> Resource > values > styles.xml 생성

```xml
<?xml version="1.0" encoding="utf-8" ?>
<resources>
    <style name="Theme.Splash" parent="Theme.AppCompat.Light.DarkActionBar">
        <!-- 현재 테마를 사용하는 액티비티의 타이틀을 제거합니다. -->
        <item name="windowNoTitle">true</item>
        <!-- 현재 테마를 사용하는 액티비티의 배경색을 설정합니다. -->
        <item name="android:background">#C29EDB</item>
    </style>
</resources>
```

위 파일을 만든후 `SplashScreen.cs` 파일에 테마를 적용해 보겠습니다.

> SplashScreen.cs 파일 수정

```CSharp
... 생략
// 4. Theme 를 설정합니다.
[Activity(MainLauncher =true, Icon ="@drawable/icon", NoHistory =true, Theme = "@style/Theme.Splash")]
... 생략
```

![그림11](https://s4.postimg.org/olkn5xecd/forhealth_splashscreen001_09.gif)

다시 실행해 보겠습니다. 음... 좀 어색하긴 하지만, 그 전보단 좀 나아진거 같습니다. 그럼 이제 3초 딜레이 후 `MainActivity`
로 이동해서 마무리 해보겠습니다. 

또다시 `SplashScreen.cs` 파일을 수정해 보겠습니다.

> SplashScreen.cs 파일 수정

```CSharp
... 생략
         protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreen);

            Loaded();
        }

        private async void Loaded()
        {
            await Task.Run(() => {
                Thread.Sleep(3000);
                StartActivity(typeof(MainActivity));
            });
        }
... 생략
```

`Loaded` 라는 메서드를 만들어 3초간 딜레이 후 `MainActivity` 로 이동하는 코드 입니다. 3초 딜레이 하는곳에서
꼭 필요한 처리를 하면 되겠죠. 예를 들면 Rest Api를 호출해서 데이타를 얻어온 후 디바이스에 저장을 한다든지요.

그럼 이제 마지막으로 실행해 보겠습니다.

![그림12](https://s4.postimg.org/r8mbx6ey5/forhealth_splashscreen001_10.gif)

만족할 만하진 않지만, 일단 원하는데로 만들어졌네요. 다음번에는 메인 페이지 UI 구성과 필요한 데이타를 어디서
어떻게 신청하는지에 대해서 알아보겠습니다.<br/>
 



