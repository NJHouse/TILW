## [Shared] Autofac 설치

안녕하세요. NJHouse 입니다.
DI(Dependency Injection) 컨테이너 중 많이 사용되고 있는 Autofac 을 설치해 보겠습니다.

솔루션탐색기 > 프로젝트 > 참조 에서 오른쪽 마우스 클릭 하면 팝업메뉴가 나타납니다. 

그 메뉴들 중 **NuGet 패키지 관리(N)** 을 선택 합니다.

![그림1](https://s10.postimg.org/bkk4wg84p/xfncr_002_001.png)

찾아보기 탭에서 **Autofac** 을 입력 후 이미지 첫번째 나와있는 **Autofac** 을 선택 합니다.

![그림2](https://s10.postimg.org/4hc9h7d3d/xfncr_002_002.png)

안정적인 최신 버전을 확인 후 **설치** 버튼을 클릭 합니다.

![그림3](https://s10.postimg.org/mlfa1hnix/xfncr_002_003.png)

라이선스 승인 창에서 **동의함** 버튼을 클릭 합니다.

![그림4](https://s10.postimg.org/7pgqtzrkp/xfncr_002_004.png)

설치가 완료 되면 참조 영역에 **Autofac** 이 추가 된 것을 확인 할 수 있습니다.

![그림5](https://s10.postimg.org/m8nvvp2sp/xfncr_002_005.png)

(Android, iOS, UWP 각각의 프로젝트에 위와 같이 설치를 합니다.)

자 그럼 기본을 끝으로 마무리 하겠습니다.

> Shared 프로젝트 > App.xaml.cs
``` CSharp
public partial class App : Application
{
    public static IContainer Container { get; set; }    // -- 컨테이너 프로퍼티 선언

    public App()
    {
        #region Autofac 설정(Inject 기능 등록)
        var builder = new ContainerBuilder();

        // -- 여기에 Inject 할 기능을 등록한다...
        
        App.Container = builder.Build();
        #endregion
    }

    ... 생략
}
```

