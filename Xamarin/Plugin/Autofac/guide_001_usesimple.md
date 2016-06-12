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
public class AddRepository : IAddRepository
{
    int count = 0;

    public int AddCount()
    {
        return ++count;
    }
}
```

이전에 작성했던 인터페이스를 상속합니다. 그리고 증가값을 담는 변수 `count` 를 선언하고 
0으로 초기화 합니다. 인터페이스 파일에서 정의했던 증가값을 반환하는 메서드를 작성합니다.

이제 의존성 사용을 위한 각각의 타입을 등록하는 파일을 만들어 보겠습니다.<br />
새 클래스의 이름을 `App.cs` 라고 입력해 생성합니다.

>App.cs

```CSharp
using System;
using Android.App;
using Android.Runtime;
using Autofac;

namespace AutofacDemo
{
    #if DEBUG
    [Application(Debuggable = true, Icon = "@mipmap/icon")]
    #else
    [Application(Debuggable = false, Icon = "@mipmap/icon")]
    #endif
    public class App : Application
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<AddRepository>().As<IAddRepository>();
        builder.RegisterType<MainModel>();

        App.Container = builder.Build();

        base.OnCreate();
    }
}
```

우선 `Application` 클래스를 상속시킵니다. <br/>
의존성을 가져올 수 있게 하기 위한 정적 변수인 `Container` 를 만듭니다.<br/>
`AddRepository` 클래스는 `IAddRepository` 라고 등록하는 코드가 있구요.<br/>
그 타입을 생성자를 통해 주입 받을 모델의 타입도 선언하고 있습니다. (아직 구현하지 않았죠)

`MainModel.cs` 을 만들어 줍니다.

>MainModel.cs

```CSharp
public class MainModel
{
    private IAddRepository addRepo;

    public MainModel(IAddRepository addParam)
    {
        this.addRepo = addParam;
    }

    public int AddCount()
    {
        return this.addRepo.AddCount();
    }
}
```

이 모델에서 중점적으로 봐야 할 부분은 생성자를 통해서 의존성을 가져온다는 것입니다.<br/>
Activity 에서 상용할 `AddCount` 메서드를 작성한뒤에 의존성을 통해 카우트를 합니다.


이제 마지막으로 `MainActivity.cs` 에서 모델을 가져와 처음 얘기했던 `count++` 부분을<br/>
대체해 보겠습니다.

>MainActivity.cs

```CSharp
using Autofac;

namespace AutofacDemo
{
    protected override void OnCreate (Bundle savedInstanceState)
    {
        base.OnCreate (savedInstanceState);

        var mainmodel = App.Container.Resolve<MainModel> ();

        Button button = FindViewById<Button> (Resource.Id.myButton);

        button.Click += delegate {
            button.Text = string.Format("{0} clicks!", mainmodel.AddCount());
        };
    }
}    
```

`App.Container.Resolve<MainModel>` 를 통해서 모델 객체를 가져와 `count++` 을 <br/>
`mainmodel.AddCount()` 로 대체하였습니다.

그리고 나서 실행을 합니다. 그리고 버튼을 누르면 기존과 같이 1씩 증가 하는것을 볼 수 있습니다.<br />

이상 Xamarin.Android 에서 `Autofac` 을 사용하는 간단한 예제를 만들어 봤습니다.

####참조

소스 URL : https://github.com/NJHouse/TILW/tree/develop/Xamarin/Sample/XAndDemo/AutofacDemo








