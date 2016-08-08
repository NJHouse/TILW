## [생각없이 앱 개발하기] 개요 & Splash Screen

안녕하세요.<br/>
NJHouse 입니다. `생각없이 앱 개발하기` 를 붙인 이유는 말 그대로 미리 기획된게 아닌 그때 그때 필요한
기능을 붙이며 개발해 보려고 합니다. 주제만 정해봤습니다. 병원 및 약국 조회(이미 많은 앱들이 나와 았죠 ㅎㅎ)
앱을 만들면서 `Xamarin.Forms Shared` 에 대해 알아보려고 합니다. ㅎㅎ 잘 될런지 모르겠지만, 해보는거죠.
전 맥이 없는 관계로 Android기준으로 개발해 보겠습니다.

#### 앱 타이틀(가제)
제목은 짓고 가야겠죠... 이거 참 어려운 일인데요. 그래서 가제로 일단 짓고 좋은 타이틀이 생각나면 바꿔보죠.
전... `어디?병원약국` 로 하고 진행해 보겠습니다. 그리고 패키지명은 `kr.njhouse.forhealth`로
하겠습니다.

#### 프로젝트생성
![그림1](http://i.imgur.com/JjN771N.png)
Visual Studio 2015 를 열고 `새 프로젝트 > 템플릿 > Visual C# > Cross-Platform > Blank App (Xamarin.Forms Shared)`
를 선택하고 이름을 `ForHealthFormsSahred` 로 하고 경로를 지정 후 (Git 으로 버전 관리를 하려면 `새 Git 리포지토리 만들기` 체크 박스에 체크를 합니다`)확인을 합니다.

![그림2](http://i.imgur.com/4ZQSsfS.png)<br/>
약간의 시간이 흐르고 나면 위 그림과 같이 5개의 프로젝트가 생성됩니다. (여기서 잠깐 카페 회워님중 `
lightdoll`님께서 알려주신 팁인데요. 사용하지 않는 프로젝트는 필요없는 로드를 제한 할 수 있습니다.)

한번 빌드를 해볼까요? 전 에뮬레이터가 아닌 갤럭시 S3를 USB로 연결해 결과를 확인해 보겠습니다.<br/>
헉! 에러가 발생하네요... ㅡㅡ;

![그림3](http://i.imgur.com/rXqsZi1.gif)

> Error 내용

```
Android application is debugging.
Cannot start debugging: Unhandled exception while trying to connect to 127.0.0.1:8979
메서드를 찾을 수 없습니다. 'System.IAsyncResult Mono.Debugger.Soft.VirtualMachineManager.BeginConnect(System.Net.IPEndPoint, System.Net.IPEndPoint, System.AsyncCallback, System.IO.TextWriter)'
```


