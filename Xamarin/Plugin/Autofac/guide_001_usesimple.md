##Xamarin 에서 Autofac 사용법 (Simple)

기존에 `DI` 컨테이너로 `Ninject for PCL`을 사용하고 있었습니다. DI 중 성능면에서 하위 
순위에 있었단건 알고 있었지만, 개인적으로 사용성이 편하다 생각되어서 계속 쓰고 있었는데요. 
여러 분들이 버그가 많다(개인적으로 아직끼지 경험한적은 없습니다.) 느리다 등등 좋지 않은 말씀
들을 많이 하시네요. 그래서 당장은 아니지만, 준비가 되면 변경해 볼까도 생각중입니다. 그러면서 
성능 및 사용성 면에서 적당하다고 생각되는 DI 는 `Autofac` 이란 생각이 들어서 학습을 해야겠단
생각을 하게 됐습니다. (이것도 자료가 참... 많이 없더군요. 특히 한글!) 그 학습한 내용을 정리
해봤습니다.

`새 술은 새 부대에` 란 말이 있습니다. Xamarin Studio 도 업데이트 되고 DI도 변경하고.. 기존 앱을 새 프로젝트에 
만들어야 되나 하는 생각도 드네요.

####프로젝트 생성
우선 프로젝트를 만들겠습니다.

![그림1](http://i.imgur.com/ldvoeZT.png)

App > Android App 을 선택후 `다음 팁` 버튼을 클릭 합니다.

![그림2](http://i.imgur.com/sctLIfS.png)

App 이름을 입력하고 나머지 설정을 한 후 `다음 팁` 버튼을 클릭 합니다.

![그림3](http://i.imgur.com/5YPWfW4.png)

프로젝트 이름을 입력한 후 `만들기` 버튼을 클릭해 프로젝트를 생성합니다.

![그림4](http://i.imgur.com/7XkwCi6.png)

프로젝트를 실행하면 위와 같은 Activity 가 보이며 버튼을 누르면 1씩 증가하는 간단한
예제입니다. 

####Autofac 설치
그럼 먼저 `Autofac` 을 설치해 보죠. <br/>
패키지 폴더에서 오른쪽 마우스 클릭해 나오는 팝업에서 `패키지를 추가...`(한글버전) 를 선택하면
다음과 같은 대화상자가 나타납니다.

![그림5](http://i.imgur.com/8OqP1yJ.png)

검색창에 `Autofac` 이라고 검색하고 나온 결과에서 그림에 보이는 것을 선택 후 `패키지 추가` 버튼을 
클릭합니다.

![그림6](http://i.imgur.com/RHWiGoH.png)

패키지 폴더에 `Autofac` 이 설치된 것을 확인 가능합니다.

####Coding
>MainActivity.cs

```CSharp
protected override void OnCreate(Bundle savedInstanceState)
{
    base.OnCreate(savedInstanceState);

    SetContentView(Resource.Layout.Main);

    Button button = FindViewById<Button>(Resource.Id.myButton);

    button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };    
}
```
`MainActivity.cs` 파일을 보면 버튼을 클릭 할때마다 1씩 증가하는 코드가 정의되어 있는데요. 
맨 마지막 줄 `..., count++` 부분을 변경해서 같은 기능이 되게 해보겠습니다.

`IAddRepository.cs` 을 만들고 아래와 같이 작성합니다.
>IAddRepository.cs

```CSharp
public interface IAddRepository
{
    int AddCount();
}
```
`AddRepository.cs` 을 만들고 작성합니다.
>AddRepository.cs

```CSharp

```






